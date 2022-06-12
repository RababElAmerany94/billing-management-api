namespace COMPANY.Application.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// a class describe user filter options
    /// </summary>
    public class UserFilterOption : FilterOption
    {

        /// <summary>
        /// filter by roles
        /// </summary>
        public List<int> RolesId { get; set; }

        /// <summary>
        /// get all users
        /// </summary>
        public bool? IsAll { get; set; }

        /// <summary>
        /// the id of Agence
        /// </summary>
        public string AgenceId { get; set; }

    }
}
