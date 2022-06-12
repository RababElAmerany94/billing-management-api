namespace COMPANY.Application.Services.DataService.BankAccountService
{
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Models.BusinessEntitiesModels.BankAccountModels;
    using COMPANY.Domain.Entities;
    using System.Threading.Tasks;

    /// <summary>
    /// an interface that defines a set of service endpoint 
    /// for working with <see cref="BankAccount"/> Entity
    /// </summary>
    public interface IBankAccountService : IBaseService<BankAccount, string, BankAccountModel, BankAccountCreateModel, BankAccountUpdateModel>
    {
        /// <summary>
        /// check if the there is any bank account with the given label or Abbreviation
        /// </summary>
        /// <param name="label">the label we want to check</param>
        Task<Result<bool>> IsUniqueAsync(string label);
    }
}
