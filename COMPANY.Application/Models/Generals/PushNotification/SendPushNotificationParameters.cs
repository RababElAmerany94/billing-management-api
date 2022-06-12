namespace COMPANY.Application.Models.General.PushNotification
{
    using System.Collections.Generic;

    /// <summary>
    /// a class describe send notification parameters
    /// </summary>
    public class SendPushNotificationParameters
    {
        /// <summary>
        /// the list of users ids
        /// </summary>
        public List<string> UserIds { get; set; }

        /// <summary>
        /// the notification
        /// </summary>
        public PushNotification Notification { get; set; }
    }

    public class PushNotification
    {
        /// <summary>
        /// the heading of notification
        /// </summary>
        public string Heading { get; set; }

        /// <summary>
        /// the content of notification
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// the data of notification
        /// </summary>
        public object Data { get; set; }
    }
}
