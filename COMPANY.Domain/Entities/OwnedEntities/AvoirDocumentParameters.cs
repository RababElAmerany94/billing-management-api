namespace COMPANY.Domain.Entities.OwnedEntities
{
    /// <summary>
    /// a class define avoir parameters
    /// </summary>
    public class AvoirDocumentParameters
    {
        /// <summary>
        /// the validate delay of facture
        /// </summary>
        public int? ValidateDelay { get; set; }

        /// <summary>
        /// the header of PDF
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// the footer of PDF
        /// </summary>
        public string Footer { get; set; }

        /// <summary>
        /// the note of facture
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// the regulation condition of facture
        /// </summary>
        public string RegulationCondition { get; set; }
    }
}
