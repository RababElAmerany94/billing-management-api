namespace COMPANY.Domain.Enums.Documents
{
    using COMPANY.Domain.Entities;
    using COMPANY.Domain.Entities.Documents;

    /// <summary>
    /// a class describe facture payment
    /// </summary>
    public class FacturePaiement : Entity<string>
    {
        public FacturePaiement()
        {
            Id = Common.Helpers.IdentityDocument.Generate("FacturePaiement");
        }

        /// <summary>
        /// the amount of facture payment
        /// </summary>
        public decimal Montant { get; set; }

        /// <summary>
        /// the id of payment of facture payment
        /// </summary>
        public string PaiementId { get; set; }

        /// <summary>
        /// the payment of facture payment
        /// </summary>
        public Paiement Paiement { get; set; }

        /// <summary>
        /// the id of facture of facture payment
        /// </summary>
        public string FactureId { get; set; }

        /// <summary>
        /// the facture of facture payment
        /// </summary>
        public Facture Facture { get; set; }

        public override void BuildSearchTerms() => SearchTerms = $"";
    }
}
