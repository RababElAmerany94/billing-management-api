namespace COMPANY.Application.Models.Generals.Antsroute
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// a class describe base basket order
    /// </summary>
    public abstract partial class BaseBasketOrder
    {
        /// <summary>
        /// Due date of the service/delivery/collect: Maximum date for the fulfillment (format: YYYY-MM-dd)
        /// </summary>
        [JsonProperty("dueDate")]
        public string DueDate { get; set; }

        /// <summary>
        /// Specify the type to differentiate service/delivery/collect. see more <see cref="OrderType"/>
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// duration in minutes of the service/delivery/collect. max value 1440 and min value 1
        /// </summary>
        [JsonProperty("duration")]
        public int Duration { get; set; }

        /// <summary>
        /// Id in your system of the service/delivery/collect. Enable to make link between Antsroute Id and your Id. 
        /// </summary>
        [JsonProperty("externalId")]
        public string ExternalId { get; set; }

        /// <summary>
        /// comment of the service/delivery/collect
        /// </summary>
        [JsonProperty("comments")]
        public string Comments { get; set; }

        /// <summary>
        /// This object represents a time slot during which a service/delivery/collect has to be fulfilled. For example a delivery between 10:00 and 12:00
        /// not required
        /// </summary>
        [JsonProperty("timeSlot")]
        public TimeSlot TimeSlot { get; set; }

        /// <summary>
        /// Name of a skill the agent must have to fulfill this service/delivery/collect
        /// </summary>
        [JsonProperty("skill")]
        public string Skill { get; set; }

        /// <summary>
        /// Well formed email address of the agent who must execute the service/delivery/collect
        /// </summary>
        [JsonProperty("customer")]
        public Customer Customer { get; set; }

        /// <summary>
        /// Well formed email address of the agent who must execute the service/delivery/collect
        /// firstName.lastName@antsroute.com
        /// </summary>
        [JsonProperty("mandatoryAgent")]
        public string MandatoryAgent { get; set; }

        /// <summary>
        /// Custom fields for this service/delivery/collect
        /// </summary>
        [JsonProperty("customFields")]
        public List<CustomField> CustomFields { get; set; }

        /// <summary>
        /// Value of the custom field defined in Antsroute. Depending of the type of the custom field ( text, date, integer ), the value must be formatted as following
        /// </summary>
        [JsonProperty("capacities")]
        public List<Capacity> Capacities { get; set; }

        /// <summary>
        /// This object describes the loading information of the loading of a delivery.
        /// </summary>
        [JsonProperty("loading")]
        public Loading Loading { get; set; }

        /// <summary>
        /// This object describes the unloading information of the loading of a delivery.
        /// </summary>
        [JsonProperty("unloading")]
        public Loading Unloading { get; set; }
    }

    public abstract partial class BaseBasketOrder
    {
        public BaseBasketOrder()
        {
            CustomFields = new List<CustomField>();
            Capacities = new List<Capacity>();
        }
    }

    /// <summary>
    /// the class define order types
    /// </summary>
    public static class OrderType
    {
        public static string Service => "SERVICE";
        public static string Delivery => "DELIVERY";
        public static string Collect => "COLLECT";
    }
}
