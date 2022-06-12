namespace COMPANY.Infrastructure.Utilities
{
    using Microsoft.Extensions.DependencyInjection;

    public static class Extensions
    {
        /// <summary>
        /// we use this method to register all Application Core services like file service
        /// and mail service etc ...
        /// </summary>
        /// <param name="services">the DI Service collection</param>
        public static void RegiseterInfrastructureServices(this IServiceCollection services)
        { }
    }
}
