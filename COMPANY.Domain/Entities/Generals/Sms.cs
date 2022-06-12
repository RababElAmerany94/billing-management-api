namespace COMPANY.Domain.Entities.Generals
{
    using COMPANY.Domain.Enums.General;
    using System;
    using System.Collections.Generic;

    public partial class Sms
    {
        /// <summary>
        /// the phone number
        /// </summary>
        public string NumeroTelephone { get; set; }

        /// <summary>
        /// the message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// is this sms blocked
        /// </summary>
        public bool IsBloquer { get; set; }

        /// <summary>
        /// date of send or receive response
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// the type of sms send or response
        /// </summary>
        public SmsType Type { get; set; }

        /// <summary>
        /// the id of sms in external platforme
        /// </summary>
        public string ExternalId { get; set; }

        #region relationships

        /// <summary>
        /// the id of sms sent associated with sms
        /// </summary>
        public string SmsEnvoyeId { get; set; }

        /// <summary>
        /// the sms sent associated with sms
        /// </summary>
        public Sms SmsEnvoye { get; set; }

        /// <summary>
        /// the id of client associated with sms
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// the client associated with sms
        /// </summary>
        public Client Client { get; set; }

        /// <summary>
        /// the dossier associated with sms
        /// </summary>
        public string DossierId { get; set; }

        /// <summary>
        /// the id of dossier associated with sms
        /// </summary>
        public Dossier Dossier { get; set; }

        /// <summary>
        /// the list of responses to sent sms
        /// </summary>
        public ICollection<Sms> Reponses { get; set; }

        #endregion
    }

    public partial class Sms : Entity<string>
    {
        public Sms()
        {
            Id = Common.Helpers.IdentityDocument.Generate("SMS");
            Reponses = new HashSet<Sms>();
        }

        public void AddResponse(DateTime date, string message, string numeroTelephone, string externalId)
        {
            var sms = new Sms()
            {
                IsBloquer = false,
                Type = SmsType.Recevoir,
                ClientId = ClientId,
                DossierId = DossierId,
                ExternalId = externalId,
                Date = date,
                Message = message,
                NumeroTelephone = numeroTelephone,
                SmsEnvoyeId = Id,
            };

            Reponses.Add(sms);
        }

        public override void BuildSearchTerms()
            => SearchTerms = $"";
    }
}
