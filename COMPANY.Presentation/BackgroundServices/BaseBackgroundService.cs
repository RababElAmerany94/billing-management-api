namespace COMPANY.BackgroundServices
{
    using Coravel.Invocable;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// the base Background Service
    /// </summary>
    public abstract class BaseBackgroundService : IInvocable
    {
        /// <summary>
        /// the services provider
        /// </summary>
        protected readonly IServiceProvider _services;

        /// <summary>
        /// create an instant of <see cref="BaseBackgroundService"/>
        /// </summary>
        /// <param name="services">the service provider</param>
        protected BaseBackgroundService(IServiceProvider services)
        {
            _services = services;
        }

        /// <summary>
        /// invoice the background service logic, this function will only call <see cref="ExecuteAsync"/>
        /// so make sure all your logic is set in that function
        /// </summary>
        public Task Invoke() => ExecuteAsync();

        /// <summary>
        /// Execute the back ground task
        /// </summary>
        public void Execute() => ExecuteAsync().GetAwaiter().GetResult();

        /// <summary>
        /// Execute the back ground task
        /// </summary>
        public abstract Task ExecuteAsync();

    }
}
