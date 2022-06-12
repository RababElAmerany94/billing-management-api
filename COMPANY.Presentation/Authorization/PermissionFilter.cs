namespace COMPANY.Presentation.Authorization
{
    using COMPANY.Application.Models.AccountManagement.Permission;
    using COMPANY.Common.Constants;
    using COMPANY.Domain.Enums.Authentification;
    using COMPANY.Helpers;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Controllers;
    using Microsoft.AspNetCore.Mvc.Filters;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class PermissionFilter : IAuthorizationFilter
    {
        readonly Access _access;

        public PermissionFilter(Access access)
            => _access = access;

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var modulesIds = new List<string>();

            if (context.ActionDescriptor is ControllerActionDescriptor controllerActionDescriptor)
            {
                var modulesAttributes = controllerActionDescriptor.ControllerTypeInfo.GetCustomAttributes<ModuleAttribute>();
                modulesIds = modulesAttributes.Select(e => e.Module).ToList();
            }

            var hasClaim = context
                .HttpContext
                .User
                .Claims
                .Any(c =>
                    c.Type == ClaimsTypes.Permissions &&
                    c.Value.FromJson<List<PermissionModel>>().Any(p => p.Access == _access && p.Modules.Any(m => modulesIds.Contains(m.ModuleId)))
                );

            if (!hasClaim)
                context.Result = new ForbidResult();
        }
    }
}
