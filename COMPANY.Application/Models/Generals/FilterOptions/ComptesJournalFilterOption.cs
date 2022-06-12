namespace COMPANY.Application.Models.General.FilterOptions
{
    using COMPANY.Application.Enums;
    using System;

    public class ComptesJournalFilterOption : FilterOption
    {
        /// <summary>
        /// is the journal for caisse
        /// </summary>
        public bool IsForCaisse { get; set; }

        /// <summary>
        /// the period of sales journal
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
