namespace COMPANY.Presistence.DataAccess
{
    using COMPANY.Application.DataInteraction.DataAccess;
    using COMPANY.Application.Exceptions;
    using COMPANY.Common.Helpers;
    using COMPANY.Domain.Entities;
    using COMPANY.Domain.Enums;
    using COMPANY.Presistence.DataAccess.Base;
    using COMPANY.Presistence.DataContext;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using System.Threading.Tasks;

    /// <summary>
    /// a class that implement <see cref="INumerotationDataAccess"/>
    /// to describe the data access layer for the <see cref="Numerotation"/> entity
    /// </summary>
    public class NumerotationDataAccess : DataAccess<Numerotation, string>, INumerotationDataAccess
    {

        public NumerotationDataAccess(IDataSource context, ILoggerFactory logger) : base(context, logger) { }

        /// <summary>
        /// Get numerotation by type and agence
        /// </summary>
        /// <param name="type">the type of numerotation</param>
        /// <param name="agenceId">the id of agence</param>
        /// <returns></returns>
        public async Task<Numerotation> GetNumerotationByTypeAndAgence(NumerotationType type, string agenceId)
        {
            var result = await Get()
                     .SingleOrDefaultAsync(c => c.Type == type && (agenceId.IsValid() ? c.AgenceId == agenceId : !c.AgenceId.IsValid()));

            if (result is null)
                throw new NotFoundException($"Failed Retrieving the numeration")
;
            return result;
        }

    }
}
