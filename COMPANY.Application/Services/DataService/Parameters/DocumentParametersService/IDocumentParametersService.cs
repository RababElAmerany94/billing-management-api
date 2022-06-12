namespace COMPANY.Application.Services.DataService.DocumentParametersService
{
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Models.BusinessEntitiesModels.DocumentParametersModels;
    using System.Threading.Tasks;

    public interface IDocumentParametersService
    {
        /// <summary>
        /// get the DocumentParameters with the  given id
        /// </summary>
        /// <returns>the DocumentParameters result</returns>
        Task<Result<DocumentParametersModel>> GetDocumentParametersByIdAsync();

        /// <summary>
        /// create the DocumentParameters with the given values
        /// </summary>
        /// <param name="createModel">the consultant model for creating new entity</param>
        /// <returns>the newly created DocumentParameters result</returns>
        Task<Result<DocumentParametersModel>> CreateDocumentParametersAsync(DocumentParametersCreateModel createModel);

        /// <summary>
        /// update the DocumentParameters from the given model
        /// </summary>
        /// <param name="id">the id of the DocumentParameters to be updated</param>
        /// <param name="updateModel">the update model</param>
        /// <returns>the update version of the DocumentParameters</returns>
        Task<Result<DocumentParametersModel>> UpdateDocumentParametersAsync(string id, DocumentParametersUpdateModel updateModel);
    }
}
