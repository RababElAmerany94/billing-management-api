namespace COMPANY.Application.Models.General.FilterOptions
{
    using System;

    public class ReleveFacturesFilterOption
    {
        /// <summary>
        /// the client id
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// the date from 
        /// </summary>
        public DateTime DateFrom { get; set; }

        /// <summary>
        /// the date to
        /// </summary>
        public DateTime DateTo { get; set; }

        /// <summary>
        /// the facture unpaid
        /// </summary>
        public bool IsUnpaid { get; set; }

        /// <summary>
        /// include factures
        /// </summary>
        public bool IncludeFactures { get; set; }
    }
}
