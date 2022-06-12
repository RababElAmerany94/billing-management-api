namespace COMPANY.Presentation.Controllers.Parameters
{
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Enums;
    using COMPANY.Application.Models;
    using COMPANY.Application.Models.BusinessEntities.Parameters.SourceDuLead;
    using COMPANY.Application.Services.DataService.Parameters.SourceDuLeadService;
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
    [Module(Modules.Parameters)]
    [ApiController]
    public class SourceDuLeadController : BaseController
    {
        private readonly ISourceDuLeadService _service;

        public SourceDuLeadController(
            ISourceDuLeadService service
        ) => _service = service;

        /// <summary>
        /// get the list of all source du lead
        /// </summary>
        [HttpGet]
        [Permission(Access.Read)]
        public async Task<ActionResult<IEnumerable<SourceDuLeadModel>>> Get()
            => Ok(await _service.GetAllAsync());

        /// <summary>
        /// get the list of source du lead as paged Result
        /// </summary>
        /// <param name="filterModel">the filter options</param>
        /// <returns>a paged result</returns>
        [HttpPost]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<PagedResult<SourceDuLeadModel>>> Get([FromBody] FilterOption filterModel)
            => ActionResultFor(await _service.GeAsPagedResultAsync(filterModel));

        /// <summary>
        /// create a new Source du lead record
        /// </summary>
        /// <returns>the newly created SourceDuLead</returns>
        [HttpPost("create")]
        [Permission(Access.Create)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<SourceDuLeadModel>>> Create(SourceDuLeadCreateModel SourceDuLeadCreateModel)
            => ActionResultFor(await _service.CreateAsync(SourceDuLeadCreateModel));

        /// <summary>
        /// update the Source du lead with the given model
        /// </summary>
        /// <param name="id">the id of the business origin to be updated</param>
        /// <param name="SourceDuLeadUpdateModel">the update model</param>
        /// <returns>the updated Source du lead</returns>
        [HttpPut("Update/{id}")]
        [Permission(Access.Update)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<SourceDuLeadModel>>> Update(string id, [FromBody] SourceDuLeadUpdateModel SourceDuLeadUpdateModel)
            => ActionResultFor(await _service.UpdateAsync(id, SourceDuLeadUpdateModel));

        /// <summary>
        /// delete the Source du lead with the given id
        /// </summary>
        /// <param name="id">the id of the Source du lead to be deleted</param>
        /// <returns>an operation result object</returns>
        [HttpDelete("delete/{id}")]
        [Permission(Access.Delete)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result>> Delete(string id)
            => ActionResultFor(await _service.DeleteAsync(id));

        /// <summary>
        /// check name of Source du lead is unique
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
