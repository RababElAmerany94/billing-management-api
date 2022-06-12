namespace COMPANY.Controllers.EntitiesControllers
{
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Enums;
    using COMPANY.Application.Models;
    using COMPANY.Application.Models.BusinessEntitiesModels.BankAccountModels;
    using COMPANY.Application.Services.DataService.BankAccountService;
    using COMPANY.Domain.Enums.Authentification;
    using COMPANY.Presentation.Authorization;
    using COMPANY.Presentation.Controllers.Base;
    using COMPANY.Presistence.Implementations;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Authorize]
    [Route("api/[controller]")]
    [Module(Modules.BankAccount)]
    [ApiController]
    public class BankAccountsController : BaseController
    {
        private readonly IBankAccountService _service;

        public BankAccountsController(
            IBankAccountService service
        ) => _service = service;

        /// <summary>
        /// get the list of bank accounts as paged Result
        /// </summary>
        /// <param name="filterModel">the filter options</param>
        /// <returns>a paged result</returns>
        [HttpPost]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<PagedResult<BankAccountModel>>> Get([FromBody]FilterOption filterModel)
             => ActionResultFor(await _service.GeAsPagedResultAsync(filterModel));

        /// <summary>
        /// create a new bank account record
        /// </summary>
        /// <returns>the newly created bank account</returns>
        [HttpPost("create")]
        [Permission(Access.Create)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<BankAccountModel>>> Create(BankAccountCreateModel bankAccountModel)
            => ActionResultFor(await _service.CreateAsync(bankAccountModel));

        /// <summary>
        /// update the bank account with the given model
        /// </summary>
        /// <param name="id">the id of the bank account to be updated</param>
        /// <param name="bankAccountUpdateModel">the update model</param>
        /// <returns>the updated bank account</returns>
        [HttpPut("Update/{id}")]
        [Permission(Access.Update)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<BankAccountModel>>> Update(string id, [FromBody]BankAccountUpdateModel bankAccountUpdateModel)
            => ActionResultFor(await _service.UpdateAsync(id, bankAccountUpdateModel));

        /// <summary>
        /// delete the bank account with the given id
        /// </summary>
        /// <param name="id">the id of the bank account to be deleted</param>
        /// <returns>an operation result object</returns>
        [HttpDelete("delete/{id}")]
        [Permission(Access.Delete)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result>> Delete(string id)
            => ActionResultFor(await _service.DeleteAsync(id));

        /// <summary>
        /// check name of bank account is unique
        /// </summary>
        /// <param name="name">the name to check is unique</param>
        /// <returns></returns>
        [HttpGet("IsUnique/{name}")]
        [Permission(Access.Create)]
        [ProducesResponseType(200)]
        public async Task<ActionResult<Result<bool>>> IsUnique(string name)
            => ActionResultFor(await _service.IsUniqueAsync(name));
    }
}