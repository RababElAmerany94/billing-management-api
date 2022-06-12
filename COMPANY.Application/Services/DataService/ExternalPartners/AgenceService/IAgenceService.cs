namespace COMPANY.Application.Services.DataService
{
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Models;
    using COMPANY.Application.Models.BusinessEntities.ExternalPartners.Agence;
    using COMPANY.Domain.Entities;
    using COMPANY.Domain.Entities.OwnedEntities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// the interface that defines a set of services for the Agence
    /// </summary>
    public interface IAgenceService
        : IBaseService<Agence, string, AgenceModel, AgenceCreateModel, AgenceUpdateModel>
    {
        /// <summary>
        /// check if the Agence with the given id is exist
        /// </summary>
        /// <param name="agenceId">the id of the agence</param>
        /// <returns>true if exist, false if not</returns>
        Task<Result<bool>> IsAgenceExistAsync(string agenceId);

        /// <summary>
        /// get the login detail of an agence
        /// </summary>
        /// <param name="idAgence">the id of the agence to retrieve the login for it</param>
        /// <returns>a user model</returns>
        Task<Result<UserModel>> GetAgenceLoginAsync(string idAgence);

        /// <summary>
        /// save the given memo to the agence with the given id
        /// </summary>
        /// <param name="id">the id of the agence to save the memo for it</param>
        /// <param name="memos">the memo to be saved</param>
        /// <returns>a result object</returns>
        Task<Result> SaveMemosAsync(string id, ICollection<Memo> memos);

        /// <summary>
        /// export the list of agences as an excel format
        /// </summary>
        /// <returns>the result object</returns>
        Task<Result<byte[]>> ExportAgencesListAsExcelAsync();

        /// <summary>
        /// change activation of agence
        /// </summary>
        /// <param name="changeActivationAgenceModel">the change visibility model</param>
        /// <returns>a activation of agence</returns>
        Task<Result<bool>> ChangeActivateAgence(ChangeActivationAgenceModel changeActivationAgenceModel);

        /// <summary>
        /// delete the login of a agence
        /// </summary>
        /// <param name="agenceId">the id of the agence to remove the login for it</param>
        /// <returns>an operation result</returns>
        Task<Result> DeleteLoginForAgenceAsync(string agenceId);

        /// <summary>
        /// create a login for the agence
        /// </summary>
        /// <param name="loginModel">the login model to create the agence login</param>
        /// <returns>an operation result</returns>
        Task<Result<UserModel>> CreateLoginForAgenceAsync(CreateLoginModel loginModel);

        /// <summary>
        /// check if the given reference is unique
        /// </summary>
        /// <param name="reference">the reference to be checked</param>
        /// <returns>true if unique, false if not</returns>
        Task<Result<bool>> CheckUniqueReferenceAsync(string reference);
    }
}
