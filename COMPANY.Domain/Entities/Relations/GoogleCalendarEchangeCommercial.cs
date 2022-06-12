namespace COMPANY.Domain.Entities.Relations
{
    public class GoogleCalendarEchangeCommercial : Entity<string>
    {
        public GoogleCalendarEchangeCommercial()
        {
            Id = Common.Helpers.IdentityDocument.Generate("GoogleCalendarEchangeCommercial");
        }

        /// <summary>
        /// the id of event
        /// </summary>
        public string ExternalEventId { get; set; }

        /// <summary>
        /// the id of calendar
        /// </summary>
        public string CalendarId { get; set; }

        /// <summary>
        /// the id of commercial exchange associate with this entity
        /// </summary>
        public string EchangeCommercialId { get; set; }

        /// <summary>
        /// the commercial exchange associate with this entity
        /// </summary>
        public EchangeCommercial EchangeCommercial { get; set; }

        /// <summary>
        /// the user who synchronize with his calendar
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// the id of user who synchronize with his calendar
        /// </summary>
        public string UserId { get; set; }

        public override void BuildSearchTerms()
            => SearchTerms = string.Empty;
    }
}
