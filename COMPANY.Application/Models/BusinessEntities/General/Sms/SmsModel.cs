namespace COMPANY.Application.Models.BusinessEntities.General.Sms
{
    using COMPANY.Application.Models.BusinessEntities.General.Base;
    using COMPANY.Domain.Enums.General;
    using System;
    using System.Collections.Generic;

    public class SmsModel : EntityModel<string>
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
        /// the list of responses to sent sms
        /// </summary>
        public ICollection<SmsModel> Reponses { get; set; }

        #endregion
    }
}
