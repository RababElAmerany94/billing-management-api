namespace COMPANY.Application.Models.General.FilterOptions
{
    using COMPANY.Domain.Enums.Documents;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// a class describe avoir filter option
    /// </summary>
    public class AvoirFilterOption : FilterOption
    {
        /// <summary>
        /// list of status
        /// </summary>
        public List<AvoirStatus> Status { get; set; }

        /// <summary>
        /// the date from
        /// </summary>
        public DateTime? DateFrom { get; set; }

        /// <summary>
        /// the date to
        /// </summary>
        public DateTime? DateTo { get; set; }

        /// <summary>
        /// the id of client 
        /// </summary>
        public string ClientId { get; set; }
    }

}
