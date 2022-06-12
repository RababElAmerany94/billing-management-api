namespace COMPANY.Controllers
{
    using Application.Data.Enums;
    using Application.Models;
    using Application.Services.AuthService;
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Enums;
    using COMPANY.Application.Models.Account;
    using COMPANY.Application.Models.BusinessEntitiesModels.AccountModels;
    using COMPANY.Application.Models.General.FilterOptions;
    using COMPANY.Domain.Entities.OwnedEntities;
    using COMPANY.Domain.Enums.Authentification;
    using COMPANY.Presentation.Authorization;
    using COMPANY.Presentation.Controllers.Base;
    using COMPANY.Presistence.Implementations;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [Module(Modules.Users)]
    [ApiController]
    public class AccountController : BaseController
    {
        private readonly IAccountService _service;

        public AccountController(IAccountService service)
            => _service = service;

        /// <summary>
        /// get the user with the given Id
        /// </summary>
        /// <param name="id">the id of the user</param>
        /// <returns>return the user</returns>
        [HttpGet("{id}")]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [Authorize]
        public async Task<ActionResult<Result<UserModel>>> Get(string id)
            => ActionResultFor(await _service.GetByIdAsync(id));

        /// <summary>
        /// create a new user
        /// </summary>
        /// <param name="userModel">the user model</param>
        /// <returns>the newly created user</returns>
        [HttpPost("Create")]
        [Permission(Access.Create)]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<UserModel>>> Create([FromBody] UserCreateModel userModel)
            => ActionResultFor(await _service.CreateAsync(userModel));

        /// <summary>
        /// delete the user with the given Id
        /// </summary>
        /// <param name="id">the id of the user to be deleted</param>
        /// <returns>an operation result</returns>
        [HttpDelete("Delete/{id}")]
        [Permission(Access.Delete)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result>> Delete(string id)
            => ActionResultFor(await _service.DeleteAsync(id));

        /// <summary>
        /// log in the user and generate a token for his session
        /// </summary>
        /// <param name="loginModel">the login model</param>
        /// <returns>a user token model</returns>
        [AllowAnonymous]
        [HttpPost("Login")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<UserTokenModel>> Login([FromBody] UserLoginModel loginModel)
        {
            // Check if the user is exist
            var result = await _service.IsUserExistAsync(loginModel.UserName, loginModel.Password);

            // the operation failed something went wrong
            if (result.Status == ResultStatus.Failed && result.HasError)
                return StatusCode(500, result);

            // no value means no user has been found
            if (!result.HasValue)
                return NotFound(result);

            // generate the user claims
            var claimPrincipal = result.Value.GenerateClaimsPrincipal();

            // sign in the user with AUTH handler
            await HttpContext.SignInAsync(claimPrincipal);

            // get the generated token
            var token = HttpContext.User.FindFirst("token")?.Value;

            // if the token is null or empty, something wrong happened
            if (string.IsNullOrEmpty(token))
                return StatusCode(500);

            // return the token
            return new UserTokenModel()
            {
                Token = token,
                RoleId = result.Value.Role.Id,
                Actif = result.Value.IsActive
            };
        }

        /// <summary>
        /// update the user password
        /// </summary>
        /// <param name="updatePasswordModel">the password model</param>
        [HttpPut("UpdatePassword")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result>> UpdatePassword(UserUpdatePasswordModel updatePasswordModel)
            => ActionResultFor(await _service.UpdateUserPassword(updatePasswordModel));

        /// <summary>
        /// update the user with the given id
        /// </summary>
        /// <param name="userId">the id of the user to be updated</param>
        /// <param name="userModel">the user model</param>
        /// <returns>the updated version of the user</returns>
        [HttpPut("Update/{userId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<UserModel>>> UpdateUser(string userId, [FromBody] UserUpdateModel userModel)
            => ActionResultFor(await _service.UpdateAsync(userId, userModel));

        /// <summary>
        /// check if the user name is unique
        /// </summary>
        /// <param name="userName">the user name to be checked</param>
        /// <returns></returns>
        [HttpPut("IsUserNameUnique/{userName}")]
        [ProducesResponseType(200)]
        [Authorize]
        public async Task<ActionResult<Result<bool>>> IsUserNameUnique(string userName)
            => ActionResultFor(await _service.IsUserNameUniqueAsync(userName));

        /// <summary>
        /// update the user login info
        /// </summary>
        /// <param name="loginModel">the login model</param>
        /// <returns>the updated version of the user</returns>
        [HttpPut("UpdateLogin")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<UserModel>>> UpdateUserLogin(LoginModel loginModel)
            => ActionResultFor(await _service.UpdateUserLoginAsync(loginModel));

        /// <summary>
        /// get the list of users as paged Result
        /// </summary>
        /// <param name="filterModel">the filter options</param>
        /// <returns>a paged result</returns>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<PagedResult<UserModel>>> Get([FromBody] UserFilterOption filterModel)
            => ActionResultFor(await _service.GeAsPagedResultAsync(filterModel));

        /// <summary>
        /// get lite information of the user with the given Id
        /// </summary>
        /// <param name="id">the id of the user</param>
        /// <returns>return the user</returns>
        [HttpGet("Lite/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<UserLiteModel>>> GetLite(string id)
            => ActionResultFor(await _service.GetLiteUserAsync(id));

        /// <summary>
        /// save the given memo to the user with the given id
        /// </summary>
        /// <param name="id">the id of the user to save the memo for it</param>
        /// <param name="memos">the memo to be saved</param>
        /// <returns>a result object</returns>
        [HttpPost("Memos/Save/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result>> SaveMemos(string id, [FromBody] ICollection<Memo> memos)
            => ActionResultFor(await _service.SaveMemosAsync(id, memos));

        /// <summary>
        /// check if the given reference is unique, returns true if unique, false if not
        /// </summary>
        /// <param name="reference">the reference to be checked</param>
        /// <returns>true if unique, false if not</returns>
        [HttpGet("CheckUniqueMatricule/{reference}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<bool>>> CheckUniqueReference(string reference)
            => ActionResultFor(await _service.CheckUniqueMatriculeAsync(reference));

        /// <summary>
        /// change activation of agence
        /// </summary>
        /// <param name="changeActivateUser">the change visibility model</param>
        /// <returns>a activation of user</returns>
        [HttpPost("ChangeActivateUser")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<bool>>> Create([FromBody] ChangeActivationUserModel changeActivateUser)
            => ActionResultFor(await _service.ChangeActivateUser(changeActivateUser));

        /// <summary>
        /// get planning of commercials
        /// </summary>
        /// <param name="filterOption">the filter options</param>
        /// <returns>a paged result</returns>
        [HttpPost("GetCommercialsPlanning")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<PagedResult<CommercialPlanningModel>>> GetPlanningTechnicien([FromBody] CommercialsPlanningFilterOption filterOption)
            => ActionResultFor(await _service.GetCommercialsPlanningAsPagedResultAsync(filterOption));

        /// <summary>
        /// update Google calendar id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="googleCalendarId"></param>
        /// <returns></returns>
        [HttpPost("UpdateGoogleCalendarId/{id}/{googleCalendarId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result>> Create([FromRoute] string id, [FromRoute] string googleCalendarId)
            => ActionResultFor(await _service.UpdateGoogleCalendarId(id, googleCalendarId));
    }
}
