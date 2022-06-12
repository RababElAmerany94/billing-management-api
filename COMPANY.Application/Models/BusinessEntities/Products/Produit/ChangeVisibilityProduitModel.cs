namespace COMPANY.Application.Models.BusinessEntitiesModels.ProduitModels
{
    /// <summary>
    /// a class describe change visibility of produit model
    /// </summary>
    public class ChangeVisibilityProduitModel
    {
        /// <summary>
        /// the id of produit
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// is this produit visible to agence
        /// </summary>
        public bool IsPublic { get; set; }
    }
}
