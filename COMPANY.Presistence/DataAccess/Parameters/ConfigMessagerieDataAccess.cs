namespace COMPANY.Presistence.DataAccess
{
    using COMPANY.Application.DataInteraction.DataAccess;
    using COMPANY.Application.Exceptions;
    using COMPANY.Common.Constants;
    using COMPANY.Common.Helpers;
    using COMPANY.Domain.Entities;
    using COMPANY.Presistence.DataAccess.Base;
    using COMPANY.Presistence.DataContext;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using System.Threading.Tasks;

    public class ConfigMessagerieDataAccess : DataAccess<ConfigMessagerie, string>, IConfigMessagerieDataAccess
    {
        public ConfigMessagerieDataAccess(IDataSource context, ILoggerFactory resultBuilder)
            : base(context, resultBuilder) { }

        /// <summary>
        /// get configuration messagerie by agence id
        /// </summary>
        /// <param name="agenceId"> the agence id </param>
        /// <returns>a instance of document parameter</returns>
        public async Task<ConfigMessagerie> GetConfigMessagerieByAgenceIdAsync(string agenceId)
        {
            var result = await Get()
                .SingleOrDefaultAsync(c => (agenceId.IsValid() ? c.AgenceId == agenceId : !c.AgenceId.IsValid()));

            if (result is null)
                throw new NotFoundException($"Failed Retrieving the config messagerie, there is no config messagerie with the given agence id: {agenceId}", MsgCode.NoConfigMessagerie);

            return result;
        }
    }
}
