namespace COMPANY.Application.Models.BusinessEntities.Documents.DocumentComptable
{
    using COMPANY.Application.Models.BusinessEntities.General.Base;
    using COMPANY.Application.Models.General;
    using COMPANY.Domain.Entities.OwnedEntities;
    using COMPANY.Domain.Enums;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// a class describe accounting document model
    /// </summary>
    public class DocumentComptableModel : EntityModel<string>
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
        /// is this accounting document comptabilise
        /// </summary>
        public bool Comptabilise { get; set; }

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
        public int? Counter { get; set; }

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
        /// the historique of document.
        /// </summary>
        public ICollection<ChangesHistory> Historique { get; set; }

        /// <summary>
        /// represent the memos that this document owns.
        /// </summary>
        public ICollection<Memo> Memos { get; set; }

        /// <summary>
        /// the list of email sent
        /// </summary>
        public ICollection<MailHistoryModel> Emails { get; set; }

        #region relations

        /// <summary>
        /// the id of client associate with accounting document
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// the client associate this accounting document
        /// </summary>
        public ClientModel Client { get; set; }

        /// <summary>
        /// list of documents associates.
        /// </summary>
        public ICollection<DocumentAssociate> DocumentAssociates { get; set; } = new List<DocumentAssociate>();

        #endregion
    }
}
