namespace COMPANY.Application.Models.BusinessEntitiesModels.Documents.Devis
{
    using COMPANY.Application.Models.BusinessEntities.General.Base;
    using COMPANY.Domain.Entities;

    /// <summary>
    /// a class describe devis update model
    /// </summary>
    public class DevisUpdateModel : DevisCreateModel, IEntityUpdateModel<Devis>
    {
        public void Update(Devis devis)
        {
            devis.Reference = Reference;
            devis.DateSignature = DateSignature;
            devis.DateVisit = DateVisit;
            devis.DateVisitePrealable = DateVisitePrealable;
            devis.DateCreation = DateCreation;
            devis.Articles = Articles;
            devis.Status = Status;
            devis.TotalHT = TotalHT;
            devis.TotalTTC = TotalTTC;
            devis.Remise = Remise;
            devis.RemiseType = RemiseType;
            devis.TotalReduction = TotalReduction;
            devis.TotalPaid = TotalPaid;
            devis.RaisonPerdue = RaisonPerdue;
            devis.Note = Note;
            devis.UserId = UserId;
            devis.ClientId = ClientId;
        }
    }
}
