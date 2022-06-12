namespace COMPANY.Application.Models.BusinessEntities.Documents.DossierPV
{
    using COMPANY.Application.Models.BusinessEntities.General.Base;
    using COMPANY.Domain.Entities;

    /// <summary>
    /// a class describe dossier PV update model
    /// </summary>
    public class DossierPVUpdateModel : DossierPVCreateModel, IEntityUpdateModel<DossierPV>
    {
        public void Update(DossierPV entity)
        {
            entity.Photos = Photos;
            entity.Articles = Articles;
            entity.IsSatisfied = IsSatisfied;
            entity.ReasonNoSatisfaction = ReasonNoSatisfaction;
            entity.NameClientSignature = NameClientSignature;
            entity.SignatureClient = SignatureClient;
            entity.SignatureTechnicien = SignatureTechnicien;
        }
    }
}
