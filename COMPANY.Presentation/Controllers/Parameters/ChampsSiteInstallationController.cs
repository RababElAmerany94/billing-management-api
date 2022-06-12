namespace COMPANY.Presentation.Controllers.Parameters
{
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Enums;
    using COMPANY.Application.Models;
    using COMPANY.Application.Models.BusinessEntities.Parameters.ChampsSiteInstallation;
    using COMPANY.Application.Services.DataService.Parameters.ChampSiteInstallationService;
    using COMPANY.Domain.Enums.Authentification;
    using COMPANY.Presentation.Authorization;
    using COMPANY.Presentation.Controllers.Base;
    using COMPANY.Presistence.Implementations;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [Module(Modules.ChampsSiteInstallation)]
    [ApiController]
    public class ChampsSiteInstallationController : BaseController
    {
        private readonly IChampSiteInstallationService _service;

        public ChampsSiteInstallationController(IChampSiteInstallationService service)
            => _service = service;

        /// <summary>
        /// get the list of all champs site d'installation
        /// </summary>
        [HttpGet]
        [Permission(Access.Read)]
        public async Task<ActionResult<IEnumerable<ChampSiteInstallationModel>>> Get()
            => Ok(await _service.GetAllAsync());

        /// <summary>
        /// get the list of champs site d'installation as paged Result
        /// </summary>
        /// <param name="filterOption">the filter options</param>
        /// <returns>a paged result</returns>
        [HttpPost]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<PagedResult<ChampSiteInstallationModel>>> Get([FromBody] FilterOption filterOption)
            => ActionResultFor(await _service.GeAsPagedResultAsync(filterOption));

        /// <summary>
        /// create a new champs site d'installation record
        /// </summary>
        /// <returns>the newly created champs site d'installation</returns>
        [HttpPost("create")]
        [Permission(Access.Create)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<ChampSiteInstallationModel>>> Create(ChampSiteInstallationCreateModel model)
            => ActionResultFor(await _service.CreateAsync(model));

        /// <summary>
        /// update the champ site d'installation with the given model
        /// </summary>
        /// <param name="id">the id of the champs site d'installation to be updated</param>
        /// <param name="model">the update model</param>
        /// <returns>the updated champ site d'installation</returns>
        [HttpPut("Update/{id}")]
        [Permission(Access.Update)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<ChampSiteInstallationModel>>> Update(string id, [FromBody] ChampSiteInstallationUpdateModel model)
            => ActionResultFor(await _service.UpdateAsync(id, model));

        /// <summary>
        /// delete the champ site d'installation with the given id
        /// </summary>
        /// <param name="id">the id of the champ site d'installation to be deleted</param>
        /// <returns>an operation result object</returns>
        [HttpDelete("delete/{id}")]
        [Permission(Access.Delete)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result>> Delete(string id)
            => ActionResultFor(await _service.DeleteAsync(id));

        /// <summary>
        /// check name of champ site d'installation is unique
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
