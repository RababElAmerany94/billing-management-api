namespace COMPANY.Presentation
{
    using Application.Services.AuthService;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.InovaSquadAuth;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;
    using System.Text;

    /// <summary>
    /// this class is used o configure Authentication
    /// </summary>
    public static class AuthExtentions
    {
        /// <summary>
        /// add Authentication to the project
        /// </summary>
        /// <param name="services">the DI Collection service</param>
        /// <param name="configuration"></param>
        internal static void AddAuth(this IServiceCollection services, IConfiguration configuration)
        {
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration.GetSection("TokenAuthentication:SecretKey").Value));

            services
                .AddAuthentication(InovaSquadAuthDefaults.AuthenticationScheme)
                .AddInovaSquadAuth(options =>
                {
                    options.IssuerSigningKey = signingKey;
                    options.Audience = configuration.GetSection("TokenAuthentication:Audience").Value;
                    options.ClaimsIssuer = configuration.GetSection("TokenAuthentication:Issuer").Value;
                });

            services.AddAuthorization();
        }
    }
}
