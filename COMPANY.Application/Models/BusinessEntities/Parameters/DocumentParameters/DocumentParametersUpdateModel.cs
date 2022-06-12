namespace COMPANY.Application.Models.BusinessEntitiesModels.DocumentParametersModels
{
    using COMPANY.Application.Models.BusinessEntities.General.Base;
    using COMPANY.Domain.Entities;

    /// <summary>
    /// a class describe document parameteres update model
    /// </summary>
    public class DocumentParametersUpdateModel : DocumentParametersCreateModel, IEntityUpdateModel<DocumentParameters>
    {
        /// <summary>
        /// update document parameters
        /// </summary>
        /// <param name="entity"></param>
        public void Update(DocumentParameters entity)
        {
            entity.Avoir = Avoir;
            entity.Facture = Facture;
            entity.Devis = Devis;
            entity.BonCommande = BonCommande;
            entity.TVA = TVA;
        }
    }
}
