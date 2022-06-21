namespace Microsoft.AspNetCore.Authentication.InovaSquadAuth
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.IdentityModel.Tokens;

    public class TokenValidatedContext : ResultContext<InovaSquadAuthOptions>
    {
        public TokenValidatedContext(
            HttpContext context,
            AuthenticationScheme scheme,
            InovaSquadAuthOptions options)
            : base(context, scheme, options) { }

        public SecurityToken SecurityToken { get; set; }
    }
}