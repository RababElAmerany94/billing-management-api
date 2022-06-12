namespace COMPANY.Application.Models.Generals.Antsroute
{
    using Newtonsoft.Json;

    /// <summary>
    /// This object describes the loading information of the loading of a delivery.
    /// </summary>
    public class Loading
    {
        [JsonProperty("location")]
        public Location Location { get; set; }

        /// <summary>
        /// Duration of the loading of the delivery
        /// </summary>
        [JsonProperty("duration")]
        public int Duration { get; set; }

        /// <summary>
        /// This object represents a time slot during which a service/delivery/collect has to be fulfilled.
        /// </summary>
        [JsonProperty("timeSlot")]
        public TimeSlot TimeSlot { get; set; }

        /// <summary>
        /// Comments about the loading of the delivery.
        /// </summary>
        [JsonProperty("comments")]
        public string Comments { get; set; }
    }
}
