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

    /// <summary>
    /// this service will handle create passages
    /// </summary>
    public partial class DevisEnRetardService
    {
        /// <summary>
        /// Execute the back ground task
        /// </summary>
        public override async Task ExecuteAsync()
        {
            using (var scope = _services.CreateScope())
            {
                using (var _context = scope.GetService<CompanyDbContext>())
                {
                    try
                    {
                        var devis = await _context
                            .Devis
                            .Where(e => e.Status == DevisStatus.Encours && e.DateVisit.Date < DateTime.Now)
                            .ToListAsync();


                        foreach (var item in devis)
                            item.Status = DevisStatus.Enretard;

                        _context.UpdateRange(devis);
                        await _context.SaveChangesAsync();
                    }
                    catch (Exception exception)
                    {
                        _logger.LogError("error to update devis", exception);
                    }
                }
            }
        }
    }

    public partial class DevisEnRetardService : BaseBackgroundService
    {
        private readonly ILogger<DevisEnRetardService> _logger;

        /// <summary>
        /// create an instant of <see cref="DevisEnRetardService"/>
        /// </summary>
        /// <param name="services">the <see cref="IServiceProvider"/> instant</param>
        /// <param name="logger"></param>
        public DevisEnRetardService(
            IServiceProvider services,
            ILogger<DevisEnRetardService> logger
        ) : base(services)
        {
            _logger = logger;
        }
    }
}
