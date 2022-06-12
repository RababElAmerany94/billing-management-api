namespace COMPANY.Presistence.DataAccess.Documents
{
    using COMPANY.Application.Data;
    using COMPANY.Application.DataInteraction.DataAccess;
    using COMPANY.Domain.Enums.Documents;
    using COMPANY.Presistence.DataAccess.Base;
    using COMPANY.Presistence.DataContext;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using System.Threading.Tasks;

    /// <summary>
    /// a class that implement <see cref="IPaiementDataAccess"/>
    /// to describe the data access layer for the <see cref="Paiement"/> entity
    /// </summary>
    public class PaiementDataAccess : DataAccess<Paiement, string>, IPaiementDataAccess
    {
        public PaiementDataAccess(IDataSource context, ILoggerFactory logger) : base(context, logger)
        { }

        /// <summary>
        /// Get total paiements with the given data request 
        /// </summary>
        /// <param name="request">the data request</param>
        /// <returns>a result object</returns>
        public async Task<decimal> GetTotalPaiementsAsync(IDataRequest<Paiement> request = null)
        {
            return await Get(request).SumAsync(e => e.Montant);
        }

    }
}
