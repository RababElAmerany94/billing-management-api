namespace COMPANY.Presentation.BackgroundServices
{
    using COMPANY.BackgroundServices;
    using COMPANY.Domain.Enums;
    using COMPANY.Presistence.DataContext;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public partial class DossierEnRetardService
    {
        public override async Task ExecuteAsync()
        {
            using (var scope = _services.CreateScope())
            {
                using (var _context = scope.GetService<CompanyDbContext>())
                {
                    try
                    {
                        var dossiers = await _context.Dossiers
                            .Where(e => e.DateRDV.HasValue && e.DateRDV.Value.Date < DateTime.Now.Date && e.Status == DossierStatus.Assigne)
                            .ToListAsync();

                        foreach (var dossier in dossiers)
                            dossier.Status = DossierStatus.EnRetard;

                        // save changes
                        _context.UpdateRange(dossiers);
                        await _context.SaveChangesAsync();
                    }
                    catch (Exception exception)
                    {
                        _logger.LogError("error occurred when update status of dossiers to en retard", exception);
                    }
                }
            }
        }
    }

    /// <summary>
    /// partial part for <see cref="DossierEnRetardService"/>
    /// </summary>
    public partial class DossierEnRetardService : BaseBackgroundService
    {
        private readonly ILogger<DossierEnRetardService> _logger;

        /// <summary>
        /// create an instant of <see cref="DossierEnRetardService"/>
        /// </summary>
        /// <param name="services">the <see cref="IServiceProvider"/> instant</param>
        /// <param name="logger"></param>
        public DossierEnRetardService(
            IServiceProvider services,
            ILogger<DossierEnRetardService> logger) : base(services)
        {
            _logger = logger;
        }
    }
}
