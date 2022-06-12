namespace COMPANY.Domain.Entities.Relations
{
    using COMPANY.Common.Helpers;

    public class PermissionModule : Entity<string>
    {
        public PermissionModule()
        {
            Id = IdentityDocument.Generate("PermissionModule");
        }

        /// <summary>
        /// the id of module associate with this entity
        /// </summary>
        public string ModuleId { get; set; }

        /// <summary>
        /// the module associate with this entity
        /// </summary>
        public Module Module { get; set; }

        // <summary>
        /// the id of module associate with this entity
        /// </summary>
        public string PermissionId { get; set; }

        /// <summary>
        /// the module associate with this permission
        /// </summary>
        public Permission Permission { get; set; }

        public override void BuildSearchTerms()
            => SearchTerms = $"";
    }
}
