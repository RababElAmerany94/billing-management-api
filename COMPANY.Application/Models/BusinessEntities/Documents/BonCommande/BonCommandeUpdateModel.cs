namespace COMPANY.Application.Models.BusinessEntities.Documents.BonCommande
{
    using COMPANY.Application.Models.BusinessEntities.General.Base;
    using COMPANY.Domain.Entities.Documents;
    using Inova.AutoMapperRegister.Attributes;

    [ModelFor(typeof(BonCommande))]
    public class BonCommandeUpdateModel : BonCommandeCreateModel, IEntityUpdateModel<BonCommande>
    {
        public void Update(BonCommande bonCommande)
        {
            bonCommande.Reference = Reference;
            bonCommande.DateSignature = DateSignature;
            bonCommande.NameClientSignature = NameClientSignature;
            bonCommande.Signe = Signe;
            bonCommande.DateVisit = DateVisit;
            bonCommande.Articles = Articles;
            bonCommande.Status = Status;
            bonCommande.TotalHT = TotalHT;
            bonCommande.TotalTTC = TotalTTC;
            bonCommande.TotalReduction = TotalReduction;
            bonCommande.TotalPaid = TotalPaid;
            bonCommande.Remise = Remise;
            bonCommande.RemiseType = RemiseType;
            bonCommande.RaisonAnnulation = RaisonAnnulation;
            bonCommande.Note = Note;
            bonCommande.UserId = UserId;
            bonCommande.ClientId = ClientId;
        }
    }
}
