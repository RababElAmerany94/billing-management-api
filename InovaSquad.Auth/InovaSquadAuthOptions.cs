namespace Microsoft.AspNetCore.Authentication.InovaSquadAuth
{
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    /// <summary>
    /// Options class provides information needed to control Bearer Authentication handler behavior
    /// </summary>
    public class InovaSquadAuthOptions : AuthenticationSchemeOptions
    {
        /// <summary>
        /// Gets or sets the Microsoft.IdentityModel.Tokens.SecurityKey that is to be used
        /// for signature validation.
        /// </summary>
        public SecurityKey IssuerSigningKey { get; set; }

        /// <summary>
        /// Gets or sets if HTTPS is required for the meta data address or authority.
        /// The default is true. This should be disabled only in development environments.
        /// </summary>
        public bool RequireHttpsMetadata { get; set; } = true;

        /// <summary>
        /// Gets or sets the discovery endpoint for obtaining meta data
        /// </summary>
        public string MetadataAddress { get; set; }

        /// <summary>
        /// Gets or sets the Authority to use when making OpenIdConnect calls.
        /// </summary>
        public string Authority { get; set; }

        /// <summary>
        /// the expiration in minutes
        /// </summary>
        public int Expiration { get; set; } = 7200;

        /// <summary>
        /// Gets or sets a single valid audience value for any received OpenIdConnect token.
        /// This value is passed into TokenValidationParameters.ValidAudience if that property is empty.
        /// </summary>
        /// <value>
        /// The expected audience for any received OpenIdConnect token.
        /// </value>
        public string Audience { get; set; } = "InovaSquad.com";

        /// <summary>
        /// Gets or sets the challenge to put in the "WWW-Authenticate" header.
        /// </summary>
        public string Challenge { get; set; } = InovaSquadAuthDefaults.AuthenticationScheme;

        /// <summary>
        /// The object provided by the application to process events raised by the bearer authentication handler.
        /// The application may implement the interface fully, or it may create an instance of JwtBearerEvents
        /// and assign delegates only to the events it wants to process.
        /// </summary>
        public new InovaSquadAuthEvents Events
        {
            get { return (InovaSquadAuthEvents)base.Events; }
            set { base.Events = value; }
        }

        ///// <summary>
        ///// Configuration provided directly by the developer. If provided, then MetadataAddress and the Backchannel properties
        ///// will not be used. This information should not be updated during request processing.
        ///// </summary>
        //public OpenIdConnectConfiguration Configuration { get; set; }

        ///// <summary>
        ///// Responsible for retrieving, caching, and refreshing the configuration from metadata.
        ///// If not provided, then one will be created using the MetadataAddress and Backchannel properties.
        ///// </summary>
        //public IConfigurationManager<OpenIdConnectConfiguration> ConfigurationManager { get; set; }

        /// <summary>
        /// The HttpMessageHandler used to retrieve meta data.
        /// This cannot be set at the same time as BackchannelCertificateValidator unless the value
        /// is a WebRequestHandler.
        /// </summary>
        public HttpMessageHandler BackchannelHttpHandler { get; set; }

        /// <summary>
        /// Gets or sets the timeout when using the back channel to make an HTTP call.
        /// </summary>
        public TimeSpan BackchannelTimeout { get; set; } = TimeSpan.FromMinutes(1);

        /// <summary>
        /// Gets or sets if a meta data refresh should be attempted after a SecurityTokenSignatureKeyNotFoundException. This allows for automatic
        /// recovery in the event of a signature key rollover. This is enabled by default.
        /// </summary>
        public bool RefreshOnIssuerKeyNotFound { get; set; } = true;

        /// <summary>
        /// Gets the ordered list of <see cref="ISecurityTokenValidator"/> used to validate access tokens.
        /// </summary>
        //public IList<ISecurityTokenValidator> SecurityTokenValidators { get; } = new List<ISecurityTokenValidator> { new JwtSecurityTokenHandler() };

        /// <summary>
        /// Gets or sets the parameters used to validate identity tokens.
        /// </summary>
        /// <remarks>Contains the types and definitions required for validating a token.</remarks>
        /// <exception cref="ArgumentNullException">if 'value' is null.</exception>
        public TokenValidationParameters TokenValidationParameters { get; set; } = new TokenValidationParameters();

        /// <summary>
        /// Defines whether the bearer token should be stored in the
        /// <see cref="AuthenticationProperties"/> after a successful authorization.
        /// </summary>
        public bool SaveToken { get; set; } = true;

        /// <summary>
        /// Defines whether the token validation errors should be returned to the caller.
        /// Enabled by default, this option can be disabled to prevent the JWT handler
        /// from returning an error and an error_description in the WWW-Authenticate header.
        /// </summary>
        public bool IncludeErrorDetails { get; set; } = true;

        /// <summary>
        /// Generates a random value (nonce) for each generated token.
        /// </summary>
        /// <remarks>The default nonce is a random GUID.</remarks>
        public Func<Task<string>> NonceGenerator { get; set; }
            = () => Task.FromResult(Guid.NewGuid().ToString());
    }
}