namespace COMPANY.Application.Models.BusinessEntitiesModels.PrixProduitParAgenceModels
{
    /// <summary>
    /// a class describe  prix produit par agence model
    /// </summary>
    public class PrixProduitParAgenceCreateModel
    {
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
    }
}
