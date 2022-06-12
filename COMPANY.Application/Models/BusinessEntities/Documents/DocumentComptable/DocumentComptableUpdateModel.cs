namespace COMPANY.Application.Models.BusinessEntities.Documents.DocumentComptable
{
    using COMPANY.Application.Models.BusinessEntities.General.Base;
    using COMPANY.Domain.Entities.Documents;

    /// <summary>
    /// a class describe accounting document update model
    /// </summary>
    public class DocumentComptableUpdateModel : DocumentComptableCreateModel, IEntityUpdateModel<DocumentComptable>
    {
        /// <summary>
        /// update the accounting document from the current accounting document Model
        /// </summary>
        /// <param name="entity">the accounting document instant to be updated</param>
        public void Update(DocumentComptable entity)
        {
            entity.Reference = Reference;
            entity.DateCreation = DateCreation;
            entity.DateEcheance = DateEcheance;
            entity.Articles = Articles;
            entity.Objet = Objet;
            entity.ReglementCondition = ReglementCondition;
            entity.Note = Note;
            entity.Counter = Counter;
            entity.TotalHT = TotalHT;
            entity.Remise = Remise;
            entity.RemiseType = RemiseType;
            entity.ClientId = ClientId;
        }
    }
}
