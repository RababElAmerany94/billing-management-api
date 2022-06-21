namespace Microsoft.AspNetCore.Authentication.InovaSquadAuth
{
    using Microsoft.AspNetCore.Http;
    using System;

    public class AuthenticationFailedContext : ResultContext<InovaSquadAuthOptions>
    {
        public AuthenticationFailedContext(
            HttpContext context,
            AuthenticationScheme scheme,
            InovaSquadAuthOptions options)
            : base(context, scheme, options) { }

        public Exception Exception { get; set; }
    }
}