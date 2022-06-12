namespace Microsoft.AspNetCore.Authentication.CompanySquadAuth
{
    using System;
    using CompanySquadAuth;
    using System.Threading.Tasks;

    public class CompanySquadAuthEvents
    {
        /// <summary>
        /// Invoked if exceptions are thrown during request processing. The exceptions will be re-thrown after this event unless suppressed.
        /// </summary>
        public Func<AuthenticationFailedContext, Task> OnAuthenticationFailed { get; set; } = context => Task.CompletedTask;

        /// <summary>
        /// Invoked when a protocol message is first received.
        /// </summary>
        public Func<MessageReceivedContext, Task> OnMessageReceived { get; set; } = context => Task.CompletedTask;

        /// <summary>
        /// Invoked after the security token has passed validation and a ClaimsIdentity has been generated.
        /// </summary>
        public Func<TokenValidatedContext, Task> OnTokenValidated { get; set; } = context => Task.CompletedTask;

        /// <summary>
        /// Invoked before a challenge is sent back to the caller.
        /// </summary>
        public Func<CompanySquadChallengeContext, Task> OnChallenge { get; set; } = context => Task.CompletedTask;

        public virtual Task AuthenticationFailed(AuthenticationFailedContext context) => OnAuthenticationFailed(context);

        public virtual Task MessageReceived(MessageReceivedContext context) => OnMessageReceived(context);

        public virtual Task TokenValidated(TokenValidatedContext context) => OnTokenValidated(context);

        public virtual Task Challenge(CompanySquadChallengeContext context) => OnChallenge(context);
    }
}