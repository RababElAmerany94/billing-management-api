namespace COMPANY.Domain.Entities.Documents
{
    using COMPANY.Domain.Enums.General;

    /// <summary>
    /// a class describe relation between facture and devis
    /// </summary>
    public class FactureDevis : Entity<string>
    {
        public FactureDevis()
        {
            Id = Common.Helpers.IdentityDocument.Generate("FactureDevis");
        }

        /// <summary>
        /// the montant devis
        /// </summary>
        public decimal Montant { get; set; }

        /// <summary>
        /// the type montant
        /// </summary>
        public MontantType MontantType { get; set; }

        #region relations

        /// <summary>
        /// the id of devis associate with this class
        /// </summary>
        public string DevisId { get; set; }

        /// <summary>
        /// the devis entity with this class
        /// </summary>
        public Devis Devis { get; set; }

        /// <summary>
        /// the id of facture associate with this class
        /// </summary>
        public string FactureId { get; set; }

        /// <summary>
        /// the facture associate with this class
        /// </summary>
        public Facture Facture { get; set; }

        #endregion

        public override void BuildSearchTerms()
            => SearchTerms = $"";
    }
}
