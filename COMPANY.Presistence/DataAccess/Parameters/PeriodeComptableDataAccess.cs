namespace COMPANY.Presistence.DataAccess
{
    using COMPANY.Application.DataInteraction.DataAccess;
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Exceptions;
    using COMPANY.Domain.Entities;
    using COMPANY.Presistence.DataAccess.Base;
    using COMPANY.Presistence.DataContext;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// a class that implement <see cref="IPeriodeComptableDataAccess"/>
    /// to describe the data access layer for the <see cref="PeriodeComptable"/> entity
    /// </summary>
    public class PeriodeComptableDataAccess : DataAccess<PeriodeComptable, string>, IPeriodeComptableDataAccess
    {
        public PeriodeComptableDataAccess(IDataSource context, ILoggerFactory logger) : base(context, logger)
        { }

        /// <summary>
        /// get the periode comptable with the given id
        /// </summary>
        /// <param name="agenceId">the id of agence</param>
        /// <returns>the accounting period</returns>
        public async Task<PeriodeComptable> GetCurrentPeriodeComptableAsync(string agenceId)
        {
            var result = await Get().OrderByDescending(e => e.DateDebut)
                                    .Where(e => !e.DateCloture.HasValue && e.AgenceId == agenceId)
                                    .SingleOrDefaultAsync();

            if (result is null)
                throw new NotFoundException($"Failed Retrieving the accounting period, there is no periode comptable with the given agence id: {agenceId}");

            return result;
        }

        /// <summary>
        /// cloture comptable
        /// </summary>
        /// <param name="dateStart">the date start of accounting period</param>
        /// <param name="dateEnd">the date end of accounting period</param>
        /// <param name="agenceId">the agence id who has this period</param>
        /// <returns>a boolean result</returns>
        public async Task<Result<bool>> ClotureComptable(DateTime dateStart, DateTime dateEnd, string agenceId)
        {
            try
            {
                var result = await _context.ClotureComptable(dateStart, dateEnd, agenceId);
                return Result<bool>.Success(true);
            }
            catch (Exception ex)
            {
                throw new NotFoundException($"Failed Retrieving execute ClotureComptable stored procedure, an exception has been thrown", ex);
            }
        }
    }
}
