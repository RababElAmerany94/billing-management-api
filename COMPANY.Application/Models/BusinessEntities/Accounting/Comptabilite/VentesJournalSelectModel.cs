namespace COMPANY.Application.Models.BusinessEntities.Accounting.Comptabilite
{
    using COMPANY.Application.Enums;
    using COMPANY.Domain.Entities.OwnedEntities;
    using COMPANY.Domain.Enums;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// a class describe select sales journal model
    /// </summary>
    public class VentesJournalSelectModel
    {
        /// <summary>
        /// the accounting document id
        /// </summary>
        public string AccountingDocumentId { get; set; }

        /// <summary>
        /// the reference of accounting document
        /// </summary>
        public string Reference { get; set; }

        /// <summary>
        /// the date of creation accounting document
        /// </summary>
        public DateTime DateCreation { get; set; }

        /// <summary>
        /// the client name
        /// </summary>
        public string ClientName { get; set; }

        /// <summary>
        /// the accounting code of client
        /// </summary>
        public string ClientAccountingCode { get; set; }

        /// <summary>
        /// the articles of accounting document
        /// </summary>
        public ICollection<Article> Articles { get; set; }

        /// <summary>
        /// the total TTC of accounting document
        /// </summary>
        public decimal TotalTTC { get; set; }

        /// <summary>
        /// the type of item sales journal
        /// </summary>
        public DocumentComptableType Type { get; set; }

        /// <summary>
        /// is the articles accounting
        /// </summary>
        public bool IsArticlesAccounting { get; set; }

        /// <summary>
        /// the discount of accounting document
        /// </summary>
        public decimal Remise { get; set; }

        /// <summary>
        /// the type of discount of accounting document
        /// </summary>
        public RemiseType RemiseType { get; set; }
    }
}
