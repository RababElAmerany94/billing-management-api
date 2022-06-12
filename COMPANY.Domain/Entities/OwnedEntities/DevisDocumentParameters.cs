namespace COMPANY.Domain.Entities.OwnedEntities
{
    /// <summary>
    /// a class describe devis document parameters
    /// </summary>
    public class DevisDocumentParameters
    {
        /// <summary>
        /// the validate delay of devis
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
        /// the header of PDF
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// the footer of PDF
        /// </summary>
        public string Footer { get; set; }

        /// <summary>
        /// the note of devis
        /// </summary>
        public string Note { get; set; }
    }
}
