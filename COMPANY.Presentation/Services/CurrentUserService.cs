namespace COMPANY.Presentation.Services
{
    using COMPANY.Application.DataInteraction.DataAccess.Base;
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Interfaces;
    using COMPANY.Application.Models.AccountManagement.Permission;
    using COMPANY.Application.Models.BusinessEntitiesModels.AccountModels;
    using COMPANY.Common.Constants;
    using COMPANY.Common.Helpers;
    using COMPANY.Domain.Entities;
    using COMPANY.Domain.Enums.Authentification;
    using COMPANY.Helpers;
    using Inova.AutoInjection.Attributes;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Inject(typeof(ICurrentUserService), ServiceLifetime.Scoped)]
    public class CurrentUserService : ICurrentUserService
    {
        private UserTokenInformation _loggedInUserInfo;
        private Role _userRole;
        private readonly HttpContext _httpContext;
        private readonly IDataAccess<Role, int> _roleDataAccess;
        private readonly IDataAccess<User, string> _accountDataAccess;

        public CurrentUserService(
            IHttpContextAccessor httpContextAccessor,
            IUnitOfWork unitOfWork)
        {
            _httpContext = httpContextAccessor.HttpContext;
            _roleDataAccess = unitOfWork.DataAccess<Role, int>();
            _accountDataAccess = unitOfWork.DataAccess<User, string>();
        }

        public UserTokenInformation User
        {
            get
            {
                if (_loggedInUserInfo is null)
                    _loggedInUserInfo = GetLoggedInUserInfo();

                return _loggedInUserInfo;
            }
        }

        public bool IsAuthenticated => _httpContext?.User?.Identity?.IsAuthenticated ?? false;

        public bool IsAdmin => User.RoleId == UserRole.Admin;

        public bool IsDirecteur => User.RoleId == UserRole.Directeur;

        public bool IsTechnicien => User.RoleId == UserRole.Technicien;

        public bool IsCommercial => User.RoleId == UserRole.Commercial;

        public bool IsAgence => User.RoleId == UserRole.AdminAgence;

        public bool IsFollowAgence => User.AgenceId.IsValid();

        public async Task<User> GetUserAsync()
            => await _accountDataAccess.GetAsync(User.Id);

        public string GetUserIPAddress()
            => _httpContext.Connection.RemoteIpAddress.ToString();

        public IEnumerable<PermissionModel> GetUserPermissions()
            => User.Permissions;

        public async Task<Role> GetUserRoleAsync()
        {
            if (_userRole is null)
                _userRole = await _roleDataAccess.GetAsync((int)User.RoleId);

            return _userRole;
        }

        public bool HasPermission(params PermissionModel[] permissions)
            => User.Permissions.Intersect(permissions).Count() == permissions.Length;

        private UserTokenInformation GetLoggedInUserInfo()
        {
            if (_httpContext is null)
                return null;

            if (!IsAuthenticated)
                return null;

            var user = new UserTokenInformation()
            {
                Id = "",
                AgenceId = null,
                RoleId = 0,
                IsActive = false,
                Email = _httpContext.User.FindFirst(ClaimsTypes.Email)?.Value,
                Username = _httpContext.User.FindFirst(ClaimsTypes.Name)?.Value,
                RoleName = _httpContext.User.FindFirst(ClaimsTypes.Role)?.Value,
                Name = _httpContext.User.FindFirst(ClaimsTypes.Name)?.Value,
                Modules = _httpContext.User.FindFirst(ClaimsTypes.Modules)?.Value.FromJson<ICollection<string>>(),
                Permissions = _httpContext.User.FindFirst(ClaimsTypes.Permissions)?.Value.FromJson<ICollection<PermissionModel>>(),
            };

            if (Enum.TryParse(_httpContext.User.FindFirst(ClaimsTypes.RoleId)?.Value, true, out UserRole role))
                user.RoleId = role;

            if (_httpContext.User.FindFirst(ClaimsTypes.UserId).Value.IsValid())
                user.Id = _httpContext.User.FindFirst(ClaimsTypes.UserId).Value;

            if (_httpContext.User.FindFirst(ClaimsTypes.AgenceId).Value.IsValid())
                user.AgenceId = _httpContext.User.FindFirst(ClaimsTypes.AgenceId).Value;

            if (bool.TryParse(_httpContext.User.FindFirst(ClaimsTypes.IsActive)?.Value, out bool isActive))
                user.IsActive = isActive;

            return user;
        }
    }
}
