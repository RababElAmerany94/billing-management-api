namespace COMPANY.Domain.Entities
{
    using COMPANY.Domain.Entities.Relations;
    using System.Collections.Generic;

    /// <summary>
    /// this class defines modules exits in anseris application
    /// </summary>
    public class Module : Entity<string>
    {
        /// <summary>
        /// the name of module
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// the permissions they have this module
        /// </summary>
        public ICollection<PermissionModule> PermissionModules { get; set; }

        /// <summary>
        /// the roles they have this module
        /// </summary>
        public ICollection<RoleModule> RoleModules { get; set; }

        /// <summary>
        /// build the search terms
        /// </summary>
        public override void BuildSearchTerms() 
            => SearchTerms = $"";
    }
}
