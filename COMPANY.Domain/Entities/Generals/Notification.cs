namespace COMPANY.Domain.Entities.Generals
{
    using COMPANY.Domain.Enums;

    /// <summary>
    /// a class describe notification class
    /// </summary>
    public class Notification : Entity<string>
    {
        public Notification()
        {
            Id = Common.Helpers.IdentityDocument.Generate("Notification");
        }

        public Notification(string title, DocType docType, string identityDocument, string userId) : this()
        {
            Title = title;
            DocType = docType;
            IdentityDocument = identityDocument;
            UserId = userId;
        }

        /// <summary>
        /// the title of notification
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// the type of document associated with notification
        /// </summary>
        public DocType DocType { get; set; }

        /// <summary>
        /// the identity of document associated with notification
        /// </summary>
        public string IdentityDocument { get; set; }

        /// <summary>
        /// is this notification has seen
        /// </summary>
        public bool IsSeen { get; set; }

        /// <summary>
        /// the id of user who has the notification
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// the id of user who has the notification
        /// </summary>
        public User User { get; set; }

        public override void BuildSearchTerms()
            => SearchTerms = $"{Title}";
    }
}
