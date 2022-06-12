namespace Xterme.Application.Models.GeneralModels.PagingModels
{
    using System;
    using COMPANY.Application.Models;

    /// <summary>
    /// the payment filter option
    /// </summary>
    public class PaiementFilterOption : FilterOption
    {
        /// <summary>
        /// the date from
        /// </summary>
        public DateTime? DateFrom { get; set; }
        /// <summary>
        /// the date to 
        /// </summary>
        public DateTime? DateTo { get; set; }
        /// <summary>
        /// the id of bank account
        /// </summary>
        public string BankAccountId { get; set; }
    }
}
