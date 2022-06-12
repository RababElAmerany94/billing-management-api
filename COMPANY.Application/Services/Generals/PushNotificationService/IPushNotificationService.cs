namespace COMPANY.Application.Services.Generals.PushNotificationService
{
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Models.General.PushNotification;
    using System.Threading.Tasks;

    /// <summary>
    /// an interface describes methods should offer push notification service
    /// </summary>
    public interface IPushNotificationService
    {
        /// <summary>
        /// send push notification
        /// </summary>
        /// <param name="parameters">the parameters to send a notification</param>
        /// <returns>a result instance</returns>
        Task<Result> SendNotificationAsync(SendPushNotificationParameters parameters);
    }
}
