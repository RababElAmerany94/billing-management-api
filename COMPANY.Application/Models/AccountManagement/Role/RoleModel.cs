namespace COMPANY.Application.Models.AccountManagement.Role
{
    using COMPANY.Application.Models.AccountManagement.Permission;
    using COMPANY.Application.Models.BusinessEntities.General.Base;
    using System.Collections.Generic;

    /// <summary>
    /// a class that defines a model for <see cref="Domain.Entities.Role"/>
    /// </summary>
    public class RoleModel : EntityModel<int>
    {
        /// <summary>
        /// the name/label of the role
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// the permission of this role
        /// </summary>
        public ICollection<PermissionModel> Permissions { get; set; }

        /// <summary>
        /// the permission of this role
        /// </summary>
        public ICollection<RoleModuleModel> Modules { get; set; }
    }
}
