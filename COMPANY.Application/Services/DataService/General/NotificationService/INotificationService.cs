namespace COMPANY.Application.Services.DataService.General.NotificationService
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Models.BusinessEntities.General.Notification;
    using COMPANY.Domain.Entities.Generals;

    public interface INotificationService
        : IBaseService<Notification, string, NotificationModel, NotificationPutModel, NotificationPutModel>
    {
        /// <summary>
        /// add set of notifications
        /// </summary>
        /// <param name="notifications">list of notifications</param>
        Task AddNotifications(IEnumerable<Notification> notifications);

        /// <summary>
        /// mark notification as seen
        /// </summary>
        /// <param name="notificationId">the id of notification</param>
        /// <returns>a result instance</returns>
        Task<Result> MarkAsSeen(string notificationId);

        /// <summary>
        /// mark all notification as seen
        /// </summary>
        /// <returns>a result instance</returns>
        Task<Result> MarkAllAsSeen();
    }
}
