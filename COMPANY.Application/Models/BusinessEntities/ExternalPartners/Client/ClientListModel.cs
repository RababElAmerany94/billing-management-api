namespace COMPANY.Application.Models.BusinessEntitiesModels.ClientModels
{
    using COMPANY.Application.Models.BusinessEntities.General.Base;
    using COMPANY.Domain.Entities;
    using COMPANY.Domain.Enums;
    using System.Collections.Generic;

    /// <summary>
    /// a class describe client list model
    /// </summary>
    public class ClientListModel : EntityModel<string>
    {
        /// <summary>
        /// client Reference
        /// </summary>
        public string Reference { get; set; }

        /// <summary>
        /// the first name of the client
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// last Name of the Client
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// the full name of the Client
        /// </summary>
        public string FullName { get => $"{FirstName} {LastName}"; }

        /// <summary>
        /// type of the client
        /// </summary>
        public ClientType Type { get; set; }

        /// <summary>
        /// the label prime CEE of client
        /// </summary>
        public string LabelPrimeCEE { get; set; }

        /// <summary>
        /// the addresses of the client
        /// </summary>
        public ICollection<Address> Addresses { get; set; }

        /// <summary>
        /// list of contacts of the client. 
        /// </summary>
        public ICollection<Contact> Contacts { get; set; }

        /// <summary>
        /// the id of the agence
        /// </summary>
        public string AgenceId { get; set; }

        /// <summary>
        /// the name of agence
        /// </summary>
        public string Agence { get; set; }
    }
}
