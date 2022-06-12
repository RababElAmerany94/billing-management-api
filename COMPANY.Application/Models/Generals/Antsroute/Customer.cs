namespace COMPANY.Application.Models.Generals.Antsroute
{
    using COMPANY.Domain.Entities;
    using Newtonsoft.Json;

    /// <summary>
    /// This object represents a customer for which you want create a service/delivery/collect
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Last name of the customer
        /// </summary>
        [JsonProperty("lastName")]
        public string LastName { get; set; }

        /// <summary>
        /// First name of the customer
        /// </summary>
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        /// <summary>
        /// Address of the customer
        /// example: rue du Sergent Blandan 54000 Nancy
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; }

        /// <summary>
        /// Phone number of the customer
        /// </summary>
        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Mobile phone number of the customer in international format
        /// pattern: +XXXXXXXX
        /// example: +33612345678
        /// </summary>
        [JsonProperty("mobileNumber")]
        public string MobileNumber { get; set; }

        /// <summary>
        /// Well formed email of the customer
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// Comment about customer
        /// </summary>
        [JsonProperty("comments")]
        public string Comments { get; set; }

        /// <summary>
        /// Id in your system of the customer. Enables to make link between Antsroute Id and your Id. This Id will be unique, it will be impossible to create two customers with the same externalId
        /// </summary>
        [JsonProperty("externalId")]
        public string ExternalId { get; set; }

        public Customer()
        { }

        public Customer(Client client, string address) : this()
        {
            LastName = client.LastName;
            FirstName = client.FirstName;
            Address = address;
            PhoneNumber = client.PhoneNumber;
            //ExternalId = client.Id;
        }
    }
}
