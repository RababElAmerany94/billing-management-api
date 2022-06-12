namespace COMPANY.Application.Services.DataService.PeriodeComptableService
{
    using AutoMapper;
    using COMPANY.Application.Data;
    using COMPANY.Application.DataInteraction.DataAccess;
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Interfaces;
    using COMPANY.Application.Models.BusinessEntitiesModels.AccountingPeriodModals;
    using COMPANY.Common.Helpers;
    using COMPANY.Domain.Entities;
    using Company.AutoInjection.Attributes;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    /// <summary>
    /// the implementation of the <see cref="IPeriodeComptableService"/>
    /// </summary>
    [Inject(typeof(IPeriodeComptableService), ServiceLifetime.Scoped)]
    public class PeriodeComptableService :
        BaseService<PeriodeComptable, string, PeriodeComptableModel, PeriodeComptableCreateModel, PeriodeComptableUpdateModel>, IPeriodeComptableService
    {
        private readonly IPeriodeComptableDataAccess _periodeComptableDataAccess;

        public PeriodeComptableService(
            IDataRequestBuilder<PeriodeComptable> dataRequestBuilder,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ICurrentUserService currentUser) : base(dataRequestBuilder, unitOfWork, mapper, currentUser)
        {
            _periodeComptableDataAccess = unitOfWork.PeriodeComptableDataAccess;
        }

        /// <summary>
        /// closing periode comptable
        /// </summary>
        /// <param name="PeriodeComptableId"></param>
        /// <returns></returns>
        public async Task<Result> ClosingPeriodComptable(string PeriodeComptableId)
        {
            var result = await _dataAccess.GetAsync(PeriodeComptableId);

            result.DateCloture = DateTime.Now;
            result.IsClose = true;
            result.UserId = _user.Id;
            var dateEndPeriodComptable = result.DateDebut.AddMonths(result.Period).AddDays(-1);

            var resultAccountingDocuments = await _periodeComptableDataAccess.ClotureComptable(result.DateDebut, dateEndPeriodComptable, result.AgenceId);

            /// if all documents accounting
            if (resultAccountingDocuments.HasValue && resultAccountingDocuments.Value)
            {
                _dataAccess.Update(result);
                await _unitOfWork.SaveChangesAsync();
                return Result.Success("the period comptable closed successfully");
            }
            else
                return Result.Failed(null, "Failed, an exception has been thrown");
        }

        #region overrides

        protected override Expression<Func<PeriodeComptable, bool>> BuildGetAsPagedPredicate<TFilter>(TFilter filterOption)
        {
            var predicate = PredicateBuilder.True<PeriodeComptable>()
                .And(e => !e.IsClose);

            // the current logged in user could be an associate or any other user
            // the key here is to use the agence id on the user entity
            if (_user.IsFollowAgence)
                predicate = predicate.And(c => c.AgenceId == _user.AgenceId);
            else
                predicate = predicate.And(c => !c.AgenceId.IsValid());

            return predicate;
        }

        #endregion
    }
}
