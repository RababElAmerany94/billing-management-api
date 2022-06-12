namespace Microsoft.AspNetCore.Authentication.CompanySquadAuth
{
    using Microsoft.AspNetCore.Http;
    using System;

    public class AuthenticationFailedContext : ResultContext<CompanySquadAuthOptions>
    {
        public AuthenticationFailedContext(
            HttpContext context,
            AuthenticationScheme scheme,
            CompanySquadAuthOptions options)
            : base(context, scheme, options) { }

        public Exception Exception { get; set; }
    }
}