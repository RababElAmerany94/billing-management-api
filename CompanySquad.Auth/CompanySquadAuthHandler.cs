﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;

namespace Microsoft.AspNetCore.Authentication.CompanySquadAuth
{
    public class CompanySquadAuthHandler : SignInAuthenticationHandler<CompanySquadAuthOptions>
    {
        public CompanySquadAuthHandler(
            IOptionsMonitor<CompanySquadAuthOptions> options, 
            ILoggerFactory logger, UrlEncoder encoder, 
            ISystemClock clock)
            : base(options, logger, encoder, clock)
        { }

        /// <summary>
        /// The handler calls methods on the events which give the application control at certain points where processing is occurring. 
        /// If it is not provided a default instance is supplied which does nothing when the methods are called.
        /// </summary>
        protected new CompanySquadAuthEvents Events
        {
            get => (CompanySquadAuthEvents)base.Events;
            set => base.Events = value;
        }

        protected override Task<object> CreateEventsAsync() => Task.FromResult<object>(new CompanySquadAuthEvents());

        /// <summary>
        /// Searches the 'Authorization' header for a 'Bearer' token. If the 'Bearer' token is found, it is validated using <see cref="TokenValidationParameters"/> set in the options.
        /// </summary>
        /// <returns></returns>
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            string token = null;
            try
            {
                // Give application opportunity to find from a different location, adjust, or reject token
                var messageReceivedContext = new MessageReceivedContext(Context, Scheme, Options);

                // event can set the token
                await Events.MessageReceived(messageReceivedContext);
                if (messageReceivedContext.Result != null)
                {
                    return messageReceivedContext.Result;
                }

                // If application retrieved token from somewhere else, use that.
                token = messageReceivedContext.Token;

                if (string.IsNullOrEmpty(token))
                {
                    string authorization = Request.Headers[HeaderNames.Authorization];

                    // If no authorization header found, nothing to process further
                    if (string.IsNullOrEmpty(authorization))
                    {
                        return AuthenticateResult.NoResult();
                    }

                    if (authorization.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                    {
                        token = authorization.Substring("Bearer ".Length).Trim();
                    }

                    // If no token found, no further work possible
                    if (string.IsNullOrEmpty(token))
                    {
                        return AuthenticateResult.NoResult();
                    }
                }

                List<Exception> validationFailures = null;
                SecurityToken validatedToken = null;

                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    IssuerSigningKey = Options.IssuerSigningKey,
                    ValidIssuer = Options.ClaimsIssuer,
                    ValidAudience = Options.Audience,
                    ClockSkew = TimeSpan.Zero
                };

                var validator = new JwtSecurityTokenHandler();

                if (validator.CanReadToken(token))
                {
                    ClaimsPrincipal principal = null;

                    try
                    {
                        principal = validator.ValidateToken(token, validationParameters, out validatedToken);
                    }
                    catch (Exception ex)
                    {
                        Logger.TokenValidationFailed(ex);

                        if (validationFailures == null)
                        {
                            validationFailures = new List<Exception>(1);
                        }
                        validationFailures.Add(ex);
                    }

                    if (validationFailures is null || validationFailures.Count <= 0)
                    {
                        Logger.TokenValidationSucceeded();

                        var tokenValidatedContext = new TokenValidatedContext(Context, Scheme, Options)
                        {
                            Principal = principal,
                            SecurityToken = validatedToken
                        };

                        await Events.TokenValidated(tokenValidatedContext);
                        if (tokenValidatedContext.Result != null)
                        {
                            return tokenValidatedContext.Result;
                        }

                        if (Options.SaveToken)
                        {
                            tokenValidatedContext.Properties.StoreTokens(new[]
                            {
                                new AuthenticationToken { Name = "access_token", Value = token }
                            });
                        }

                        tokenValidatedContext.Success();
                        return tokenValidatedContext.Result; 
                    }
                }

                if (validationFailures != null)
                {
                    var authenticationFailedContext = new AuthenticationFailedContext(Context, Scheme, Options)
                    {
                        Exception = (validationFailures.Count == 1) ? validationFailures[0] : new AggregateException(validationFailures)
                    };

                    await Events.AuthenticationFailed(authenticationFailedContext);
                    if (authenticationFailedContext.Result != null)
                    {
                        return authenticationFailedContext.Result;
                    }

                    return AuthenticateResult.Fail(authenticationFailedContext.Exception);
                }

                return AuthenticateResult.Fail("No SecurityTokenValidator available for token: " + token ?? "[null]");
            }
            catch (Exception ex)
            {
                Logger.ErrorProcessingMessage(ex);

                var authenticationFailedContext = new AuthenticationFailedContext(Context, Scheme, Options)
                {
                    Exception = ex
                };

                await Events.AuthenticationFailed(authenticationFailedContext);
                if (authenticationFailedContext.Result != null)
                {
                    return authenticationFailedContext.Result;
                }

                throw;
            }
        }

