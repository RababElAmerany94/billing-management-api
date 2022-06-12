namespace COMPANY.Domain.Entities.OwnedEntities
{
    /// <summary>
    /// a class define facture parameters
    /// </summary>
    public class FactureDocumentParameters
    {
        /// <summary>
        /// the validate delay of facture
        /// </summary>
        public int? ValidateDelay { get; set; }

        /// <summary>
        /// the subject of mail
        /// </summary>
        public string SujetMail { get; set; }

        /// <summary>
        /// the content of mail
        /// </summary>
        public string ContenuMail { get; set; }

        /// <summary>
        /// the sujet relance
        /// </summary>
        public string SujetRelance { get; set; }

        /// <summary>
        /// the contenu relance
        /// </summary>
        public string ContenuRelance { get; set; }

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
