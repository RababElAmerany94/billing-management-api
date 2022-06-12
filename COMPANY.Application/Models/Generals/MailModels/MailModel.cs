namespace COMPANY.Application.Models.GeneralModels.BodiesModels.MailModels
{
    /// <summary>
    /// a class describe mail model
    /// </summary>
    public class MailModel
    {
        /// <summary>
        /// that meaning send email to
        /// </summary>
        public string[] EmailTo { get; set; }

        /// <summary>
        /// the subject of email
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// the body of email   
        /// </summary>
        public string Body { get; set; }
    }
}
