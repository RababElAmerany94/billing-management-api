namespace COMPANY.Controllers
{
    using Application.Models;
    using Application.Services.DataService;
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Enums;
    using COMPANY.Application.Models.GeneralModels.PagingModels;
    using COMPANY.Domain.Entities.OwnedEntities;
    using COMPANY.Domain.Enums.Authentification;
    using COMPANY.Presentation.Authorization;
    using COMPANY.Presentation.Controllers.Base;
    using COMPANY.Presistence.Implementations;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Authorize]
    [Route("api/[controller]")]
    [Module(Modules.Clients)]
    [ApiController]
    public class ClientsController : BaseController
    {
        private readonly IClientService _service;

        public ClientsController(IClientService service) => _service = service;

        /// <summary>
        /// get the list of all Clients
        /// </summary>
        [HttpGet]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<IEnumerable<ClientModel>>>> Get()
            => ActionResultFor(await _service.GetAllAsync());

        /// <summary>
        /// get the list of clients as paged Result
        /// </summary>
        /// <param name="filterModel">the filter options</param>
        /// <returns>a paged result</returns>
        [HttpPost]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<PagedResult<ClientModel>>> Get([FromBody] ClientFilterOption filterModel)
            => ActionResultFor(await _service.GeAsPagedResultAsync(filterModel));

        /// <summary>
        /// get the client with the given id
        /// </summary>
        /// <param name="id">the id of the client to retrieve</param>
        /// <returns>the client</returns>
        [HttpGet("{id}")]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<ClientModel>>> Get(string id)
            => ActionResultFor(await _service.GetByIdAsync(id));

        /// <summary>
        /// create a client using the ClientCreateModel
        /// </summary>
        /// <param name="clientModel">the model to create the client from it</param>
        /// <returns>the newly created client</returns>
        [HttpPost("Create")]
        [Permission(Access.Create)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<ClientModel>>> Create([FromBody] ClientCreateModel clientModel)
            => ActionResultFor(await _service.CreateAsync(clientModel));

        /// <summary>
        /// update the client with the given model
        /// </summary>
        /// <param name="id">the id of the client to be updated</param>
        /// <param name="clientModel">the update model</param>
        /// <returns>the updated client</returns>
        [HttpPut("Update/{id}")]
        [Permission(Access.Update)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<ClientModel>>> Update(string id, [FromBody] ClientUpdateModel clientModel)
            => ActionResultFor(await _service.UpdateAsync(id, clientModel));

        /// <summary>
        /// delete the client with the given id
        /// </summary>
        /// <param name="id">the id of the client to be deleted</param>
        /// <returns>a result object</returns>
        [HttpDelete("Delete/{id}")]
        [Permission(Access.Delete)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result>> Delete(string id)
            => ActionResultFor(await _service.DeleteAsync(id));

        /// <summary>
        /// check if the given reference is unique, returns true if unique, false if not
        /// </summary>
        /// <param name="reference">the reference to be checked</param>
        /// <returns>true if unique, false if not</returns>
        [HttpGet("CheckUniqueReference/{reference}")]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<bool>>> CheckUniqueReference(string reference)
            => ActionResultFor(await _service.CheckUniqueReferenceAsync(reference));

        /// <summary>
        /// check if the given phone is unique, returns true if unique, false if not
        /// </summary>
        /// <param name="phone">the phone to be checked</param>
        /// <returns>true if unique, false if not</returns>
        [HttpGet("CheckUniquePhone/{phone}")]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<bool>>> CheckUniquePhone(string phone)
            => ActionResultFor(await _service.CheckUniquePhoneAsync(phone));

        /// <summary>
        /// save the given memo to the client with the given id
        /// </summary>
        /// <param name="id">the id of the client to save the memo for it</param>
        /// <param name="memos">the memo to be saved</param>
        /// <returns>a result object</returns>
        [HttpPost("Memos/Save/{id}")]
        [Permission(Access.Create)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result>> SaveMemos(string id, [FromBody] ICollection<Memo> memos)
            => ActionResultFor(await _service.SaveMemosAsync(id, memos));

        /// <summary>
        /// export the list of client as an excel format
        /// </summary>
        /// <returns>the result object</returns>
        [HttpGet("ExporterExcel")]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<byte[]>>> ExporterExcel()
        {
            // get the user id
            var userId = HttpContext.GetUserID();

            // try to export the list of client, base on the current logged in user
            return ActionResultFor(await _service.ExportClientListAsExcelAsync(userId));
        }
    }
}