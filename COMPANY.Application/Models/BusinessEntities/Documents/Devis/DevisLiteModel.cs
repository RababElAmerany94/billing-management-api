namespace COMPANY.Application.Models.BusinessEntities.Documents.Devis
{
    using COMPANY.Application.Models.BusinessEntities.General.Base;
    using COMPANY.Application.Models.BusinessEntities.Relations.FactureDevis;
    using COMPANY.Application.Models.BusinessEntitiesModels.ClientModels;
    using COMPANY.Domain.Entities.OwnedEntities;
    using COMPANY.Domain.Enums;
    using System.Collections.Generic;

    public class DevisLiteModel : EntityModel<string>
    {
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
        /// prime cee of dossier
        /// </summary>
        public ClientListModel PrimeCEE { get; set; }

        /// <summary>
        /// the articles of devis
        /// </summary>
        public ICollection<Article> Articles { get; set; }

        /// <summary>
        /// the list of factures associate with this devis
        /// </summary>
        public ICollection<FactureDevisModel> Factures { get; set; }
    }
}
