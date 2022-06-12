namespace COMPANY.Domain.Entities
{
    using COMPANY.Domain.Enums;
    using COMPANY.Domain.Enums.Documents;
    using System.Collections.Generic;

    /// <summary>
    /// a class describe bank account 
    /// </summary>
    public class BankAccount : Entity<string>
    {
        public BankAccount()
        {
            Id = Common.Helpers.IdentityDocument.Generate("BankAccount");
        }

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

        #region relations

        /// <summary>
        /// the list of paiements associate with this regulation mode
        /// </summary>
        public ICollection<Paiement> Paiements { get; set; }

        /// <summary>
        /// the id of agence involved with this account
        /// </summary>
        public string AgenceId { get; set; }

        /// <summary>
        /// the agence involved with this account
        /// </summary>
        public Agence Agence { get; set; }

        #endregion

        public override void BuildSearchTerms() => SearchTerms = $"{Name}";
    }
}
