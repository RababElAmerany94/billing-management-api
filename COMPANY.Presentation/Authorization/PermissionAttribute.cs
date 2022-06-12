namespace COMPANY.Presentation.Authorization
{
    using COMPANY.Domain.Enums.Authentification;
    using Microsoft.AspNetCore.Mvc;

    public class PermissionAttribute : TypeFilterAttribute
    {
        public PermissionAttribute(Access access) : base(typeof(PermissionFilter))
        {
            Arguments = new object[] { access };
        }
    }
}
