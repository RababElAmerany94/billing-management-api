namespace COMPANY.Presentation.Controllers.Parameters
{
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Enums;
    using COMPANY.Application.Models;
    using COMPANY.Application.Models.BusinessEntities.Parameters.LogementType;
    using COMPANY.Application.Services.DataService.Parameters.LogementTypeService;
    using COMPANY.Domain.Enums.Authentification;
    using COMPANY.Presentation.Authorization;
    using COMPANY.Presentation.Controllers.Base;
    using COMPANY.Presistence.Implementations;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [Module(Modules.TypeLogement)]
    [ApiController]
    public class LogementTypeController : BaseController
    {
        private readonly ILogementTypeService _service;

        public LogementTypeController(ILogementTypeService service)
            => _service = service;

        /// <summary>
        /// get the list of all logement type
        /// </summary>
        [HttpGet]
        [Permission(Access.Read)]
        public async Task<ActionResult<IEnumerable<LogementTypeModel>>> Get()
            => Ok(await _service.GetAllAsync());

        /// <summary>
        /// get the list of logement type as paged Result
        /// </summary>
        /// <param name="filterOption">the filter options</param>
        /// <returns>a paged result</returns>
        [HttpPost]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<PagedResult<LogementTypeModel>>> Get([FromBody] FilterOption filterOption)
            => ActionResultFor(await _service.GeAsPagedResultAsync(filterOption));

        /// <summary>
        /// create a new logement type record
        /// </summary>
        /// <returns>the newly created logement type</returns>
        [HttpPost("create")]
        [Permission(Access.Create)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<LogementTypeModel>>> Create(LogementTypeCreateModel logementTypeCreateModel)
            => ActionResultFor(await _service.CreateAsync(logementTypeCreateModel));

        /// <summary>
        /// update the logement type with the given model
        /// </summary>
        /// <param name="id">the id of the logement type to be updated</param>
        /// <param name="logementTypeUpdateModel">the update model</param>
        /// <returns>the updated logement type</returns>
        [HttpPut("Update/{id}")]
        [Permission(Access.Update)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<LogementTypeModel>>> Update(string id, [FromBody] LogementTypeUpdateModel logementTypeUpdateModel)
            => ActionResultFor(await _service.UpdateAsync(id, logementTypeUpdateModel));

        /// <summary>
        /// delete the unite with the given id
        /// </summary>
        /// <param name="id">the id of the logement type to be deleted</param>
        /// <returns>an operation result object</returns>
        [HttpDelete("delete/{id}")]
        [Permission(Access.Delete)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result>> Delete(string id)
            => ActionResultFor(await _service.DeleteAsync(id));

        /// <summary>
        /// check name of logement type is unique
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
