namespace Microsoft.AspNetCore.Authentication.InovaSquadAuth
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;
    using System;
    using System.Security.Claims;

    /// <summary>
    /// add the YiSo authentication to the authenticationBuilder
    /// </summary>
    public static class InovaSquadAuthExtensions
    {
        #region AuthenticationBuilder Extensions
        /// <summary>
        /// add the AddInovaSquadAuth to AuthenticationBuilder
        /// </summary>
        /// <param name="builder">the AuthenticationBuilder</param>
        /// <returns><see cref="AuthenticationBuilder"/></returns>
        public static AuthenticationBuilder AddInovaSquadAuth(this AuthenticationBuilder builder)
            => AddInovaSquadAuth(builder, InovaSquadAuthDefaults.AuthenticationScheme, _ => { });

        /// <summary>
        /// add the AddInovaSquadAuth to AuthenticationBuilder
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="authenticationScheme"></param>
        /// <returns><see cref="AuthenticationBuilder"/></returns>
        public static AuthenticationBuilder AddInovaSquadAuth(this AuthenticationBuilder builder, string authenticationScheme)
            => AddInovaSquadAuth(builder, authenticationScheme, _ => { });

        /// <summary>
        /// add the AddInovaSquadAuth to AuthenticationBuilder
        /// </summary>
        /// <param name="builder">the AuthenticationBuilder</param>
        /// <param name="configureOptions">the YiSo Configure Options object</param>
        /// <returns><see cref="AuthenticationBuilder"/></returns>
        public static AuthenticationBuilder AddInovaSquadAuth(this AuthenticationBuilder builder, Action<InovaSquadAuthOptions> configureOptions)
            => AddInovaSquadAuth(builder, InovaSquadAuthDefaults.AuthenticationScheme, configureOptions);

        /// <summary>
        /// add the AddInovaSquadAuth to AuthenticationBuilder
        /// </summary>
        /// <param name="builder">the AuthenticationBuilder</param>
        /// <param name="authenticationScheme">the authentication Scheme name</param>
        /// <param name="configureOptions">the YiSo Configure Options object</param>
        /// <returns><see cref="AuthenticationBuilder"/></returns>
        public static AuthenticationBuilder AddInovaSquadAuth(this AuthenticationBuilder builder, string authenticationScheme, Action<InovaSquadAuthOptions> configureOptions)
        {
            builder.Services.AddSingleton<IPostConfigureOptions<InovaSquadAuthOptions>, InovaSquadPostConfigureOptions>();

            return builder.AddScheme<InovaSquadAuthOptions, InovaSquadAuthHandler>(
                authenticationScheme, configureOptions);
        }
        #endregion

        #region HttpContext Extensions

        /// <summary>
        /// Generate the Claim Principle from the given claims
        /// </summary>
        /// <param name="httpContext">the HttpContext</param>
        /// <param name="claims">the list of claims associated with the user</param>
        /// <returns><see cref="ClaimsPrincipal"/> instant</returns>
        public static ClaimsPrincipal GeneratePrinciple(this HttpContext httpContext, params Claim[] claims)
            => new ClaimsPrincipal(new ClaimsIdentity(claims));

        /// <summary>
        /// Generate the Claim Principle from the given claims
        /// </summary>
        /// <param name="httpContext">the HttpContext</param>
        /// <param name="claims">the list of claims associated with the user</param>
        /// <returns><see cref="ClaimsPrincipal"/> instant</returns>
        public static ClaimsPrincipal GeneratePrinciple(this HttpContext httpContext, string authSchem, params Claim[] claims)
            => new ClaimsPrincipal(new ClaimsIdentity(claims, authSchem));

        #endregion
    }
}

namespace Microsoft.AspNetCore.Mvc
{
    using Authentication;
    using COMPANY.Common.Helpers;
    using Http;
    using System.Security.Claims;

    public static class HTTPContextExtensions
    {
        /// <summary>
        /// try to get the id of the current logged in user, by using 'userId' as the claim name
        /// if no user is logged in an exception will be thrown
        /// </summary>
        /// <param name="httpContext">the HTTP context instant</param>
        /// <returns>the id of the user</returns>
        /// <exception cref="UserNotLoggedInExceptionException">if no user is logged in</exception>
        public static string GetUserID(this HttpContext httpContext)
        {
            var idValue = GetUserID(httpContext, "userId");

            if (string.IsNullOrEmpty(idValue))
                throw new UserNotLoggedInExceptionException();

            return idValue;
        }

        /// <summary>
        /// get the id of the user currently logged in, if no user is logged in, null will be returned
        /// </summary>
        /// <param name="httpContext">the HTTP context instant</param>
        /// <param name="claimUserIdName">the name of the user id claim</param>
        /// <returns>the id of the user as a string, or null if no value has been found</returns>
        public static string GetUserID(this HttpContext httpContext, string claimUserIdName)
            => httpContext.User.FindFirst(claimUserIdName)?.Value;

        /// <summary>
        /// try to get the id of agence of the current logged in user, by using 'agenceId' as the claim name
        /// </summary>
        /// <param name="httpContext">the HTTP context instant</param>
        /// <returns>the id of the agence for the current user or null</returns>
        public static string GetAgenceID(this HttpContext httpContext)
        {
            var idValue = GeAssociateID(httpContext, "agenceId");

            if (idValue.IsValid())
                return idValue;

            return null;
        }

        /// <summary>
        /// try to get the id of associate of the current logged in user
        /// </summary>
        /// <param name="httpContext">the HTTP context instant</param>
        /// <param name="claimAssociateIdName">the HTTP context instant</param>
        /// <returns>the id of the associate for the current user or null</returns>
        public static string GeAssociateID(this HttpContext httpContext, string claimAssociateIdName)
            => httpContext.User.FindFirst(claimAssociateIdName)?.Value;

        /// <summary>
        /// get the current logged in user role, if no role is found null will be returned;
        /// </summary>
        /// <param name="httpContext">the HTTP context instant</param>
        /// <returns>the role as string, if nothing found null will be returned</returns>
        public static string GetUserRole(this HttpContext httpContext)
            => httpContext.User.FindFirst(ClaimTypes.Role)?.Value;
    }
}
