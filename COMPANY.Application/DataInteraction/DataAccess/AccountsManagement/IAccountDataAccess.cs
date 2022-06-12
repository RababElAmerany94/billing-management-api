namespace COMPANY.Application.Data
{
    using COMPANY.Application.DataInteraction.DataAccess.Base;
    using COMPANY.Application.Models.BusinessEntitiesModels.AccountModels;
    using COMPANY.Application.Models.General.FilterOptions;
    using COMPANY.Presistence.Implementations;
    using Domain.Entities;
    using System.Threading.Tasks;

    /// <summary>
    /// an interface that defines the dataAccess Layer for the User
    /// </summary>
    public interface IAccountDataAccess : IDataAccess<User, string>
    {
        /// <summary>
        /// get a single user that match the given request
        /// </summary>
        /// <remarks>the Roles are already included, so you don't have to add includes for it in your data request</remarks>
        /// <param name="dataRequest"></param>
        /// <returns>the user</returns>
        Task<User> GetUserAsync(IDataRequest<User> dataRequest);

        /// <summary>
        /// get the user with the given id
        /// </summary>
        /// <param name="id">the id of the user to be retrieved</param>
        /// <returns>the user</returns>
        Task<User> GetUserByIdAsync(string id);

        /// <summary>
        /// check if the given userName exist
        /// </summary>
        /// <param name="userName">the userName to check</param>
        /// <returns>true if exist, false if not</returns>
        Task<bool> IsUserNameExistAsnc(string userName);

        /// <summary>
        /// get the user with the given userName
        /// </summary>
        /// <param name="userName">the userName that the user should own</param>
        /// <returns>the user</returns>
        Task<User> GetUserByUserNameAsync(string userName);

        /// <summary>
        /// Get list commercials planning as paged result
        /// </summary>
        /// <param name="filterOption">the filter option model</param>
        /// <param name="request">the request filter</param>
        /// <returns>a result as paged list</returns>
        Task<PagedResult<CommercialPlanningModel>> GetTechniciensPlanningAsPagedResultAsync(CommercialsPlanningFilterOption filterOption, IDataRequest<User> request);
    }
}
