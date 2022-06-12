namespace COMPANY.Domain.Entities.Relations
{
    using COMPANY.Domain.Enums.Authentification;

    public class RoleModule : Entity<string>
    {
        public RoleModule()
        { }

        public RoleModule(string id, UserRole role, string moduleId) : this()
        {
            Id = id;
            RoleId = (int)role;
            ModuleId = moduleId;
        }

        /// <summary>
        /// the role id
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// the module id
        /// </summary>
        public string ModuleId { get; set; }

        /// <summary>
        /// the role
        /// </summary>
        public Role Role { get; set; }

        /// <summary>
        /// the module
        /// </summary>
        public Module Module { get; set; }

        /// <summary>
        /// build the search terms
        /// </summary>
        public override void BuildSearchTerms()
            => SearchTerms = $"";
    }
}
