namespace COMPANY.Application.Models.AccountManagement.Permission
{
    using COMPANY.Application.Models.BusinessEntities.General.Base;
    using COMPANY.Domain.Enums.Authentification;
    using System.Collections.Generic;

    public class PermissionModel : EntityModel<string>
    {
        /// <summary>
        /// the access of permission
        /// </summary>
        public Access Access { get; set; }

        /// <summary>
        /// the modules of permission
        /// </summary>
        public ICollection<PermissionModuleModel> Modules { get; set; }
    }
}
