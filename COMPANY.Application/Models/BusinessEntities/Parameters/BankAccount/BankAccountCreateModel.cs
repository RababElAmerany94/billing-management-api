namespace COMPANY.Application.Models.BusinessEntitiesModels.BankAccountModels
{
    using COMPANY.Domain.Enums;

    /// <summary>
    /// a class describe bank account create model
    /// </summary>
    public class BankAccountCreateModel
    {
        /// <summary>
        /// the name of bank account
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// the accounting code of bank account
        /// </summary>
        public string CodeComptable { get; set; }

        /// <summary>
        /// the type of account
        /// </summary>
        public BankAccountType Type { get; set; }

        /// <summary>
        /// is this account modify
        /// </summary>
        public bool IsModify { get; set; }

        /// <summary>
        /// the id of Agence involved with this account
        /// </summary>
        public string AgenceId { get; set; }
    }
}
