namespace COMPANY.Application.Models.BusinessEntities.Documents.Paiement
{
    using COMPANY.Application.Models.BusinessEntities.General.Base;
    using COMPANY.Domain.Enums.Documents;

    /// <summary>
    /// a class describe payment update model
    /// </summary>
    public class PaiementUpdateModel : PaiementCreateModel, IEntityUpdateModel<Paiement>
    {
        /// <summary>
        /// internal update payment
        /// </summary>
        /// <param name="entity">the payment entity</param>
        public void Update(Paiement entity)
        {
            entity.Type = Type;
            entity.Montant = Montant;
            entity.DatePaiement = DatePaiement;
            entity.Description = Description;
            entity.BankAccountId = BankAccountId;
            entity.RegulationModeId = RegulationModeId;
            entity.AvoirId = AvoirId;
            entity.AgenceId = AgenceId;
        }
    }
}
