namespace COMPANY.Application.DataInteraction.DataAccess
{
    using COMPANY.Application.DataInteraction.DataAccess.Base;
    using COMPANY.Domain.Entities;
    using System.Threading.Tasks;

    public interface IConfigMessagerieDataAccess : IDataAccess<ConfigMessagerie, string>
    {
        /// <summary>
        /// get configuration messagerie by agence id
        /// </summary>
        /// <param name="agenceId"> the agence id </param>
        /// <returns>a instance of document parameter</returns>
        Task<ConfigMessagerie> GetConfigMessagerieByAgenceIdAsync(string agenceId);
    }
}
