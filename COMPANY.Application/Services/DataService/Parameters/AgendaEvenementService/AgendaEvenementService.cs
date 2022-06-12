namespace COMPANY.Application.Services.DataService.Parameters.AgendaEvenementService
{
    using AutoMapper;
    using COMPANY.Application.Data;
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Interfaces;
    using COMPANY.Application.Models.BusinessEntities.Parameters.AgendaEvenementType;
    using COMPANY.Application.Models.Generals.FilterOptions;
    using COMPANY.Domain.Entities.Parameters;
    using Company.AutoInjection.Attributes;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    [Inject(typeof(IAgendaEvenementService), ServiceLifetime.Scoped)]
    public class AgendaEvenementService :
        BaseService<AgendaEvenement, string, AgendaEvenementModel, AgendaEvenementCreateModel, AgendaEvenementUpdateModel>,
        IAgendaEvenementService
    {
        public AgendaEvenementService(IDataRequestBuilder<AgendaEvenement> dataRequestBuilder,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ICurrentUserService currentUser) : base(dataRequestBuilder, unitOfWork, mapper, currentUser)
        { }

        /// <summary>
        /// check if the there is any agenda evenement type with the given name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>true if unique, else false</returns>
        public async Task<Result<bool>> IsUniqueAsync(string name)
        {
            var result = await _dataAccess.IsExistAsync(e => e.Name.ToLower() == name.ToLower());
            return Result<bool>.Success(!result);
        }

        #region overrides

        protected override Expression<Func<AgendaEvenement, bool>> BuildGetAsPagedPredicate<TFilter>(TFilter filterModel)
        {
            var predicate = PredicateBuilder.True<AgendaEvenement>();

            if (filterModel is AgendaEvenementFilterOption filterOption)
            {
                if (filterOption.Type.HasValue)
                    predicate = predicate.And(e => e.Type == filterOption.Type.Value);
            }

            return predicate;
        }

        #endregion
    }
}
