namespace COMPANY.Application.Models.BusinessEntitiesModels.Documents.Devis
{
    using COMPANY.Application.Models.BusinessEntitiesModels.AddressModel;
    using COMPANY.Domain.Entities.OwnedEntities;
    using COMPANY.Domain.Enums;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// a class describe devis create model
    /// </summary>
    public class DevisCreateModel
    {
        /// <summary>
        /// the reference of devis
        /// </summary>
        public string Reference { get; set; }

        /// <summary>
        /// the site intervention of devis. 
        /// </summary>
        public AddressCreateModel SiteIntervention { get; set; }

        /// <summary>
        /// the visit date of devis
        /// </summary>
        public DateTime DateVisit { get; set; }

        /// <summary>
        /// the visit date prealabl of devis
        /// </summary>
        public DateTime? DateVisitePrealable { get; set; }

        /// <summary>
        /// the creation date of devis
        /// </summary>
        public DateTime DateCreation { get; set; }

        /// <summary>
        /// date of signature of devis
        /// </summary>
        public DateTime? DateSignature { get; set; }

        /// <summary>
        /// the articles of devis. 
        /// </summary>
        public ICollection<Article> Articles { get; set; }

        /// <summary>
        /// the status of devis
        /// </summary>
        public DevisStatus Status { get; set; }

        /// <summary>
        /// the type of devis
        /// </summary>
        public DevisType Type { get; set; }

        /// <summary>
        /// the total without tax of devis
        /// </summary>
        public decimal TotalHT { get; set; }

        /// <summary>
        /// the total TTC of devis
        /// </summary>
        public decimal TotalTTC { get; set; }

        /// <summary>
        /// the total without tax of devis
        /// </summary>
        public decimal TotalReduction { get; set; }

        /// <summary>
        /// the total paid of devis
        /// </summary>
        public decimal TotalPaid { get; set; }

        /// <summary>
        /// discount of devis
        /// </summary>
        public decimal Remise { get; set; }

        /// <summary>
        /// the type of discount of devis <see cref="Enums.RemiseType"/>
        /// </summary>
        public RemiseType RemiseType { get; set; }

        /// <summary>
        /// the raison perdu of devis
        /// </summary>
        public string RaisonPerdue { get; set; }

        #region other

        /// <summary>
        /// the note of devis
        /// </summary>
        public string Note { get; set; }

        #endregion

        #region relationship

        /// <summary>
        /// the user id of devis
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// the client id of devis
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// the dossier id of devis
        /// </summary>
        public string DossierId { get; set; }

        /// <summary>
        /// the id of agence
        /// </summary>
        public string AgenceId { get; set; }

        /// <summary>
        /// the id of bon commande associate
        /// </summary>
        public string BonCommandeId { get; set; }

        #endregion
    }
}
