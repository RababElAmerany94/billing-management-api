namespace COMPANY.Application.Models.BusinessEntitiesModels.AccountModels
{
    using COMPANY.Domain.Entities;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// a class describe commercial planning model
    /// </summary>
    public class CommercialPlanningModel
    {
        /// <summary>
        /// the id of the user
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// the first name of the user
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// the last name of the user
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// the full name of user
        /// </summary>
        public string FullName { get => $"{FirstName} {LastName}"; }

        /// <summary>
        /// the list of dossier associate with this commercial
        /// </summary>
        public IEnumerable<DossierCommercialPlanningModel> Dossiers { get; set; }
    }

    public class DossierCommercialPlanningModel
    {
        /// <summary>
        /// the id of dossier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// the date of RDV of dossier
        /// </summary>
        public DateTime DateRDV { get; set; }

        /// <summary>
        /// the client id of dossier
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// the address of client.
        /// </summary>
        public Address SiteIntervention { get; set; }

        /// <summary>
        ///  the contact of the client. 
        /// </summary>
        public Contact Contact { get; set; }

        /// <summary>
        /// the client first name
        /// </summary>
        public string ClientFirstName { get; set; }

        /// <summary>
        /// the client last name
        /// </summary>
        public string ClientLastName { get; set; }
    }
}
