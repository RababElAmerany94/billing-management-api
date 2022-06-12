namespace COMPANY.Application.Models.BusinessEntitiesModels.AccountModels
{
    using COMPANY.Application.Models.AccountManagement.Permission;
    using COMPANY.Common.Helpers;
    using COMPANY.Domain.Enums.Authentification;
    using System.Collections.Generic;

    /// <summary>
    /// the information contains user token
    /// </summary>
    public class UserTokenInformation
    {
        /// <summary>
        /// the id of logging user
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// the id of agence 
        /// </summary>
        public string AgenceId { get; set; }

        /// <summary>
        /// the role of the user
        /// </summary>
        public UserRole RoleId { get; set; }

        /// <summary>
        /// is this account active
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// is this user follow agence
        /// </summary>
        public bool IsFollowAgence => AgenceId.IsValid();

        /// <summary>
        /// the name of user
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// the userName of user
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// the role name of role name
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// the email of user
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// user-accessible modules
        /// </summary>
        public ICollection<string> Modules { get; set; }

        /// <summary>
        /// permission of user
        /// </summary>
        public ICollection<PermissionModel> Permissions { get; set; }
    }
}
