namespace COMPANY.Application.Models.BusinessEntities.General.Notification
{
    using COMPANY.Application.Models.BusinessEntities.General.Base;
    using COMPANY.Domain.Enums;
    public class NotificationModel : EntityModel<string>
    {
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
    }
}
