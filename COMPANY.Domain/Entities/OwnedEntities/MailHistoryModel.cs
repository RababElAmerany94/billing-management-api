namespace COMPANY.Domain.Entities.OwnedEntities
{
    using System;


    /// <summary>
    /// a class describe mail history model
    /// </summary>
    public class MailHistoryModel
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

        /// <summary>
        /// the date of creation this history mail object
        /// </summary>
        public DateTime DateCreation { get; set; }

        /// <summary>
        /// the id of user
        /// </summary>
        public string UserId { get; set; }
    }
}
