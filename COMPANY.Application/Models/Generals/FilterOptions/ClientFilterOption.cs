
namespace COMPANY.Application.Models.GeneralModels.PagingModels
{
    using COMPANY.Domain.Enums;
    using System.Collections.Generic;

    /// <summary>
    /// a class describe client filter options
    /// </summary>
    public class ClientFilterOption : FilterOption
    {
        /// <summary>
        /// filter by type
        /// </summary>
        public IEnumerable<ClientType> Types { get; set; }

        /// <summary>
        /// the type of client
        /// </summary>
        public ClientType? Type { get; set; }

    }
}
