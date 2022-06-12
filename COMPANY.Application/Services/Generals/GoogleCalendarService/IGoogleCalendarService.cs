namespace COMPANY.Application.Services.Generals.GoogleCalendarService
{
    using COMPANY.Application.Models.General.GoogleCalendar;
    using System.Threading.Tasks;

    /// <summary>
    /// an interface describes the methods that should every Google calendar service implemented
    /// </summary>
    public interface IGoogleCalendarService
    {
        /// <summary>
        /// add event to Google calendar
        /// </summary>
        /// <param name="calendarId">the identification of calendar</param>
        /// <param name="content">the content of event</param>
        /// <returns>return id of event in Google calendar</returns>
        Task<string> AddEvent(string calendarId, GoogleCalendarEvent content);

        /// <summary>
        /// add event to Google calendar
        /// </summary>
        /// <param name="eventId">the id of event</param>
        /// <param name="calendarId">the identification of calendar</param>
        /// <param name="content">the content of event</param>
        /// <returns>return id of event in Google calendar</returns>
        Task UpdateEvent(string eventId, string calendarId, GoogleCalendarEvent content);

        /// <summary>
        /// delete event to Google calendar
        /// </summary>
        /// <param name="eventId">the id of event</param>
        /// <param name="calendarId">the id of calendar</param>
        /// <returns></returns>
        Task DeleteEvent(string eventId, string calendarId);
    }
}
