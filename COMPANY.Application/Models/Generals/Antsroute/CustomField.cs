namespace COMPANY.Application.Models.Generals.Antsroute
{
    using Newtonsoft.Json;

    /// <summary>
    /// This object represents an order customer field defined in your Antsroute account.
    /// This allow you to add your own field properties to a service/delivery/collect
    /// </summary>
    public class CustomField
    {
        /// <summary>
        /// Name of the custom field defined in Antsroute. This name should respect case and accent
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Value of the custom field defined in Antsroute. Depending of the type of the custom field ( text, date, integer ), the value must be formatted as following
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
