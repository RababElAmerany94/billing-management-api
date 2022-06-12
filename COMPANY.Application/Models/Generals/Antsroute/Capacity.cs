namespace COMPANY.Application.Models.Generals.Antsroute
{
    using Newtonsoft.Json;

    /// <summary>
    /// This object represents a capacity(e.g.volume) for a service/delivery/collect and its value.
    /// </summary>
    public class Capacity
    {
        /// <summary>
        /// Name of the capacity type defined in Antsroute. This name should respect case and accent
        /// </summary>
        [JsonProperty("capacityName")]
        public string CapacityName { get; set; }

        /// <summary>
        /// Value of the related capacity name for the order
        /// </summary>
        [JsonProperty("capacityValue")]
        public long CapacityValue { get; set; }
    }
}
