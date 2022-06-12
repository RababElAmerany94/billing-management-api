namespace COMPANY.Application.Models.BusinessEntitiesModels.PrixProduitParAgenceModels
{
    using COMPANY.Domain.Entities;

    /// <summary>
    /// a class describe prix produit par Agence
    /// </summary>
    public class PrixProduitParAgenceUpdateModel : PrixProduitParAgenceCreateModel
    {
        /// <summary>
        /// update prix produit par agence
        /// </summary>
        /// <param name="prixProduitParAgence">the prix produit par agence</param>
        public void UpdatePrixProduitParAgence(PrixProduitParAgence prixProduitParAgence)
        {
            prixProduitParAgence.TVA = TVA;
            prixProduitParAgence.PrixHT = PrixHT;
        }
    }
}
