namespace COMPANY.Application.Services.DataService
{
    using Application.Data;
    using Application.Models;
    using Application.Services.FileService;
    using AutoMapper;
    using COMPANY.Application.DataInteraction.DataAccess.Base;
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Interfaces;
    using COMPANY.Application.Models.BusinessEntities.General;
    using COMPANY.Application.Models.BusinessEntities.Relations.ClientCommercial;
    using COMPANY.Application.Models.BusinessEntities.Relations.ClientRelation;
    using COMPANY.Application.Models.BusinessEntitiesModels.AddressModel;
    using COMPANY.Application.Models.GeneralModels.PagingModels;
    using COMPANY.Application.Services.DataService.NumerotationService;
    using COMPANY.Common.Helpers;
    using COMPANY.Domain.Entities;
    using COMPANY.Domain.Entities.OwnedEntities;
    using COMPANY.Domain.Entities.Relations;
    using COMPANY.Domain.Enums;
    using COMPANY.Domain.Enums.ExternalPartners;
    using Inova.AutoInjection.Attributes;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Query;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    /// <summary>
    /// the implementation of the <see cref="IClientService"/>
    /// </summary>
    [Inject(typeof(IClientService), ServiceLifetime.Scoped)]
    public class ClientService :
        BaseService<Client, string, ClientModel, ClientCreateModel, ClientUpdateModel>, IClientService
    {
        private readonly IFileService _fileService;
        private readonly ILogger<ClientService> _logger;
        private readonly INumerotationService _numerotationService;
        private readonly IDataAccess<ClientRelation, string> _clientRelationDataAccess;
        private readonly IDataAccess<ClientCommercial, string> _clientCommercialDataAccess;

        public ClientService(
            IDataRequestBuilder<Client> dataRequestBuilder,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ICurrentUserService currentUser,
            INumerotationService numerotationService,
            IFileService fileService,
            ILogger<ClientService> logger) : base(dataRequestBuilder, unitOfWork, mapper, currentUser)
        {
            _numerotationService = numerotationService;
            _fileService = fileService;
            _logger = logger;
            _clientRelationDataAccess = unitOfWork.DataAccess<ClientRelation, string>();
            _clientCommercialDataAccess = unitOfWork.DataAccess<ClientCommercial, string>();
        }

        /// <summary>
        /// check if the given reference is unique
        /// </summary>
        /// <param name="reference">the reference to be checked</param>
        /// <returns>true if unique, false if not</returns>
        public async Task<Result<bool>> CheckUniqueReferenceAsync(string reference)
        {
            var result = await _dataAccess.IsExistAsync(c => c.Reference == reference && c.AgenceId == _user.AgenceId);
            return Result<bool>.Success(!result);
        }

        /// <summary>
        /// check if the given phone is unique
        /// </summary>
        /// <param name="phone">the phone to be checked</param>
        /// <returns>true if unique, false if not</returns>
        public async Task<Result<bool>> CheckUniquePhoneAsync(string phone)
        {
            var result = await _dataAccess.IsExistAsync(c => c.PhoneNumber == phone);
            return Result<bool>.Success(!result);
        }

        /// <summary>
        /// save the given memos to the client memos list
        /// </summary>
        /// <param name="id">the id of the client to save the memo for him</param>
        /// <param name="memos">the memo to be saved</param>
        /// <returns>an operation result</returns>
        public async Task<Result> SaveMemosAsync(string id, ICollection<Memo> memos)
        {
            var result = await GetEntityByIdAsync(id);
            result.Memos = memos;
            _dataAccess.Update(result);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success("updated successfully");
        }

        /// <summary>
        /// export the list of client as an excel file
        /// </summary>
        /// <param name="loggedInUserId">the id of the current logged in user</param>
        /// <returns>the result instant</returns>
        public async Task<Result<byte[]>> ExportClientListAsExcelAsync(string loggedInUserId)
        {
            try
            {
                var clients = await GetAllAsync();
                var data = _mapper.Map<IEnumerable<ClientModel>>(clients);
                var excelFile = _fileService.GenerateClientExcelFile(data);
                return Result<byte[]>.Success(excelFile, "the file created successful");
            }
            catch (Exception ex)
            {
                return Result<byte[]>.Failed(null, ex, "Failed generating the excel file, an exception has been thrown");
            }
        }

        /// <summary>
        /// change genere client from prospect to client
        /// </summary>
        /// <param name="clientId">the id of client</param>
        public async Task ChangeGenreClientFromProspectToClient(string clientId)
        {
            if (await _dataAccess.IsExistAsync(e => e.Id == clientId && e.Genre == ClientGenre.Prospect))
            {
                var client = await GetEntityByIdAsync(clientId);
                client.Genre = ClientGenre.Client;
                _dataAccess.Update(client);
            }
        }

        /// <summary>
        /// add new contacts to client
        /// </summary>
        /// <param name="client">the client </param>
        /// <param name="contacts">the contacts to add format JSON</param>
        /// <returns>list of contacts</returns>
        public Result<List<Contact>> AddContactsClient(Client client, List<ContactCreateModel> contacts)
        {
            try
            {
                if (contacts.Any(e => e.IsNew.HasValue && e.IsNew.Value))
                {
                    var newContact = _mapper.Map<List<Contact>>(contacts.Where(e => e.IsNew.HasValue && e.IsNew.Value));
                    var contactsInDB = client.Contacts.ToList();

                    if (contactsInDB is null)
                        contactsInDB = new List<Contact>();

                    contactsInDB.AddRange(newContact);

                    client.Contacts = contactsInDB;
                    _dataAccess.Update(client);
                }

                var contactMapped = _mapper.Map<List<Contact>>(contacts);
                return Result<List<Contact>>.Success(contactMapped);
            }
            catch (Exception ex)
            {
                _logger.LogError("The error occurs when adding when we add new contact because of ([ex])", ex.Message);
                return Result<List<Contact>>.Failed(null, ex, "The error occurs when adding when we add new contact");
            }
        }

        /// <summary>
        /// add address client 
        /// </summary>
        /// <param name="client">the client </param>
        /// <param name="addresses">the addresses to add format JSON</param>
        /// <returns>list of addresses</returns>
        public Result<List<Address>> AddAddressClient(Client client, List<AddressCreateModel> addresses)
        {
            try
            {
                if (addresses.Any(e => e.IsNew.HasValue && e.IsNew.Value))
                {
                    var newAddresses = _mapper.Map<List<Address>>(addresses.Where(e => e.IsNew.HasValue && e.IsNew.Value));
                    var addressesInDB = client.Addresses.ToList();

                    if (addressesInDB is null)
                        addressesInDB = new List<Address>();

                    addressesInDB.AddRange(newAddresses);

                    client.Addresses = addressesInDB;
                    _dataAccess.Update(client);
                }

                var addressesMapped = _mapper.Map<List<Address>>(addresses);
                return Result<List<Address>>.Success(addressesMapped);
            }
            catch (Exception ex)
            {
                _logger.LogError("The error occurs when adding when we add new address because of ([ex])", ex.Message);
                return Result<List<Address>>.Failed(null, ex, "The error occurs when adding when we add new address");
            }
        }

        /// <summary>
        /// add address client 
        /// </summary>
        /// <param name="client">the client </param>
        /// <param name="newValueDossier">the new value from dossier to client</param>
        /// <returns></returns>
        public Result<string> EditClientChampsAsDossier(Client client, DossierCreateModel newValueDossier)
        {
            try
            {
                if (newValueDossier != null)
                {
                    client.IsMaisonDePlusDeDeuxAns = newValueDossier.IsMaisonDePlusDeDeuxAns;
                    client.NumeroAH = newValueDossier.NumeroAH;
                    client.LogementTypeId = newValueDossier.LogementTypeId;
                    client.PrimeCEEId = newValueDossier.PrimeCEEId;
                    client.TypeChauffageId = newValueDossier.TypeChauffageId;
                    client.TypeTravaux = newValueDossier.TypeTravaux;
                    client.SurfaceTraiter = newValueDossier.SurfaceTraiter;
                    client.SourceLeadId = newValueDossier.SourceLeadId;
                    client.RevenueFiscaleReference = newValueDossier.RevenueFiscaleReference;
                    client.Precarite = newValueDossier.Precarite;
                    client.ParcelleCadastrale = newValueDossier.ParcelleCadastrale;
                    client.NombrePersonne = newValueDossier.NombrePersonne;
                    client.DateReceptionLead = newValueDossier.DateReceptionLead;

                    _dataAccess.Update(client);
                }
                return Result<string>.Success("The Client was updated successfully)");
            }
            catch (Exception ex)
            {
                _logger.LogError("The error occurs when adding when we add new  value to client of ([ex])", ex.Message);
                return Result<string>.Failed(null, ex, "The error occurs when we add new value to client");
            }
        }

        #region private methods

        /// <summary>
        /// Remove Relation of Client
        /// </summary>
        /// <returns></returns>
        private async Task RemoveOldClientRelations(string clientId, ICollection<ClientRelationCreateModel> newRelations)
        {
            var oldRelations = await _clientRelationDataAccess.GetAsync(e => e.ClientId == clientId);
            var relationsToRemove = oldRelations.Where(e => !newRelations.Any(n => n.Id == e.Id));

            if (relationsToRemove.Any())
                _clientRelationDataAccess.DeleteRange(relationsToRemove);
        }

        /// <summary>
        /// Remove Relation of Client ommercial
        /// </summary>
        /// <returns></returns>
        private async Task RemoveOldClientCommercials(string clientId, ICollection<ClientCommercialCreateModel> newCommercials)
        {
            var oldCommercial = await _clientCommercialDataAccess.GetAsync(e => e.ClientId == clientId);
            var commercialsToRemove = oldCommercial.Where(e => !newCommercials.Any(n => n.Id == e.Id));

            if (commercialsToRemove.Any())
                _clientCommercialDataAccess.DeleteRange(commercialsToRemove);
        }

        #endregion

        #region overrides

        protected override async Task AfterAddEntity(Client entity, ClientCreateModel model)
        {
            if (model.Type == ClientType.Professionnel)
                await _numerotationService.IncrementNumerotationWithoutSaveChangesAsync(NumerotationType.ClientProfessionnel);
            else if (model.Type == ClientType.Particulier)
                await _numerotationService.IncrementNumerotationWithoutSaveChangesAsync(NumerotationType.ClientParticulier);
            else
                await _numerotationService.IncrementNumerotationWithoutSaveChangesAsync(NumerotationType.ClientObliges);
        }

        protected override async Task BeforeUpdateEntity(Client entity, ClientUpdateModel model)
        {
            await RemoveOldClientRelations(entity.Id, model.Relations);
            entity.Relations = _mapper.Map<ICollection<ClientRelation>>(model.Relations);

            await RemoveOldClientCommercials(entity.Id, model.Commercials);
            entity.Commercials = _mapper.Map<ICollection<ClientCommercial>>(model.Commercials);
        }

        protected override Func<IQueryable<Client>, IIncludableQueryable<Client, object>> BuildIncludesGetById()
            => e => e
            .Include(u => u.PrimeCEE)
            .Include(u => u.Commercials).ThenInclude(u => u.Commercial)
            .Include(u => u.Agence)
            .Include(u => u.Relations).ThenInclude(u => u.Client);

        protected override Expression<Func<Client, bool>> BuildGetListPredicate()
        {
            var predicate = PredicateBuilder.True<Client>();
            if (_user.IsFollowAgence)
                predicate.And(c => c.AgenceId == _user.AgenceId);
            else
                predicate.And(c => !c.AgenceId.IsValid());
            return predicate;
        }

        protected override Expression<Func<Client, bool>> BuildGetAsPagedPredicate<TFilter>(TFilter filterModel)
        {
            var predicate = PredicateBuilder.True<Client>();

            if (filterModel is ClientFilterOption filterOption)
            {
                if (_user.AgenceId.IsValid())
                    predicate = predicate.And(c => c.AgenceId == _user.AgenceId);

                if (filterOption.Types != null && filterOption.Types.Count() > 0)
                    predicate = predicate.And(c => filterOption.Types.Contains(c.Type));

                if (filterOption.Type.HasValue)
                    predicate = predicate.And(c => c.Type == filterOption.Type);
            }

            return predicate;
        }

        protected override Func<IQueryable<Client>, IIncludableQueryable<Client, object>> BuildIncludesList()
            => e => e.Include(a => a.Agence).Include(u => u.PrimeCEE).Include(u => u.Commercials);

        #endregion
    }
}
