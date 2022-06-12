namespace COMPANY.BackgroundServices
{
    using COMPANY.Domain.Enums.Documents;
    using COMPANY.Presentation;
    using COMPANY.Presistence.DataContext;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// this service will handle get list avoirs with status en retard
    /// </summary>
    public partial class AvoirEnRetardService
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
                        var avoirs = await _context
                            .Avoirs
                            .Where(e => e.DateEcheance.Date < DateTime.Now.Date && e.Status == AvoirStatus.Encours)
                            .ToListAsync();

                        // change status avoirs to expire
                        for (int i = 0; i < avoirs.Count(); i++)
                            avoirs[i].Status = AvoirStatus.Expire;

                        _context.Avoirs.UpdateRange(avoirs);
                        await _context.SaveChangesAsync();
                    }
                    catch (Exception exception)
                    {
                        _logger.LogError("error to change status of avoir to en retard", exception);
                    }
                }
            }
        }
    }

    /// <summary>
    /// partial part for <see cref="AvoirEnRetardService"/>
    /// </summary>
    public partial class AvoirEnRetardService : BaseBackgroundService
    {
        private readonly ILogger<AvoirEnRetardService> _logger;

        /// <summary>
        /// create an instant of <see cref="AvoirEnRetardService"/>
        /// </summary>
        /// <param name="services">the <see cref="IServiceProvider"/> instant</param>
        /// <param name="logger"></param>
        public AvoirEnRetardService(
            IServiceProvider services,
            ILogger<AvoirEnRetardService> logger) : base(services)
        {
            _logger = logger;
        }
    }
}
