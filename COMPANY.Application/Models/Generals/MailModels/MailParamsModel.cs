namespace COMPANY.Application.Models.GeneralModels.MailModels
{
    using System.Collections.Generic;

    /// <summary>
    /// a class describe mail parameters model
    /// </summary>
    public class MailParamsModel
    {
        /// <summary>
        /// the subject of mail
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// the content of mail
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// the list of emails to 
        /// </summary>
        public List<string> MessageTo { get; set; }

        /// <summary>
        /// the list of blind carbon copy
        /// </summary>
        public List<string> BCC { get; set; }

        /// <summary>
        /// the list of carbon copy
        /// </summary>
        public List<string> CC { get; set; }

        /// <summary>
        /// the list of attachment
        /// </summary>
        public List<AttachmentModel> Attachments { get; set; }
    }
}
