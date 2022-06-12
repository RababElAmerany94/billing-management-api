namespace COMPANY.Domain.Entities.Documents
{
    using COMPANY.Domain.Enums;
    using COMPANY.Domain.Enums.Documents;
    using System.Collections.Generic;

    public class Facture : DocumentComptable
    {
        public Facture() : base()
        {
            Id = Common.Helpers.IdentityDocument.Generate("Facture");
        }

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
        public ICollection<FacturePaiement> FacturePaiements { get; set; }

        /// <summary>
        /// list of avoirs
        /// </summary>
        public ICollection<Avoir> Avoirs { get; set; }

        /// <summary>
        /// the list of devis associate with this facture
        /// </summary>
        public ICollection<FactureDevis> Devis { get; set; }
    }
}
