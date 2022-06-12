namespace COMPANY.Application.Models.BusinessEntities.Documents.DocumentComptable
{
    using COMPANY.Domain.Entities.OwnedEntities;
    using COMPANY.Domain.Enums;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// a class describe accounting document
    /// </summary>
    public class DocumentComptableCreateModel
    {
        /// <summary>
        /// the reference of accounting document
        /// </summary>
        public string Reference { get; set; }

        /// <summary>
        /// the creation date of accounting document
        /// </summary>
        public DateTime DateCreation { get; set; }

        /// <summary>
        /// the date deadline of accounting document
        /// </summary>
        public DateTime DateEcheance { get; set; }

        /// <summary>
        /// the list of articles
        /// </summary>
        public ICollection<Article> Articles { get; set; }

        /// <summary>
        /// the object of the accounting document
        /// </summary>
        public string Objet { get; set; }

        /// <summary>
        /// the condition regulation of accounting document
        /// </summary>
        public string ReglementCondition { get; set; }

        /// <summary>
        /// the note of accounting document
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// the compteur of this accounting document
        /// </summary>
        public int Counter { get; set; }

        /// <summary>
        /// total hors taxes of accounting document
        /// </summary>
        public decimal TotalHT { get; set; }

        /// <summary>
        /// total TTC of this accounting document
        /// </summary>
        public decimal TotalTTC { get; set; }

        /// <summary>
        /// discount of accounting document
        /// </summary>
        public decimal Remise { get; set; }

        /// <summary>
        /// the type of discount <see cref="Enums.RemiseType"/>
        /// </summary>
        public RemiseType RemiseType { get; set; }

        /// <summary>
        /// the id of client associate with accounting document
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// the id of agence associate with accounting document
        /// </summary>
        public string AgenceId { get; set; }
    }
}
