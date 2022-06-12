namespace COMPANY.Application.Models.BusinessEntities.Relations.FactureDevis
{
    using COMPANY.Application.Models.BusinessEntities.Documents.Devis;
    using COMPANY.Application.Models.BusinessEntities.Documents.Facture;
    using COMPANY.Application.Models.BusinessEntities.General.Base;
    using COMPANY.Application.Models.BusinessEntitiesModels.Documents.Devis;
    using COMPANY.Domain.Enums.General;
    using System;

    public class FactureDevisModel : EntityModel<string>
    {
        /// <summary>
        /// the montant devis
        /// </summary>
        public decimal Montant { get; set; }

        /// <summary>
        /// the type montant
        /// </summary>
        public MontantType MontantType { get; set; }

        /// <summary>
        /// the creation time of the model
        /// </summary>
        public DateTimeOffset CreatedOn { get; set; }

        #region relations

        /// <summary>
        /// the id of devis associate with this class
        /// </summary>
        public string DevisId { get; set; }

        /// <summary>
        /// the devis entity with this class
        /// </summary>
        public DevisLiteModel Devis { get; set; }

        /// <summary>
        /// the id of facture associate with this class
        /// </summary>
        public string FactureId { get; set; }

        /// <summary>
        /// the facture associate with this class
        /// </summary>
        public FactureLiteModel Facture { get; set; }

        #endregion
    }
}
