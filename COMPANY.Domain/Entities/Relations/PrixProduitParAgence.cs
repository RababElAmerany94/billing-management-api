namespace COMPANY.Domain.Entities
{
    /// <summary>
    /// a class describe prix produit par agence
    /// </summary>
    public class PrixProduitParAgence : Entity<string>
    {
        public PrixProduitParAgence()
        {
            Id = Common.Helpers.IdentityDocument.Generate("PrixProduitParAgence");
        }

        /// <summary>
        /// the price HT
        /// </summary>
        public decimal PrixHT { get; set; }

        /// <summary>
        /// the custom TVA
        /// </summary>
        public double TVA { get; set; }

        /// <summary>
        /// the id of produit associate with this entity
        /// </summary>
        public string ProduitId { get; set; }

        /// <summary>
        /// the produit associate with this entity
        /// </summary>
        public Produit Produit { get; set; }

        /// <summary>
        /// the id of the agence
        /// </summary>
        public string AgenceId { get; set; }

        /// <summary>
        /// the agence related to this entity, could be null
        /// </summary>
        public Agence Agence { get; set; }

        public override void BuildSearchTerms() => SearchTerms = $"";
    }
}
