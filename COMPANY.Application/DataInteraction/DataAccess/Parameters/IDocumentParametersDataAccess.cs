namespace COMPANY.Application.DataInteraction.DataAccess
{
    using COMPANY.Application.Data;
    using COMPANY.Application.DataInteraction.DataAccess.Base;
    using COMPANY.Domain.Entities;
    using System.Threading.Tasks;

    /// <summary>
    /// an interface that defines the dataAccess Layer for the document parameters
    /// </summary>
    public interface IDocumentParametersDataAccess : IDataAccess<DocumentParameters, string>
    {

        /// <summary>
        /// get document parameters by agence id
        /// </summary>
        /// <param name="agenceId"> the agence id </param>
        /// <returns>a instance of document parameter</returns>
        Task<DocumentParameters> GetByAgenceIdAsync(string agenceId);

    }
}
