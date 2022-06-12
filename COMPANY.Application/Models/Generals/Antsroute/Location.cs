namespace COMPANY.Application.Models.Generals.Antsroute
{
    using Newtonsoft.Json;

    /// <summary>
    /// This location object is used when adding loading/unloading information when you want to create a delivery or a collect
    /// </summary>
    public class Location
    {
        /// <summary>
        /// example: Warehouse A
        /// Name of the location
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Address of the location
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; }
    }
}
