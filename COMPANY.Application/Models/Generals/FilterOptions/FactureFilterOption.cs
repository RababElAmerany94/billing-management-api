namespace COMPANY.Application.Models.General.FilterOptions
{
    using COMPANY.Domain.Enums;
    using System;
    using System.Collections.Generic;

    public class FactureFilterOption : FilterOption
    {
        /// <summary>
        /// list of status
        /// </summary>
        public List<FactureStatus> Status { get; set; }

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

        /// <summary>
        /// the id of oblige
        /// </summary>
        public string PrimeCeeId { get; set; }
    }
}
