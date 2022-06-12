namespace Microsoft.AspNetCore.Authentication.CompanySquadAuth
{
    using Microsoft.AspNetCore.Http;

    public class MessageReceivedContext : ResultContext<CompanySquadAuthOptions>
    {
        public MessageReceivedContext(
            HttpContext context,
            AuthenticationScheme scheme,
            CompanySquadAuthOptions options)
            : base(context, scheme, options) { }

        /// <summary>
        /// Bearer Token. This will give the application an opportunity to retrieve a token from an alternative location.
        /// </summary>
        public string Token { get; set; }
    }
}