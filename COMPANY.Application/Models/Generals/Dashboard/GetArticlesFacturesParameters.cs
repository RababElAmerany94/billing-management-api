namespace COMPANY.Application.Models.General.Dashboard
{
    using COMPANY.Domain.Enums;
    using System;
    using System.Collections.Generic;

    public class GetArticlesFacturesParameters
    {
        /// <summary>
        /// the date start
        /// </summary>
        public DateTime? DateFrom { get; set; }

        /// <summary>
        /// the date end
        /// </summary>
        public DateTime? DateTo { get; set; }

        /// <summary>
        /// the id of client  
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// the id of user
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// the id of agence 
        /// </summary>
        public string AgenceId { get; set; }

        /// <summary>
        /// is apply in facture of agences
        /// </summary>
        public bool InAgencesData { get; set; }

        /// <summary>
        /// the list of status facture
        /// </summary>
        public IEnumerable<FactureStatus> Status { get; set; }
    }
}
