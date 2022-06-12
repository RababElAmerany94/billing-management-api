namespace COMPANY.Domain.Entities.OwnedEntities
{
    public class BonCommandeParameters
    {
        /// <summary>
        /// the validate delay of bon de commande
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
        /// the note of bon commande
        /// </summary>
        public string Note { get; set; }
    }
}
