namespace COMPANY.Application.Models.Generals.Antsroute
{
    using Newtonsoft.Json;
    using System;

    /// <summary>
    /// a class describe result basket order
    /// </summary>
    public class BasketOrderResult : BaseBasketOrder
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("scheduledDate")]
        public DateTime? ScheduledDate { get; set; }

        [JsonProperty("estimatedTimeOfArrival")]
        public TimeSpan? EstimatedTimeOfArrival { get; set; }

        [JsonProperty("affectedAgent")]
        public string AffectedAgent { get; set; }
    }
}
