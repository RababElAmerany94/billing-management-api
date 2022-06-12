namespace COMPANY.Application.Models.BusinessEntities.Documents.Facture
{
    using COMPANY.Application.Models.BusinessEntities.Documents.DocumentComptable;
    using COMPANY.Application.Models.BusinessEntities.Relations.FactureDevis;
    using COMPANY.Domain.Enums;
    using COMPANY.Domain.Enums.Documents;
    using System.Collections.Generic;

    /// <summary>
    /// a class describe facture create model
    /// </summary>
    public class FactureCreateModel : DocumentComptableCreateModel
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
        /// the list of devis associate with this facture
        /// </summary>
        public ICollection<FactureDevisCreateModel> Devis { get; set; }
    }
}
