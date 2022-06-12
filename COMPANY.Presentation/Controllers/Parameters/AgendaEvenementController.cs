namespace COMPANY.Presentation.Controllers.Parameters
{
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Enums;
    using COMPANY.Application.Models.BusinessEntities.Parameters.AgendaEvenementType;
    using COMPANY.Application.Models.Generals.FilterOptions;
    using COMPANY.Application.Services.DataService.Parameters.AgendaEvenementService;
    using COMPANY.Domain.Enums.Authentification;
    using COMPANY.Presentation.Authorization;
    using COMPANY.Presentation.Controllers.Base;
    using COMPANY.Presistence.Implementations;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [Module(Modules.AgendaCommercial)]
    [ApiController]
    public class AgendaEvenementController : BaseController
    {
        private readonly IAgendaEvenementService _service;

        public AgendaEvenementController(IAgendaEvenementService service)
            => _service = service;

        /// <summary>
        /// get the list of all agenda event
        /// </summary>
        [HttpGet]
        [Permission(Access.Read)]
        public async Task<ActionResult<Result<IEnumerable<AgendaEvenementModel>>>> Get()
            => Ok(await _service.GetAllAsync());

        /// <summary>
        /// get the list of agenda event as paged Result
        /// </summary>
        /// <param name="filterOption">the filter options</param>
        /// <returns>a paged result</returns>
        [HttpPost]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<PagedResult<AgendaEvenementModel>>> Get([FromBody] AgendaEvenementFilterOption filterOption)
            => ActionResultFor(await _service.GeAsPagedResultAsync(filterOption));

        /// <summary>
        /// create a new agenda event record
        /// </summary>
        /// <returns>the newly created agenda event</returns>
        [HttpPost("create")]
        [Permission(Access.Create)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<AgendaEvenementModel>>> Create(AgendaEvenementCreateModel createModel)
            => ActionResultFor(await _service.CreateAsync(createModel));

        /// <summary>
        /// update the agenda event with the given model
        /// </summary>
        /// <param name="id">the id of the agenda event to be updated</param>
        /// <param name="updateModel">the update model</param>
        /// <returns>the updated agenda event</returns>
        [HttpPut("Update/{id}")]
        [Permission(Access.Update)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<AgendaEvenementModel>>> Update(string id, [FromBody] AgendaEvenementUpdateModel updateModel)
            => ActionResultFor(await _service.UpdateAsync(id, updateModel));

        /// <summary>
        /// delete the agenda event with the given id
        /// </summary>
        /// <param name="id">the id of the agenda event to be deleted</param>
        /// <returns>an operation result object</returns>
        [HttpDelete("delete/{id}")]
        [Permission(Access.Delete)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result>> Delete(string id)
            => ActionResultFor(await _service.DeleteAsync(id));

        /// <summary>
        /// check name of agenda event is unique
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
