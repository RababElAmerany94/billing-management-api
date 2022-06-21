namespace COMPANY.Infrastructure.GoogleCalendarService
{
    using COMPANY.Application.Models.General.GoogleCalendar;
    using COMPANY.Application.Models.GeneralModels;
    using COMPANY.Application.Services.Generals.GoogleCalendarService;
    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Calendar.v3;
    using Google.Apis.Calendar.v3.Data;
    using Google.Apis.Services;
    using Inova.AutoInjection.Attributes;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// a class describe Google calendar service
    /// </summary>
    [Inject(typeof(IGoogleCalendarService), ServiceLifetime.Singleton)]
    public class GoogleCalendarService : IGoogleCalendarService
    {
        /// <summary>
        /// scopes to connect
        /// </summary>
        private readonly string[] _scopes = {
            CalendarService.Scope.Calendar
        };

        private readonly GoogleCalendarSecrets _googleCalendarSecret;
        private readonly ILogger<GoogleCalendarService> _logger;

        public GoogleCalendarService(
            IOptions<AppSettings> options,
            ILogger<GoogleCalendarService> logger)
        {
            _googleCalendarSecret = options.Value.GoogleCalendarSecrets;
            _logger = logger;
        }


        /// <summary>
        /// add event to Google calendar
        /// </summary>
        /// <param name="calendarId">the identification of calendar</param>
        /// <param name="content">the content of event</param>
        /// <returns>return id of event in Google calendar</returns>
        public async Task<string> AddEvent(string calendarId, GoogleCalendarEvent content)
        {
            try
            {
                var service = BuildCalendarService();
                var calendarEvent = BuildCalendarEvent(content);
                Event eventAdd = await service.Events.Insert(calendarEvent, calendarId).ExecuteAsync();
                return eventAdd.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError("The event has not been inserted because {Reason}", ex.Message);
                return string.Empty;
            }
        }

        /// <summary>
        /// add event to Google calendar
        /// </summary>
        /// <param name="eventId">the id of event</param>
        /// <param name="calendarId">the identification of calendar</param>
        /// <param name="content">the content of event</param>
        /// <returns>return id of event in Google calendar</returns>
        public async Task UpdateEvent(string eventId, string calendarId, GoogleCalendarEvent content)
        {
            try
            {
                var service = BuildCalendarService();
                var calendarEvent = BuildCalendarEvent(content);
                await service.Events.Update(calendarEvent, calendarId, eventId).ExecuteAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("The event has not been updated because {Reason}", ex.Message);
            }
        }

        /// <summary>
        /// delete event to Google calendar
        /// </summary>
        /// <param name="eventId">the id of event</param>
        /// <param name="calendarId">the id of calendar</param>
        /// <returns></returns>
        public async Task DeleteEvent(string eventId, string calendarId)
        {
            try
            {
                var service = BuildCalendarService();
                await service.Events.Delete(calendarId, eventId).ExecuteAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("The event has not been updated because {Reason}", ex.Message);
            }
        }

        #region private methods 

        /// <summary>
        /// build calendar event
        /// </summary>
        /// <param name="content">the content of event</param>
        /// <returns></returns>
        private Event BuildCalendarEvent(GoogleCalendarEvent content)
        {
            // create event
            Event calendarEvent = new Event()
            {
                Summary = content.Title,
                Description = content.Body,
                Start = new EventDateTime() { DateTime = content.StartDate },
                End = new EventDateTime() { DateTime = content.EndDate ?? content.EndDate },
                Location = content.Location,
            };

            return calendarEvent;
        }

        /// <summary>
        /// build Google calendar service
        /// </summary>
        /// <returns></returns>
        private CalendarService BuildCalendarService()
        {
            var credential = new ServiceAccountCredential(
                new ServiceAccountCredential.Initializer(_googleCalendarSecret.ClientEmail)
                {
                    Scopes = _scopes
                }.FromPrivateKey(_googleCalendarSecret.PrivateKey)
             );

            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
            });

            return service;
        }

        #endregion
    }
}
