namespace COMPANY.Application.Models.BusinessEntitiesModels.ProduitModels
{
    using COMPANY.Application.Models.BusinessEntities.General.Base;
    using COMPANY.Domain.Entities;

    /// <summary>
    /// a class describe produit update model
    /// </summary>
    public class ProduitUpdateModel : ProduitCreateModel, IEntityUpdateModel<Produit>
    {
        /// <summary>
        /// update produit
        /// </summary>
        /// <param name="produit"></param>
        public void Update(Produit produit)
        {
            produit.Reference = Reference;
            produit.PrixAchat = PrixAchat;
            produit.PrixHT = PrixHT;
            produit.TVA = TVA;
            produit.Description = Description;
            produit.Designation = Designation;
            produit.PrixParTranche = PrixParTranche;
            produit.Unite = Unite;
            produit.IsPublic = IsPublic;
            produit.Labels = Labels;
            produit.FournisseurId = FournisseurId;
            produit.CategoryId = CategoryId;
        }
    }
}