        protected override async Task HandleChallengeAsync(AuthenticationProperties properties)
        {
            var authResult = await HandleAuthenticateOnceSafeAsync();
            var eventContext = new CompanySquadChallengeContext(Context, Scheme, Options, properties)
            {
                AuthenticateFailure = authResult?.Failure
            };

            // Avoid returning error=invalid_token if the error is not caused by an authentication failure (e.g missing token).
            if (Options.IncludeErrorDetails && eventContext.AuthenticateFailure != null)
            {
                eventContext.Error = "invalid_token";
                eventContext.ErrorDescription = CreateErrorDescription(eventContext.AuthenticateFailure);
            }

            await Events.Challenge(eventContext);
            if (eventContext.Handled)
            {
                return;
            }

            Response.StatusCode = 401;

            if (string.IsNullOrEmpty(eventContext.Error) &&
                string.IsNullOrEmpty(eventContext.ErrorDescription) &&
                string.IsNullOrEmpty(eventContext.ErrorUri))
            {
                Response.Headers.Append(HeaderNames.WWWAuthenticate, Options.Challenge);
            }
            else
            {
                // https://tools.ietf.org/html/rfc6750#section-3.1
                // WWW-Authenticate: Bearer realm="example", error="invalid_token", error_description="The access token expired"
                var builder = new StringBuilder(Options.Challenge);
                if (Options.Challenge.IndexOf(' ') > 0)
                {
                    // Only add a comma after the first param, if any
                    builder.Append(',');
                }
                if (!string.IsNullOrEmpty(eventContext.Error))
                {
                    builder.Append(" error=\"");
                    builder.Append(eventContext.Error);
                    builder.Append("\"");
                }
                if (!string.IsNullOrEmpty(eventContext.ErrorDescription))
                {
                    if (!string.IsNullOrEmpty(eventContext.Error))
                    {
                        builder.Append(",");
                    }

                    builder.Append(" error_description=\"");
                    builder.Append(eventContext.ErrorDescription);
                    builder.Append('\"');
                }
                if (!string.IsNullOrEmpty(eventContext.ErrorUri))
                {
                    if (!string.IsNullOrEmpty(eventContext.Error) ||
                        !string.IsNullOrEmpty(eventContext.ErrorDescription))
                    {
                        builder.Append(",");
                    }

                    builder.Append(" error_uri=\"");
                    builder.Append(eventContext.ErrorUri);
                    builder.Append('\"');
                }

                Response.Headers.Append(HeaderNames.WWWAuthenticate, builder.ToString());
            }
        }

        private static string CreateErrorDescription(Exception authFailure)
        {
            IEnumerable<Exception> exceptions;
            if (authFailure is AggregateException agEx)
            {
                exceptions = agEx.InnerExceptions;
            }
            else
            {
                exceptions = new[] { authFailure };
            }

            var messages = new List<string>();

            foreach (var ex in exceptions)
            {
                // Order sensitive, some of these exceptions derive from others
                // and we want to display the most specific message possible.
                switch (ex)
                {
                    case SecurityTokenInvalidAudienceException stia:
                        messages.Add($"The audience '{stia.InvalidAudience ?? "(null)"}' is invalid");
                        break;
                    case SecurityTokenInvalidIssuerException stii:
                        messages.Add($"The issuer '{stii.InvalidIssuer ?? "(null)"}' is invalid");
                        break;
                    case SecurityTokenNoExpirationException _:
                        messages.Add("The token has no expiration");
                        break;
                    case SecurityTokenInvalidLifetimeException stil:
                        messages.Add("The token lifetime is invalid; NotBefore: "
                            + $"'{stil.NotBefore?.ToString(CultureInfo.InvariantCulture) ?? "(null)"}'"
                            + $", Expires: '{stil.Expires?.ToString(CultureInfo.InvariantCulture) ?? "(null)"}'");
                        break;
                    case SecurityTokenNotYetValidException stnyv:
                        messages.Add($"The token is not valid before '{stnyv.NotBefore.ToString(CultureInfo.InvariantCulture)}'");
                        break;
                    case SecurityTokenExpiredException ste:
                        messages.Add($"The token expired at '{ste.Expires.ToString(CultureInfo.InvariantCulture)}'");
                        break;
                    case SecurityTokenSignatureKeyNotFoundException _:
                        messages.Add("The signature key was not found");
                        break;
                    case SecurityTokenInvalidSignatureException _:
                        messages.Add("The signature is invalid");
                        break;
                }
            }

            return string.Join("; ", messages);
        }

        protected override async Task HandleSignInAsync(ClaimsPrincipal user, AuthenticationProperties properties)
        {
            var now = DateTime.UtcNow;

            var signInCredentials = new SigningCredentials(Options.IssuerSigningKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>(user.Claims)
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.FindFirst(ClaimTypes.Name).Value),
                new Claim(JwtRegisteredClaimNames.Jti, await Options.NonceGenerator()),
                new Claim(JwtRegisteredClaimNames.Iat, new DateTimeOffset(now).ToUniversalTime().ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
            };

            // Create the JWT and write it to a string
            var jwt = new JwtSecurityToken(
                issuer: Options.ClaimsIssuer,
                audience: Options.Audience,
                claims: claims,
                notBefore: now,
                expires: now.AddMinutes(Options.Expiration),
                signingCredentials: signInCredentials);
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            Request.HttpContext.User.AddIdentities(user.Identities);
            Request.HttpContext.User.AddIdentities(new ClaimsIdentity[]
            {
                new ClaimsIdentity(new Claim[]{ new Claim("token", encodedJwt) })
            });
        }

        protected override Task HandleSignOutAsync(AuthenticationProperties properties)
        {
            return Task.Delay(1);
        }
    }
}