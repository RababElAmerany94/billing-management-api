namespace COMPANY.Application.Models.General.GoogleCalendar
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// a class describe Google calendar event model
    /// </summary>
    public class GoogleCalendarEvent
    {
        /// <summary>
        /// the title event 
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// the body of event
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// the start date of event
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// the end date of event
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// the location of the event
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// the attendees of event
        /// </summary>
        public List<Attendee> Attendees { get; set; }
    }

    /// <summary>
    /// the attendee of Google calendar event
    /// </summary>
    public class Attendee
    {
        /// <summary>
        /// the name of attendee
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// the email of attendee
        /// </summary>
        public string Email { get; set; }
    }
}
