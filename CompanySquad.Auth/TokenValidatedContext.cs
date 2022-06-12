namespace Microsoft.AspNetCore.Authentication.CompanySquadAuth
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.IdentityModel.Tokens;

    public class TokenValidatedContext : ResultContext<CompanySquadAuthOptions>
    {
        public TokenValidatedContext(
            HttpContext context,
            AuthenticationScheme scheme,
            CompanySquadAuthOptions options)
            : base(context, scheme, options) { }

        public SecurityToken SecurityToken { get; set; }
    }
}