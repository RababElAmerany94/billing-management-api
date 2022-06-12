namespace COMPANY.Application.Models.General.FilterOptions
{
    using COMPANY.Domain.Enums;
    using System.Collections.Generic;


    public class DevisFilterOption : FilterOption
    {
        /// <summary>
        /// the id of client of devis
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// the type of devis
        /// </summary>
        public DevisType? Type { get; set; }

        /// <summary>
        /// the status of devis
        /// </summary>
        public ICollection<DevisStatus> Status { get; set; } = new List<DevisStatus>();
    }
}
