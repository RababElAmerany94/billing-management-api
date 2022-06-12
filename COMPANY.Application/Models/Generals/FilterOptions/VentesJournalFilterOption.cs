namespace COMPANY.Application.Models.General.FilterOptions
{
    using COMPANY.Application.Enums;
    using System;

    public class VentesJournalFilterOption : FilterOption
    {
        /// <summary>
        /// the period of vente
        /// </summary>
        public Period Period { get; set; }

        /// <summary>
        /// the date from 
        /// </summary>
        public DateTime? DateFrom { get; set; }

        /// <summary>
        /// the date to
        /// </summary>
        public DateTime? DateTo { get; set; }
    }
}
