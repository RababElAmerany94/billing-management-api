namespace COMPANY.Application.Services.AuthService
{
    using Application.Models;
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Models.Account;
    using COMPANY.Application.Models.BusinessEntitiesModels.AccountModels;
    using COMPANY.Application.Models.General.FilterOptions;
    using COMPANY.Domain.Entities;
    using COMPANY.Domain.Entities.OwnedEntities;
    using COMPANY.Presistence.Implementations;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// the service for working with account management
    /// </summary>
    public interface IAccountService : IBaseService<User, string, UserModel, UserCreateModel, UserUpdateModel>
    {
        /// <summary>
        /// check if the given email is in use by another user
        /// </summary>
        /// <param name="email">email to validate</param>
        /// <returns>true if unique, false if not</returns>
        Task<Result<bool>> IsUserEmailUniqueAsync(string email);

        /// <summary>
        /// check if the given userName is in use by another user
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>true if unique, false if not</returns>
        Task<Result<bool>> IsUserNameUniqueAsync(string userName);

        /// <summary>
        /// update the user password
        /// </summary>
        /// <param name="userUpdatePasswordModel">a model that hold the update requirement</param>
        /// <returns>a result instant</returns>
        Task<Result> UpdateUserPassword(UserUpdatePasswordModel userUpdatePasswordModel);

        /// <summary>
        /// update the login info, the id of the user is included in the model
        /// </summary>
        /// <param name="loginModel">the login model</param>
        /// <returns></returns>
        Task<Result<UserModel>> UpdateUserLoginAsync(LoginModel loginModel);

        /// <summary>
        /// get lite information of the user with the specified id
        /// </summary>
        /// <param name="id">the id of the user</param>
        /// <returns>the userModel</returns>
        Task<Result<UserLiteModel>> GetLiteUserAsync(string id);

        /// <summary>
        /// check if the user is exist
        /// </summary>
        /// <param name="userName">the userName of the user</param>
        /// <param name="password">the password of the user</param>
        /// <returns>the founded user</returns>
        Task<Result<UserModel>> IsUserExistAsync(string userName, string password);

        /// <summary>
        /// change activation of user
        /// </summary>
        /// <param name="changeActivateUser">the change visibility model</param>
        /// <returns>a activation of user</returns>
        Task<Result<bool>> ChangeActivateUser(ChangeActivationUserModel changeActivateUser);

        /// <summary>
        /// save the given memos to the user memos list
        /// </summary>
        /// <param name="id">the id of the user to save the memo for him</param>
        /// <param name="memos">the memo to be saved</param>
        /// <returns>an operation result</returns>
        Task<Result> SaveMemosAsync(string id, ICollection<Memo> memos);

        /// <summary>
        /// check if the given matricule is unique
        /// </summary>
        /// <param name="matricule">the reference to be checked</param>
        /// <returns>true if unique, false if not</returns>
        Task<Result<bool>> CheckUniqueMatriculeAsync(string matricule);

        /// <summary>
        /// get the list of commercial planning as paged Result
        /// </summary>
        /// <param name="filterOption">the filter options</param>
        /// <returns>a paged result</returns>
        Task<PagedResult<CommercialPlanningModel>> GetCommercialsPlanningAsPagedResultAsync(CommercialsPlanningFilterOption filterOption);

        /// <summary>
        /// update Google calendar id
        /// </summary>
        /// <param name="userId">the id of user</param>
        /// <param name="calendarId">the new calendar id</param>
        /// <returns></returns>
        Task<Result> UpdateGoogleCalendarId(string userId, string calendarId);
    }
}
