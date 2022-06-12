namespace COMPANY.Application.Models.BusinessEntities.Documents.Facture
{
    using COMPANY.Application.Models.BusinessEntities.Documents.DocumentComptable;
    using COMPANY.Application.Models.BusinessEntities.Relations.FactureDevis;
    using COMPANY.Domain.Enums;
    using COMPANY.Domain.Enums.Documents;
    using System.Collections.Generic;

    public class FactureModel : DocumentComptableModel
    {
        /// <summary>
        /// the type of facture
        /// </summary>
        public FactureType Type { get; set; }

        /// <summary>
        /// the total without tax of devis
        /// </summary>
        public decimal TotalReduction { get; set; }

        /// <summary>
        /// the total paid of devis
        /// </summary>
        public decimal TotalPaid { get; set; }

        /// <summary>
        /// the numero AH of client
        /// </summary>
        public string NumeroAH { get; set; }

        /// <summary>
        /// the status of facture 
        /// </summary>
        public FactureStatus Status { get; set; }

        /// <summary>
        /// list of facture paiements
        /// </summary>
        public ICollection<FacturePaiementModel> FacturePaiements { get; set; }

        /// <summary>
        /// the list of devis associate with this facture
        /// </summary>
        public ICollection<FactureDevisModel> Devis { get; set; }
    }
}
