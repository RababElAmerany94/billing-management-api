namespace COMPANY.Application.Services.DataService
{
    using Application.Data;
    using Application.Models;
    using Application.Services.AuthService;
    using Application.Services.FileService;
    using AutoMapper;
    using COMPANY.Application.DataInteraction.DataAccess.Base;
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Interfaces;
    using COMPANY.Application.Models.BusinessEntities.ExternalPartners.Agence;
    using COMPANY.Application.Models.BusinessEntitiesModels.NumerotationModels;
    using COMPANY.Application.Services.DataService.NumerotationService;
    using COMPANY.Common.Helpers;
    using COMPANY.Domain.Entities;
    using COMPANY.Domain.Entities.OwnedEntities;
    using COMPANY.Domain.Enums;
    using COMPANY.Domain.Enums.Authentification;
    using Inova.AutoInjection.Attributes;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Query;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// a class that implement <see cref="IAgenceService"/> 
    /// </summary>
    [Inject(typeof(IAgenceService), ServiceLifetime.Scoped)]
    public class AgenceService :
        BaseService<Agence, string, AgenceModel, AgenceCreateModel, AgenceUpdateModel>, IAgenceService
    {
        private readonly IFileService _fileService;
        private readonly IPasswordManager _passwordManager;
        private readonly INumerotationService _numerotationService;
        private readonly IDataAccess<User, string> _accountDataAccess;
        private readonly IDataAccess<BankAccount, string> _bankAccountDataAccess;

        public AgenceService(
            IDataRequestBuilder<Agence> dataRequestBuilder,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ICurrentUserService currentUser,
            INumerotationService numerotationService,
            IFileService fileService,
            IPasswordManager passwordManager) : base(dataRequestBuilder, unitOfWork, mapper, currentUser)
        {
            _numerotationService = numerotationService;
            _fileService = fileService;
            _passwordManager = passwordManager;
            _accountDataAccess = unitOfWork.DataAccess<User, string>();
            _bankAccountDataAccess = unitOfWork.DataAccess<BankAccount, string>();
        }

        /// <summary>
        /// export the list of agences as an excel format
        /// </summary>
        /// <returns>the result object</returns>
        public async Task<Result<byte[]>> ExportAgencesListAsExcelAsync()
        {
            try
            {
                var agences = await _dataAccess.GetAsync();
                var agencesModelList = _mapper.Map<IEnumerable<AgenceModel>>(agences);
                var excelFile = _fileService.GenerateAgenceExcelFile(agencesModelList);

                return Result<byte[]>.Success(excelFile, "the file create successful");
            }
            catch (Exception ex)
            {
                return Result<byte[]>.Failed(null, ex, "Failed generating the excel file, an exception has been thrown");
            }
        }

        /// <summary>
        /// check if the agence with the given id is exist
        /// </summary>
        /// <param name="agenceId">the id of the agence</param>
        /// <returns>true if agence exist, false if not</returns>
        public async Task<Result<bool>> IsAgenceExistAsync(string agenceId)
            => Result<bool>.Success(await _dataAccess.IsExistAsync(agenceId));

        /// <summary>
        /// change activation of agence
        /// </summary>
        /// <param name="changeActivationAgenceModel">the change visibility model</param>
        /// <returns>a activation of agence</returns>
        public async Task<Result<bool>> ChangeActivateAgence(ChangeActivationAgenceModel changeActivationAgenceModel)
        {
            var result = await GetEntityByIdAsync(changeActivationAgenceModel.Id);
            result.IsActive = changeActivationAgenceModel.IsActive;
            _dataAccess.Update(result);
            await _unitOfWork.SaveChangesAsync();
            return Result<bool>.Success(result.IsActive);
        }

        /// <summary>
        /// save the given memo to the Agence with the given id
        /// </summary>
        /// <param name="id">the id of the Agence to save the memo for it</param>
        /// <param name="memos">the memo to be saved</param>
        /// <returns>a result object</returns>
        public async Task<Result> SaveMemosAsync(string id, ICollection<Memo> memos)
        {
            var result = await GetEntityByIdAsync(id);
            result.Memos = memos;
            _dataAccess.Update(result);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success("updated successfully");
        }

        /// <summary>
        /// check if the given matricule is unique
        /// </summary>
        /// <param name="reference">the matricule to be checked</param>
        /// <returns>true if unique, false if not</returns>
        public async Task<Result<bool>> CheckUniqueReferenceAsync(string reference)
        {
            var result = await _dataAccess.IsExistAsync(c => c.Reference == reference);
            return Result<bool>.Success(!result);
        }

        #region Login Agence

        /// <summary>
        /// create a login for the user
        /// </summary>
        /// <param name="loginModel">the login model to create the user login</param>
        /// <returns>an operation result</returns>
        public async Task<Result<UserModel>> CreateLoginForAgenceAsync(CreateLoginModel loginModel)
        {
            var agence = await GetEntityByIdAsync(loginModel.Id);

            if (!(agence.AgenceLoginId is null))
                return Result<UserModel>.Failed(null, null, "this agence already owns a Login");

            var userModel = new User()
            {
                IsActive = loginModel.IsActive,
                FirstName = agence.RaisonSociale,
                LastName = "",
                Email = "",
                PhoneNumber = "",
                RegistrationNumber = agence.Reference,
                AgenceId = agence.Id,
                Passwordhash = _passwordManager.CreatePasswordSalt(loginModel.Password),
                UserName = loginModel.UserName,
                RoleId = (int)UserRole.AdminAgence
            };

            await _accountDataAccess.AddAsync(userModel);
            agence.AgenceLoginId = userModel.Id;
            _dataAccess.Update(agence);
            await _unitOfWork.SaveChangesAsync();

            var data = _mapper.Map<UserModel>(userModel);
            return Result<UserModel>.Success(data);
        }

        /// <summary>
        /// delete the login of a Agence
        /// </summary>
        /// <param name="agenceId">the id of the agence to remove the login for it</param>
        /// <returns>an operation result</returns>
        public async Task<Result> DeleteLoginForAgenceAsync(string agenceId)
        {
            var result = await GetEntityByIdAsync(agenceId);

            if (result.AgenceLoginId is null)
                return Result.Failed(null, "this Agence doesn't own any login");

            var loginId = (string)result.AgenceLoginId;
            result.AgenceLoginId = null;
            _dataAccess.Update(result);
            await _accountDataAccess.DeleteAsync(loginId);
            await _unitOfWork.SaveChangesAsync();

            return Result.Success("removed successfully");
        }

        /// <summary>
        /// get the login detail of an agence
        /// </summary>
        /// <param name="agenceId">the id of the agence to retrieve the login for it</param>
        /// <returns>a user model</returns>
        public async Task<Result<UserModel>> GetAgenceLoginAsync(string agenceId)
        {
            var result = await GetEntityByIdAsync(agenceId);

            if (result.AgenceLoginId is null)
                return Result<UserModel>.Failed(null, null, "this Agence doesn't own any login");

            var userLogin = await _accountDataAccess.GetAsync(result.AgenceLoginId);
            var userLoginModel = _mapper.Map<UserModel>(userLogin);
            return Result<UserModel>.Success(userLoginModel);
        }

        #endregion

        #region private methods

        /// <summary>
        /// add default value to agence
        /// </summary>
        /// <param name="agenceId">the id of agence</param>
        /// <returns></returns>
        private async Task AddDefaultValueToAgence(string agenceId)
        {
            var caisse = new BankAccount()
            {
                Name = "Caisse",
                IsModify = false,
                AgenceId = agenceId,
                Type = BankAccountType.Caisse
            };
            await _bankAccountDataAccess.AddAsync(caisse);

            List<NumerotationCreateModel> numerotations = new List<NumerotationCreateModel>
            {
                new NumerotationCreateModel { Root = "FA", DateFormat = DateFormat.NoDate, Counter = 1, CounterLength = 5, Type = NumerotationType.Facture, AgenceId = agenceId },
                new NumerotationCreateModel { Root = "AV", DateFormat = DateFormat.NoDate, Counter = 1, CounterLength = 5, Type = NumerotationType.Avoir, AgenceId = agenceId },
                new NumerotationCreateModel { Root = "CLPR", DateFormat = DateFormat.NoDate, Counter = 1, CounterLength = 5, Type = NumerotationType.ClientProfessionnel, AgenceId = agenceId },
                new NumerotationCreateModel { Root = "CLPA", DateFormat = DateFormat.NoDate, Counter = 1, CounterLength = 5, Type = NumerotationType.ClientParticulier, AgenceId = agenceId },
                new NumerotationCreateModel { Root = "CLOBL", DateFormat = DateFormat.NoDate, Counter = 1, CounterLength = 5, Type = NumerotationType.ClientObliges, AgenceId = agenceId },
                new NumerotationCreateModel { Root = "FR", DateFormat = DateFormat.NoDate, Counter = 1, CounterLength = 5, Type = NumerotationType.Fournisseur, AgenceId = agenceId },
                new NumerotationCreateModel { Root = "UT", DateFormat = DateFormat.NoDate, Counter = 1, CounterLength = 5, Type = NumerotationType.User, AgenceId = agenceId },
                new NumerotationCreateModel { Root = "DO", DateFormat = DateFormat.NoDate, Counter = 1, CounterLength = 5, Type = NumerotationType.Dossier, AgenceId = agenceId },
                new NumerotationCreateModel { Root = "DE", DateFormat = DateFormat.NoDate, Counter = 1, CounterLength = 5, Type = NumerotationType.Devis, AgenceId = agenceId }
            };
            await _numerotationService.CreateListNumerotationAsync(numerotations);
        }

        /// <summary>
        /// Update name of user associate with agence
        /// </summary>
        /// <param name="userAgenceId">the id of user agence</param>
        /// <param name="firstName">the first name of user</param>
        /// <param name="lastName">the last name of user</param>
        /// <returns></returns>
        private async Task UpdateNameUserAssociateWithAgence(string userAgenceId, string firstName, string lastName)
        {
            var user = await _accountDataAccess.GetAsync(userAgenceId);
            user.FirstName = $"{firstName}";
            user.LastName = $"{lastName}";
            _accountDataAccess.Update(user);
        }

        #endregion

        #region overrides

        protected override async Task AfterAddEntity(Agence entity, AgenceCreateModel model)
        {
            await _numerotationService.IncrementNumerotationWithoutSaveChangesAsync(NumerotationType.Agence);
            await AddDefaultValueToAgence(entity.Id);
        }

        protected override Func<IQueryable<Agence>, IIncludableQueryable<Agence, object>> BuildIncludesGetById()
            => e => e.Include(a => a.AgenceLogin);

        protected override Func<IQueryable<Agence>, IIncludableQueryable<Agence, object>> BuildIncludesList()
            => e => e.Include(a => a.AgenceLogin);

        protected override async Task AfterUpdateEntity(Agence entity, AgenceUpdateModel model)
        {
            // update name if he agence to a entity user
            if (entity.AgenceLoginId.IsValid())
            {
                // update user first and last name of agence
                await UpdateNameUserAssociateWithAgence(entity.AgenceLoginId, entity.RaisonSociale, "");
            }
        }

        #endregion
    }
}
