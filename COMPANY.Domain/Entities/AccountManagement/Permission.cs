namespace COMPANY.Domain.Entities
{
    using COMPANY.Domain.Entities.Relations;
    using COMPANY.Domain.Enums.Authentification;
    using System.Collections.Generic;

    /// <summary>
    /// this class defines the permission of role in a module
    /// </summary>
    public class Permission : Entity<string>
    {
        /// <summary>
        /// the name of permission
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// the access of permission
        /// </summary>
        public Access Access { get; set; }

        /// <summary>
        /// the role id
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// the role
        /// </summary>
        public Role Role { get; set; }

        /// <summary>
        /// the modules they have this permission
        /// </summary>
        public ICollection<PermissionModule> Modules { get; set; }

        /// <summary>
        /// build search terms
        /// </summary>
        public override void BuildSearchTerms() 
            => SearchTerms = $"";
    }
}
