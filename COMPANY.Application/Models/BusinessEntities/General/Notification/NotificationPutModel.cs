namespace COMPANY.Application.Models.BusinessEntities.General.Notification
{
    using COMPANY.Application.Models.BusinessEntities.General.Base;
    using COMPANY.Domain.Entities.Generals;
    using COMPANY.Domain.Enums;
    public class NotificationPutModel : IEntityUpdateModel<Notification>
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
        /// the id of user who has the notification
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// update notification
        /// </summary>
        /// <param name="entity"></param>
        public void Update(Notification entity)
        { }
    }
}
