namespace COMPANY.Application.Models.BusinessEntities.Documents.FicheControle
{
    using COMPANY.Application.Models.BusinessEntities.General.Base;
    using COMPANY.Domain.Entities;

    public class FicheControleUpdateModel
        : FicheControleCreateModel, IEntityUpdateModel<FicheControle>
    {
        public void Update(FicheControle entity)
        {
            entity.NumberOperation = NumberOperation;
            entity.DateControle = DateControle;
            entity.PrestationType = PrestationType;
            entity.Photos = Photos;
            entity.ConstatCombles = ConstatCombles;
            entity.ConstatPlanchers = ConstatPlanchers;
            entity.ConstatMurs = ConstatMurs;
            entity.Remarques = Remarques;
            entity.EvaluationAccompagnement = EvaluationAccompagnement;
            entity.EvaluationTravauxRealises = EvaluationTravauxRealises;
            entity.EvaluationPropreteChantier = EvaluationPropreteChantier;
            entity.EvaluationContactAvecTechniciensApplicateurs = EvaluationContactAvecTechniciensApplicateurs;
            entity.SignatureController = SignatureController;
            entity.SignatureClient = SignatureClient;
            entity.NameClientSignature = NameClientSignature;
            entity.ControllerId = ControllerId;
        }
    }
}
