namespace COMPANY.Application.Models.BusinessEntities.Accounting.Comptabilite
{
    using System;

    /// <summary>
    /// a class describe sales journal model
    /// </summary>
    public class VentesJournalModel
    {
        /// <summary>
        /// the code journal 
        /// </summary>
        public string CodeJournal { get; set; }

        /// <summary>
        /// the date of creation
        /// </summary>
        public DateTime DateCreation { get; set; }

        /// <summary>
        /// the account number
        /// </summary>
        public string NumeroCompte { get; set; }

        /// <summary>
        /// the piece number
        /// </summary>
        public string NumeroPiece { get; set; }

        /// <summary>
        /// the client name
        /// </summary>
        public string ClientName { get; set; }

        /// <summary>
        /// the debit
        /// </summary>
        public decimal Debit { get; set; }

        /// <summary>
        /// the credit
        /// </summary>
        public decimal Credit { get; set; }
    }
}
