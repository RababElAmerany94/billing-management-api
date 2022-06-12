namespace COMPANY.Application.Models.BusinessEntitiesModels.BankAccountModels
{
    using COMPANY.Application.Models.BusinessEntities.General.Base;
    using COMPANY.Domain.Entities;

    /// <summary>
    /// a class describe bank accounting update model
    /// </summary>
    public class BankAccountUpdateModel : BankAccountCreateModel, IEntityUpdateModel<BankAccount>
    {
        /// <summary>
        /// internal update bank account 
        /// </summary>
        /// <param name="bankAccount">the bank account</param>
        public void Update(BankAccount bankAccount)
        {
            bankAccount.CodeComptable = CodeComptable;
            bankAccount.Name = Name;
        }
    }
}
