using Microsoft.Extensions.Logging;

namespace COMPANY.Application.Tools
{
    /// <summary>
    /// a struct event id of logger
    /// </summary>
    public struct LogEvent
    {
        #region general

        public static EventId GetItemNotFound = new EventId(1001);
        public static EventId UnAuthorizedException = new EventId(1002);
        public static EventId JsonException = new EventId(1003);
        public static EventId UnHandledException = new EventId(1004);

        #endregion

        #region push notification

        public static EventId SendPushNotification = new EventId(1005);

        #endregion

        #region antsroute

        public static EventId AntsrouteCreateBasketOrder = new EventId(1006);
        public static EventId AntsrouteGetBasketOrder = new EventId(1007);
        public static EventId AntsrouteDeleteBasketOrder = new EventId(1008);
        public static EventId AntsrouteEmailNotExistsInSystem = new EventId(1008);

        #endregion

        #region Spothit

        public static EventId SpothitFailedSend = new EventId(1009);
        public static EventId SpothitFailedSaveResponse = new EventId(1010);
        public static EventId SpothitFailedStopSms = new EventId(1011);

        #endregion
    }
}
