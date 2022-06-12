namespace COMPANY.Application.Models.Generals.Antsroute
{
    using Newtonsoft.Json;
    using System;

    /// <summary>
    /// This object represents a time slot during which a service/delivery/collect has to be fulfilled. For example a delivery between 10:00 and 12:00
    /// </summary>
    public class TimeSlot
    {
        /// <summary>
        /// start time of the time slot
        /// </summary>
        [JsonProperty("start")]
        public TimeSpan Start { get; set; }

        /// <summary>
        /// end time of the time slot
        /// </summary>
        [JsonProperty("end")]
        public TimeSpan End { get; set; }
    }
}
