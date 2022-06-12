namespace COMPANY.Presistence.DataAccess
{
    using COMPANY.Application.DataInteraction.DataAccess;
    using COMPANY.Application.Exceptions;
    using COMPANY.Common.Helpers;
    using COMPANY.Domain.Entities;
    using COMPANY.Presistence.DataAccess.Base;
    using COMPANY.Presistence.DataContext;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using System.Threading.Tasks;

    public class DocumentParametersDataAccess : DataAccess<DocumentParameters, string>, IDocumentParametersDataAccess
    {
        public DocumentParametersDataAccess(IDataSource context, ILoggerFactory logger) : base(context, logger)
        { }

        /// <summary>
        /// get document parameters by agence id
        /// </summary>
        /// <param name="agenceId"> the agence id </param>
        /// <returns>a instance of document parameter</returns>
        public async Task<DocumentParameters> GetByAgenceIdAsync(string agenceId)
        {

            var result = await Get().SingleOrDefaultAsync(c => (agenceId.IsValid() ? c.AgenceId == agenceId : !c.AgenceId.IsValid()));

            if (result is null)
                throw new NotFoundException($"Failed Retrieving the document parameter, there is no document parameter with the given agence id: {agenceId}");

            return result;
        }
    }

}
