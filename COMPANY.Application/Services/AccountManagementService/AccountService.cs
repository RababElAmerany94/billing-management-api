namespace COMPANY.Application.Services.AuthService
{
    using Application.Data;
    using Application.Models;
    using AutoMapper;
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Exceptions;
    using COMPANY.Application.Interfaces;
    using COMPANY.Application.Models.Account;
    using COMPANY.Application.Models.BusinessEntitiesModels.AccountModels;
    using COMPANY.Application.Models.General.FilterOptions;
    using COMPANY.Application.Services.DataService;
    using COMPANY.Application.Services.DataService.NumerotationService;
    using COMPANY.Common.Helpers;
    using COMPANY.Domain.Entities;
    using COMPANY.Domain.Entities.OwnedEntities;
    using COMPANY.Domain.Enums;
    using COMPANY.Domain.Enums.Authentification;
    using COMPANY.Presistence.Implementations;
    using Inova.AutoInjection.Attributes;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Query;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    /// <summary>
    /// the service class for dealing with account operations
    /// implement <see cref="IAccountService"/>
    /// </summary>
    [Inject(typeof(IAccountService), ServiceLifetime.Scoped)]
    public class AccountService : 
        BaseService<User, string, UserModel, UserCreateModel, UserUpdateModel>, 
        IAccountService
    {
        private readonly IPasswordManager _passwordManager;
        private readonly INumerotationService _numerotationService;
        private readonly ICurrentUserService _currentUserService;
        private readonly IAccountDataAccess _accountDataAccess;

        public AccountService(
            IPasswordManager passwordManager,
            IDataRequestBuilder<User> accountRequestBuilder,
            IMapper mapper,
            INumerotationService numerotationService,
            ICurrentUserService currentUserService,
            IUnitOfWork unitOfWork)
            : base(accountRequestBuilder, unitOfWork, mapper, currentUserService)
        {
            _accountDataAccess = unitOfWork.AccountDataAccess;
            _passwordManager = passwordManager;
            _numerotationService = numerotationService;
            _currentUserService = currentUserService;
        }

        /// <summary>
        /// get lite information of the user with the specified id
        /// </summary>
        /// <param name="id">the id of the user</param>
        /// <returns>the userModel</returns>
        public async Task<Result<UserLiteModel>> GetLiteUserAsync(string id)
        {
            var result = await GetEntityByIdAsync(id);

            var data = _mapper.Map<UserLiteModel>(result);
            return Result<UserLiteModel>.Success(data, $"the {nameof(User)} retrieved successfully");
        }

        /// <summary>
        /// check if the given email is in use by another user
        /// </summary>
        /// <param name="email">email to validate</param>
        /// <returns>true if unique, false if not</returns>
        public async Task<Result<bool>> IsUserEmailUniqueAsync(string email)
        {
            var result = await _dataAccess.IsExistAsync(e => e.Email.ToLower() == email.ToLower()); ;
            return Result<bool>.Success(result);
        }

        /// <summary>
        /// check if the given userName is in use by another user
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>true if unique, false if not</returns>
        public async Task<Result<bool>> IsUserNameUniqueAsync(string userName)
        {
            var result = await _dataAccess.IsExistAsync(u => u.UserName.ToLower().Equals(userName.ToLower()));
            return Result<bool>.Success(!result);
        }

        /// <summary>
        /// update the login info, the id of the user is included in the model
        /// </summary>
        /// <param name="loginModel">the login model</param>
        /// <returns></returns>
        public async Task<Result<UserModel>> UpdateUserLoginAsync(LoginModel loginModel)
        {
            var result = await GetEntityByIdAsync(loginModel.Id);

            // ToDo: recored the changes, if the user has changed the userName or the active state
            result.UserName = loginModel.UserName;
            result.IsActive = loginModel.Actif;

            _dataAccess.Update(result);
            await _unitOfWork.SaveChangesAsync();

            // everything is OK map the new user to UserModel and return the result
            var updatedUser = _mapper.Map<UserModel>(result);
            return Result<UserModel>.Success(updatedUser, $"the {nameof(User)} updated successfully");
        }

        /// <summary>
        /// update the user password
        /// </summary>
        /// <param name="userUpdatePasswordModel">a model that hold the update requirement</param>
        /// <returns>a result instant</returns>
        public async Task<Result> UpdateUserPassword(UserUpdatePasswordModel userUpdatePasswordModel)
        {
            var result = await GetEntityByIdAsync(userUpdatePasswordModel.UserId);

            result.Passwordhash = _passwordManager.CreatePasswordSalt(userUpdatePasswordModel.NewPassword);

            _dataAccess.Update(result);
            await _unitOfWork.SaveChangesAsync();

            return Result.Success("password updated successfully");
        }

        /// <summary>
        /// check if the user is exist
        /// </summary>
        /// <param name="userName">the userName of the user</param>
        /// <param name="password">the password of the user</param>
        /// <returns>the founded user</returns>
        public async Task<Result<UserModel>> IsUserExistAsync(string userName, string password)
        {
            var result = await _accountDataAccess.GetUserByUserNameAsync(userName);

            var validationResult = _passwordManager.IsPasswordValid(password, result.Passwordhash);

            if (!validationResult)
                throw new NotFoundException($"the given password is invalid!");

            //check if the agence is active
            if (result.AgenceId.IsValid() && !result.Agence.IsActive)
                throw new NotFoundException($"the given agence id {result.AgenceId} is inactive!");

            var data = _mapper.Map<UserModel>(result);
            return Result<UserModel>.Success(data);
        }

        /// <summary>
        /// change activation of agence
        /// </summary>
        /// <param name="changeActivateUser">the change visibility model</param>
        /// <returns>a activation of user</returns>
        public async Task<Result<bool>> ChangeActivateUser(ChangeActivationUserModel changeActivateUser)
        {
            var result = await GetEntityByIdAsync(changeActivateUser.Id);
            result.IsActive = changeActivateUser.IsActive;
            _accountDataAccess.Update(result);
            await _unitOfWork.SaveChangesAsync();

            return Result<bool>.Success(result.IsActive);
        }

        /// <summary>
        /// save the given memos to the user memos list
        /// </summary>
        /// <param name="id">the id of the user to save the memo for him</param>
        /// <param name="memos">the memo to be saved</param>
        /// <returns>an operation result</returns>
        public async Task<Result> SaveMemosAsync(string id, ICollection<Memo> memos)
        {
            var result = await GetEntityByIdAsync(id);

            result.Memos = memos;
            _accountDataAccess.Update(result);
            await _unitOfWork.SaveChangesAsync();

            return Result.Success("memo updated successfully");
        }

        /// <summary>
        /// check if the given matricule is unique
        /// </summary>
        /// <param name="matricule">the reference to be checked</param>
        /// <returns>true if unique, false if not</returns>
        public async Task<Result<bool>> CheckUniqueMatriculeAsync(string matricule)
        {
            var result = await _accountDataAccess.IsExistAsync(c => c.RegistrationNumber == matricule && c.AgenceId == _user.AgenceId);
            return Result<bool>.Success(!result);
        }

        /// <summary>
        /// get the list of commercials planning as paged Result
        /// </summary>
        /// <param name="filterOption">the filter options</param>
        /// <returns>a paged result</returns>
        public async Task<PagedResult<CommercialPlanningModel>> GetCommercialsPlanningAsPagedResultAsync(CommercialsPlanningFilterOption filterOption)
        {
            var request = BuildGetCommercialPlanningDataRequest(filterOption);
            var result = await _accountDataAccess.GetTechniciensPlanningAsPagedResultAsync(filterOption, request);

            if (!result.HasValue)
                return PagedResult<CommercialPlanningModel>.Failed(result.Error, $"Failed to retrieve list of commercials");

            return result;
        }

        /// <summary>
        /// update Google calendar id
        /// </summary>
        /// <param name="userId">the id of user</param>
        /// <param name="calendarId">the new calendar id</param>
        /// <returns></returns>
        public async Task<Result> UpdateGoogleCalendarId(string userId, string calendarId)
        {
            var user = await GetEntityByIdAsync(userId);
            user.GoogleCalendarId = calendarId;
            _dataAccess.Update(user);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success("the Google calendar id update successfully");
        }

        #region private methods

        private IDataRequest<User> BuildGetCommercialPlanningDataRequest(CommercialsPlanningFilterOption filterOption)
        {
            var acceptedRoles = new List<int> {
                (int)UserRole.Technicien,
                (int)UserRole.Admin,
                (int)UserRole.Commercial
            };

            // filter by role and search query
            var predicate = PredicateBuilder.True<User>()
                .And(u => u.FirstName.Contains(filterOption.SearchQuery) || u.LastName.Contains(filterOption.SearchQuery))
                .And(u => acceptedRoles.Contains(u.RoleId));

            if (_user.IsFollowAgence)
                predicate = predicate.And(c => c.AgenceId == _user.AgenceId);

            return _dataRequestBuilder.AddPredicate(predicate).Buil();
        }

        #endregion

        #region overrides

        protected override Task BeforeAddEntity(User entity, UserCreateModel model)
        {
            entity.Passwordhash = _passwordManager.CreatePasswordSalt(model.Password);
            entity.RoleId = model.RoleId;
            return base.BeforeAddEntity(entity, model);
        }

        protected override async Task AfterAddEntity(User entity, UserCreateModel model)
            => await _numerotationService.IncrementNumerotationWithoutSaveChangesAsync(NumerotationType.User);

        protected override Func<IQueryable<User>, IIncludableQueryable<User, object>> BuildIncludesGetById()
            => e => e.Include(u => u.Role)
                .Include(u => u.Agence)
                .Include(u => u.AgenceLogin);

        protected override Expression<Func<User, bool>> BuildGetAsPagedPredicate<TFilter>(TFilter filterModel)
        {
            var predicate = PredicateBuilder.True<User>();

            if (filterModel is UserFilterOption filterOption)
            {
                // the current logged in user could be an Agence or any other user
                // the key here is to use the associate id on the user entity
                if (_currentUserService.IsFollowAgence)
                    predicate = predicate.And(c => c.AgenceId == _user.AgenceId);
                else if (!(filterOption.IsAll.HasValue && filterOption.IsAll.Value))
                    predicate = predicate.And(c => !c.AgenceId.IsValid());

                // filter by roles
                if (filterOption.RolesId != null && filterOption.RolesId.Count() > 0)
                    predicate = predicate.And(x => filterOption.RolesId.Contains(x.RoleId));

                // filter by Agence id
                if (filterOption.AgenceId.IsValid())
                    predicate = predicate.And(e => e.AgenceId == filterOption.AgenceId);
            }

            return predicate;
        }

        protected override Func<IQueryable<User>, IIncludableQueryable<User, object>> BuildIncludesList()
            => e => e.Include(u => u.Role);

        #endregion
    }
}
