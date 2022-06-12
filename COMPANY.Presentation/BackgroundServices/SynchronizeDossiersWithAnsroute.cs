namespace COMPANY.Presentation.BackgroundServices
{
    using COMPANY.Application.Services.DataService.DossierService;
    using COMPANY.BackgroundServices;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Threading.Tasks;

    public partial class SynchronizeDossiersWithAnsroute
    {
        public override async Task ExecuteAsync()
        {
            using (var scope = _services.CreateScope())
            {
                try
                {
                    var dossierService = scope.GetService<IDossierService>();
                    await dossierService.SynchronizeWithAntsroute();
                }
                catch (Exception exception)
                {
                    _logger.LogError("error occurred when synchronize with antsroute", exception);
                }
            }
        }
    }

    /// <summary>
    /// partial part for <see cref="SynchronizeDossiersWithAnsroute"/>
    /// </summary>
    public partial class SynchronizeDossiersWithAnsroute : BaseBackgroundService
    {
        private readonly ILogger<SynchronizeDossiersWithAnsroute> _logger;

        /// <summary>
        /// create an instant of <see cref="SynchronizeDossiersWithAnsroute"/>
        /// </summary>
        /// <param name="services">the <see cref="IServiceProvider"/> instant</param>
        /// <param name="logger"></param>
        public SynchronizeDossiersWithAnsroute(
            IServiceProvider services,
            ILogger<SynchronizeDossiersWithAnsroute> logger) : base(services)
        {
            _logger = logger;
        }
    }
}
