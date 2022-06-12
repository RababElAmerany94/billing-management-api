namespace COMPANY.Application.Services.DataService.ConfigMessagerieService
{
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Models.BusinessEntitiesModels.ConfigMessagerieModels;
    using System.Threading.Tasks;

    public interface IConfigMessagerieService 
    {
        /// <summary>
        /// get the ConfigMessagerie with the  given id
        /// </summary>
        /// <returns>the ConfigMessagerie result</returns>
        Task<Result<ConfigMessagerieModel>> GetConfigMessagerieAsync();

        /// <summary>
        /// create the configMessagerie with the given values
        /// </summary>
        /// <param name="createModel">the consultant model for creating new entity</param>
        /// <returns>the newly created ConfigMessagerie result</returns>
        Task<Result<ConfigMessagerieModel>> CreateConfigMessagerieAsync(ConfigMessagerieCreateModel createModel);

        /// <summary>
        /// update the config messagerie from the given model
        /// </summary>
        /// <param name="id">the id of the configMessagerie to be updated</param>
        /// <param name="updateModel">the update model</param>
        /// <returns>the update version of the config messagerie</returns>
        Task<Result<ConfigMessagerieModel>> UpdateConfigMessagerieAsync(string id, ConfigMessagerieUpdateModel updateModel);
    }
}
