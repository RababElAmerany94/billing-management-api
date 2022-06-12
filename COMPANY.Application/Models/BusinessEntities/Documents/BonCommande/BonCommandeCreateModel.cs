namespace COMPANY.Application.Models.BusinessEntities.Documents.BonCommande
{
    using COMPANY.Application.Models.BusinessEntitiesModels.AddressModel;
    using COMPANY.Domain.Entities.Documents;
    using COMPANY.Domain.Entities.OwnedEntities;
    using COMPANY.Domain.Enums;
    using COMPANY.Domain.Enums.Documents;
    using Company.AutoMapperRegister.Attributes;
    using System;
    using System.Collections.Generic;

    [ModelFor(typeof(BonCommande))]
    public class BonCommandeCreateModel
    {
        /// <summary>
        /// the reference of bon commande
        /// </summary>
        public string Reference { get; set; }

        /// <summary>
        /// the site intervention of bon commande. 
        /// </summary>
        public AddressCreateModel SiteIntervention { get; set; }

        /// <summary>
        /// the visit date of bon commande
        /// </summary>
        public DateTime DateVisit { get; set; }

        /// <summary>
        /// the articles of bon commande. 
        /// </summary>
        public ICollection<Article> Articles { get; set; }

        /// <summary>
        /// the status of bon commande
        /// </summary>
        public BonCommandeStatus Status { get; set; }

        /// <summary>
        /// the type of bon commande
        /// </summary>
        public DevisType Type { get; set; }

        /// <summary>
        /// the total without tax of bon commande
        /// </summary>
        public decimal TotalHT { get; set; }

        /// <summary>
        /// the total TTC of bon commande
        /// </summary>
        public decimal TotalTTC { get; set; }

        /// <summary>
        /// the total without tax of bon commande
        /// </summary>
        public decimal TotalReduction { get; set; }

        /// <summary>
        /// the total paid of bon commande
        /// </summary>
        public decimal TotalPaid { get; set; }

        /// <summary>
        /// discount of bon de commande
        /// </summary>
        public decimal Remise { get; set; }

        /// <summary>
        /// the type of bon de commande <see cref="Enums.RemiseType"/>
        /// </summary>
        public RemiseType RemiseType { get; set; }

        /// <summary>
        /// the raison annulation of bon commande
        /// </summary>
        public string RaisonAnnulation { get; set; }

        #region signature

        /// <summary>
        /// date of signature of bon commande
        /// </summary>
        public DateTime? DateSignature { get; set; }

        /// <summary>
        /// the signature image base64 of bon commande
        /// </summary>
        public string Signe { get; set; }

        /// <summary>
        /// the name of who sign bon commande
        /// </summary>
        public string NameClientSignature { get; set; }

        #endregion

        #region other

        /// <summary>
        /// the note of bon commande
        /// </summary>
        public string Note { get; set; }

        #endregion

        #region relationship

        /// <summary>
        /// the user id of bon commande
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// the client id of bon commande
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// the dossier id of bon commande
        /// </summary>
        public string DossierId { get; set; }

        /// <summary>
        /// the id of agence
        /// </summary>
        public string AgenceId { get; set; }

        #endregion
    }
}
