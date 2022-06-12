namespace COMPANY.Domain.Entities
{
    /// <summary>
    /// a class that describe a contact information
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// the civility of contact
        /// </summary>
        public string Civilite { get; set; }

        /// <summary>
        /// the first name of contact
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// the last name of contact
        /// </summary>
        public string Prenom { get; set; }

        /// <summary>
        /// the job of contact
        /// </summary>
        public string Fonction { get; set; }

        /// <summary>
        /// the email of contact
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// the mobile phone of contact
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// the fixe of contact
        /// </summary>
        public string Fixe { get; set; }

        /// <summary>
        /// the comment of contact
        /// </summary>
        public string Commentaire { get; set; }

        /// <summary>
        /// is default contact
        /// </summary>
        public bool? IsDefault { get; set; }
    }
}
