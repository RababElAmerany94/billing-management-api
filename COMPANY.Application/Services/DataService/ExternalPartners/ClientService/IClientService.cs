namespace COMPANY.Application.Services.DataService
{
    using Application.Models;
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Models.BusinessEntities.General;
    using COMPANY.Application.Models.BusinessEntitiesModels.AddressModel;
    using COMPANY.Domain.Entities.OwnedEntities;
    using Domain.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// an interface that defines a set of service endpoint 
    /// for working with <see cref="Client"/> Entity
    /// </summary>
    public interface IClientService
        : IBaseService<Client, string, ClientModel, ClientCreateModel, ClientUpdateModel>
    {

        #region client

        /// <summary>
        /// check if the given reference is unique
        /// </summary>
        /// <param name="reference">the reference to be checked</param>
        /// <returns>true if unique, false if not</returns>
        Task<Result<bool>> CheckUniqueReferenceAsync(string reference);

        /// <summary>
        /// check if the given phone is unique
        /// </summary>
        /// <param name="phone">the phone to be checked</param>
        /// <returns>true if unique, false if not</returns>
        Task<Result<bool>> CheckUniquePhoneAsync(string phone);

        /// <summary>
        /// save the given memo to the client with the given id
        /// </summary>
        /// <param name="id">the id of the client to save the memo for it</param>
        /// <param name="memos">the memo to be saved</param>
        /// <returns>a result object</returns>
        Task<Result> SaveMemosAsync(string id, ICollection<Memo> memos);

        /// <summary>
        /// export the list of client as an excel file
        /// </summary>
        /// <param name="userId">the id of the user currently logged in</param>
        /// <returns>the result instant</returns>
        Task<Result<byte[]>> ExportClientListAsExcelAsync(string userId);

        /// <summary>
        /// change genere client from prospect to client
        /// </summary>
        /// <param name="clientId">the id of client</param>
        Task ChangeGenreClientFromProspectToClient(string clientId);

        #endregion

        #region additions

        /// <summary>
        /// add new contacts to client
        /// </summary>
        /// <param name="client">the client </param>
        /// <param name="contacts">list of contact</param>
        /// <returns>list of contacts</returns>
        Result<List<Contact>> AddContactsClient(Client client, List<ContactCreateModel> contacts);

        /// <summary>
        /// add addresses client 
        /// </summary>
        /// <param name="client">the client </param>
        /// <param name="addresses">list of addresses</param>
        /// <returns>list of addresses</returns>
        Result<List<Address>> AddAddressClient(Client client, List<AddressCreateModel> addresses);

        /// <summary>
        /// update champs client as dossier
        /// </summary>
        /// <param name="client">the client </param>
        /// <param name="newValueDossier">the new value from dossier to client</param>
        /// <returns></returns>
        Result<string> EditClientChampsAsDossier(Client client, DossierCreateModel newValueDossier);

        #endregion
    }
}
