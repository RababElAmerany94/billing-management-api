namespace COMPANY.BackgroundServices
{
    using COMPANY.Domain.Enums;
    using COMPANY.Presentation;
    using COMPANY.Presistence.DataContext;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// this service will handle update facture status when deadline completed
    /// </summary>
    public partial class FactureEnRetardService
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
                        // get list factures 
                        var factures = await _context
                            .Factures
                            .Where(e => e.DateEcheance.Date < DateTime.Now.Date && e.Status == FactureStatus.Encours)
                            .ToListAsync();

                        // change status
                        for (int i = 0; i < factures.Count(); i++)
                            factures[i].Status = FactureStatus.Enretard;

                        // save changes
                        _context.Factures.UpdateRange(factures);
                        await _context.SaveChangesAsync();
                    }
                    catch (Exception exception)
                    {
                        _logger.LogError("error to handle update facture status when deadline completed", exception);
                    }
                }
            }
        }
    }

    /// <summary>
    /// partial part for <see cref="FactureEnRetardService"/>
    /// </summary>
    public partial class FactureEnRetardService : BaseBackgroundService
    {
        private readonly ILogger<FactureEnRetardService> _logger;

        /// <summary>
        /// create an instant of <see cref="FactureEnRetardService"/>
        /// </summary>
        /// <param name="services">the <see cref="IServiceProvider"/> instant</param>
        /// <param name="logger"></param>
        public FactureEnRetardService(
            IServiceProvider services,
            ILogger<FactureEnRetardService> logger)
            : base(services)
        {
            _logger = logger;
        }
    }
}
