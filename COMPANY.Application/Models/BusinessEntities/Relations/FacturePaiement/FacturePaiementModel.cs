namespace COMPANY.Application.Models.BusinessEntities.Documents
{
    using COMPANY.Application.Models.BusinessEntities.Documents.Facture;
    using COMPANY.Application.Models.BusinessEntities.Documents.Paiement;

    /// <summary>
    /// a class describe facture payment model
    /// </summary>
    public class FacturePaiementModel
    {
        /// <summary>
        /// this id of facture payment
        /// </summary>
        public string Id { get; set; }

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
        public PaiementModel Paiement { get; set; }

        /// <summary>
        /// the id of facture of facture payment
        /// </summary>
        public string FactureId { get; set; }
        /// <summary>
        /// the facture of facture payment
        /// </summary>
        public FactureModel Facture { get; set; }
    }
}
