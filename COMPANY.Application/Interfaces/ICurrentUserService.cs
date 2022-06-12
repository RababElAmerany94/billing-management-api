namespace COMPANY.Application.Interfaces
{
    using COMPANY.Application.Models.AccountManagement.Permission;
    using COMPANY.Application.Models.BusinessEntitiesModels.AccountModels;
    using COMPANY.Domain.Entities;
    using COMPANY.Domain.Enums.Authentification;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// an interface describe methods to get current user information
    /// </summary>
    public interface ICurrentUserService
    {
        /// <summary>
        /// the current authenticated user information
        /// </summary>
        UserTokenInformation User { get; }

        /// <summary>
        /// check if the current request is for an authenticated user
        /// </summary>
        bool IsAuthenticated { get; }

        /// <summary>
        /// check if the current logged in user is a admin,
        /// basically we check if the role type is <see cref="UserRole.Admin"/> and
        /// </summary>
        bool IsAdmin { get; }

        /// <summary>
        /// check if the current logged in user is an directeur commercial,
        /// basically we only check if the role type is <see cref="UserRole.Directeur"/>
        /// </summary>
        bool IsDirecteur { get; }

        /// <summary>
        /// check if the current logged in user is an technicien,
        /// basically we only check if the role type is <see cref="UserRole.Technicien"/>
        /// </summary>
        bool IsTechnicien { get; }

        /// <summary>
        /// check if the current logged in user is an teleprospecteur,
        /// basically we only check if the role type is <see cref="UserRole.Commercial"/>
        /// </summary>
        bool IsCommercial { get; }

        /// <summary>
        /// check if the current logged in user is an agence,
        /// basically we only check if the role type is <see cref="UserRole.AdminAgence"/>
        /// </summary>
        bool IsAgence { get; }

        /// <summary>
        /// check if the current logged in user follow an agence
        /// </summary>
        bool IsFollowAgence { get; }

        /// <summary>
        /// check if the current logged in user has the given permission
        /// </summary>
        /// <param name="permissions">the permissions to check if the user have</param>
        /// <returns>true if the user has the permission, false if not</returns>
        bool HasPermission(params PermissionModel[] permissions);

        /// <summary>
        /// get the list of permissions of the current authenticated in user
        /// </summary>
        /// <returns>the user permissions</returns>
        IEnumerable<PermissionModel> GetUserPermissions();

        /// <summary>
        /// get the user instant of the current logged in user
        /// </summary>
        /// <returns>the user instant</returns>
        Task<User> GetUserAsync();

        /// <summary>
        /// get the role of the current authenticated user
        /// </summary>
        /// <returns>role of the user</returns>
        Task<Role> GetUserRoleAsync();


        /// <summary>
        /// get the IP address of the user request
        /// </summary>
        /// <returns>the IP address of the user</returns>
        string GetUserIPAddress();
    }
}
