namespace Microsoft.AspNetCore.Authentication.InovaSquadAuth
{
    using Microsoft.Extensions.Options;
    using System;

    public class InovaSquadPostConfigureOptions : IPostConfigureOptions<InovaSquadAuthOptions>
    {
        /// <summary>
        /// Invoked to configure a TOptions instance.
        /// </summary>
        /// <param name="name">The name of the options instance being configured.</param>
        /// <param name="options">The options instance to configured.</param>
        public void PostConfigure(string name, InovaSquadAuthOptions options)
        {
            if (options is null)
                throw new InvalidOperationException("options object is null");

            //if (string.IsNullOrEmpty(options.))
            //    throw new InvalidOperationException("SecurityKey must be provided in options");

            //if (string.IsNullOrEmpty(options.SecurityAlgorithm))
            //    throw new InvalidOperationException("Security Algorithm must be provided in options");
        }
    }
}
