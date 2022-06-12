namespace COMPANY.Application.Models.BusinessEntities.General.Sms
{
    /// <summary>
    /// a class describe send
    /// </summary>
    public class EnvoyerSmsModel
    {
        /// <summary>
        /// the id client associé with this sms
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// the id dossier associé with this sms
        /// </summary>
        public string DossierId { get; set; }

        /// <summary>
        /// the phone number of receiver
        /// </summary>
        public string NumeroTelephone { get; set; }

        /// <summary>
        /// the message of SMS
        /// </summary>
        public string Message { get; set; }
    }
}
