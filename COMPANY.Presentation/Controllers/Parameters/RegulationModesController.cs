namespace COMPANY.Controllers.EntitiesControllers
{
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Enums;
    using COMPANY.Application.Models;
    using COMPANY.Application.Models.BusinessEntitiesModels.RegulationModeModels;
    using COMPANY.Application.Services.DataService.RegulationModeService;
    using COMPANY.Domain.Enums.Authentification;
    using COMPANY.Presentation.Authorization;
    using COMPANY.Presentation.Controllers.Base;
    using COMPANY.Presistence.Implementations;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Authorize]
    [Route("api/[controller]")]
    [Module(Modules.ModesReglement)]
    [ApiController]
    public class RegulationModesController : BaseController
    {
        private readonly IRegulationModeService _service;

        public RegulationModesController(
            IRegulationModeService service
        ) => _service = service;

        /// <summary>
        /// get the list of regulation modes as paged Result
        /// </summary>
        /// <param name="filterModel">the filter options</param>
        /// <returns>a paged result</returns>
        [HttpPost]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<PagedResult<RegulationModeModel>>> Get([FromBody] FilterOption filterModel)
            => ActionResultFor(await _service.GeAsPagedResultAsync(filterModel));

        /// <summary>
        /// create a new regulation mode record
        /// </summary>
        /// <returns>the newly created regulation mode</returns>
        [HttpPost("create")]
        [Permission(Access.Create)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<RegulationModeModel>>> Create(RegulationModeCreateModel regulationModeModel)
            => ActionResultFor(await _service.CreateAsync(regulationModeModel));

        /// <summary>
        /// update the regulation mode with the given model
        /// </summary>
        /// <param name="id">the id of the regulation mode to be updated</param>
        /// <param name="regulationModeUpdateModel">the update model</param>
        /// <returns>the updated regulation mode</returns>
        [HttpPut("Update/{id}")]
        [Permission(Access.Update)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<RegulationModeModel>>> Update(string id, [FromBody] RegulationModeUpdateModel regulationModeUpdateModel)
            => ActionResultFor(await _service.UpdateAsync(id, regulationModeUpdateModel));

        /// <summary>
        /// delete the regulation mode with the given id
        /// </summary>
        /// <param name="id">the id of the regulation mode to be deleted</param>
        /// <returns>an operation result object</returns>
        [HttpDelete("delete/{id}")]
        [Permission(Access.Delete)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result>> Delete(string id)
            => ActionResultFor(await _service.DeleteAsync(id));

        /// <summary>
        /// check name of regulation mode is unique
        /// </summary>
        /// <param name="name">the name to check is unique</param>
        /// <returns></returns>
        [HttpGet("IsUnique/{name}")]
        [Permission(Access.Create)]
        [ProducesResponseType(200)]
        public async Task<ActionResult<Result<bool>>> IsUnique(string name)
            => Ok(await _service.IsUniqueAsync(name));

    }
}