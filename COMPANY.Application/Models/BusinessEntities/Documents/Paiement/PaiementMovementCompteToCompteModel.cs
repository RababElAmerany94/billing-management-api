namespace COMPANY.Application.Models.BusinessEntities.Documents.Paiement
{
    /// <summary>
    /// a class describe body of movement account to account
    /// </summary>
    public class PaiementMovementCompteToCompteModel
    {
        /// <summary>
        /// the id of account debit
        /// </summary>
        public string CompteDebitId { get; set; }

        /// <summary>
        /// the id of credit account
        /// </summary>
        public string CreditCompteId { get; set; }

        /// <summary>
        /// the amount of movement
        /// </summary>
        public decimal Montant { get; set; }

        /// <summary>
        /// the description of the payment
        /// </summary>
        public string Description { get; set; }
    }
}
