namespace COMPANY.Application.Services.DataService.BankAccountService
{
    using AutoMapper;
    using COMPANY.Application.Data;
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Exceptions;
    using COMPANY.Application.Interfaces;
    using COMPANY.Application.Models.BusinessEntitiesModels.BankAccountModels;
    using COMPANY.Common.Helpers;
    using COMPANY.Domain.Entities;
    using Inova.AutoInjection.Attributes;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    /// <summary>
    /// the implementation of the <see cref="IBankAccountService"/>
    /// </summary>
    [Inject(typeof(IBankAccountService), ServiceLifetime.Scoped)]
    public class BankAccountService :
        BaseService<BankAccount, string, BankAccountModel, BankAccountCreateModel, BankAccountUpdateModel>,
        IBankAccountService
    {

        public BankAccountService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IDataRequestBuilder<BankAccount> requestBuilder,
            ICurrentUserService currentUserService
        ) : base(requestBuilder, unitOfWork, mapper, currentUserService)
        { }

        /// <summary>
        /// check if the there is any bank account with the given label or Abbreviation
        /// </summary>
        /// <param name="label">the label we want to check</param>
        /// <returns>true if unique, else false</returns>
        public async Task<Result<bool>> IsUniqueAsync(string label)
        {
            var predicate = PredicateBuilder.True<BankAccount>()
                .And(e => e.Name.ToLower() == label.ToLower());

            if (_user.IsFollowAgence)
                predicate = predicate.And(c => c.AgenceId == _user.AgenceId);
            else
                predicate = predicate.And(c => !c.AgenceId.IsValid());

            var result = await _dataAccess.IsExistAsync(predicate);

            return Result<bool>.Success(!result);
        }

        #region overrides

        protected override Expression<Func<BankAccount, bool>> BuildGetAsPagedPredicate<TFilter>(TFilter filterOption)
        {
            var predicate = PredicateBuilder.True<BankAccount>();

            // the current logged in user could be an agence or any other user
            // the key here is to use the agence id on the user entity
            if (_user.IsFollowAgence)
                predicate = predicate.And(c => c.AgenceId == _user.AgenceId);
            else
                predicate = predicate.And(c => !c.AgenceId.IsValid());

            return predicate;
        }

        protected override async Task BeforeDeleteEntity(string id)
        {
            var entity = await GetEntityByIdAsync(id);

            if (!entity.IsModify)
                throw new UnAuthorizedException("this bank account is not modifiable");
        }

        protected override Task BeforeUpdateEntity(BankAccount entity, BankAccountUpdateModel model)
        {
            if (!entity.IsModify)
                model.Name = entity.Name;

            return base.BeforeUpdateEntity(entity, model);
        }

        #endregion

    }
}
