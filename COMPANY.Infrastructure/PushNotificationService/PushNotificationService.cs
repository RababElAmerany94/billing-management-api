namespace COMPANY.Infrastructure.PushNotificationService
{
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Models.General.PushNotification;
    using COMPANY.Application.Models.GeneralModels;
    using COMPANY.Application.Services.Generals.PushNotificationService;
    using COMPANY.Application.Tools;
    using COMPANY.Common.Constants;
    using COMPANY.Helpers;
    using Inova.AutoInjection.Attributes;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;

    public partial class PushNotificationService : IPushNotificationService
    {
        /// <summary>
        /// send push notification
        /// </summary>
        /// <param name="parameters">the parameters to send a notification</param>
        /// <returns>a result instance</returns>
        public async Task<Result> SendNotificationAsync(SendPushNotificationParameters parameters)
        {
            try
            {
                _logger.LogInformation(
                    LogEvent.SendPushNotification,
                    "Executing [{methodName}] to send push notification with message ID [{messageId}] to users with ids : {usersIDs}",
                    nameof(SendNotificationAsync),
                    parameters.Notification.Content,
                    parameters.UserIds.ToJson());

                using (var client = new HttpClient())
                {
                    _logger.LogDebug(LogEvent.SendPushNotification, "Creating the request body...");
                    string requestBody = BuildRequestBody(parameters.UserIds, parameters.Notification);

                    _logger.LogDebug(LogEvent.SendPushNotification, "sending request to OneSignal");

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("basic", _oneSignalOptions.APIKey);
                    var response = await client.PostAsync(_oneSignalOptions.EndPoint, new StringContent(requestBody, Encoding.UTF8, "application/json"));

                    if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        _logger.LogWarning("Failed to send the push notification request response : [{@response}]", response);
                        return Result.Failed(null, "Failed to send the push notification message");
                    }

                    _logger.LogInformation(LogEvent.SendPushNotification, "the notification has been sent successfully");
                    return Result.Success("the notification has been sent successfully");
                }
            }
            catch (System.Exception ex)
            {
                _logger.LogError(LogEvent.SendPushNotification, ex, "Failed to send push notification message");
                return Result.Failed(
                    ex,
                    "Failed to send push notification message, exception has been thrown",
                    MsgCode.OperationFailedException.ToString());
            }
        }

        private string BuildRequestBody(List<string> userIds, PushNotification notification)
        {
            return new
            {
                app_id = _oneSignalOptions.AppId,
                include_external_user_ids = userIds,
                contents = new
                {
                    en = notification.Content
                },
                headings = new
                {
                    en = notification.Heading
                }
            }.ToJson();
        }
    }

    [Inject(typeof(IPushNotificationService), ServiceLifetime.Singleton)]
    public partial class PushNotificationService
    {
        private readonly OneSignalSecrets _oneSignalOptions;
        private readonly ILogger<PushNotificationService> _logger;

        public PushNotificationService(
            IOptions<AppSettings> options,
            ILogger<PushNotificationService> logger)
        {
            _oneSignalOptions = options.Value.OneSignalSecrets;
            _logger = logger;
        }
    }
}
