namespace COMPANY.Controllers.EntitiesControllers
{
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Enums;
    using COMPANY.Application.Models.BusinessEntitiesModels.ConfigMessagerieModels;
    using COMPANY.Application.Services.DataService.ConfigMessagerieService;
    using COMPANY.Domain.Enums.Authentification;
    using COMPANY.Presentation.Authorization;
    using COMPANY.Presentation.Controllers.Base;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Authorize]
    [Route("api/[controller]")]
    [Module(Modules.Parameters)]
    [ApiController]
    public class ConfigMessagerieController : BaseController
    {
        private readonly IConfigMessagerieService _service;

        public ConfigMessagerieController(IConfigMessagerieService service)
        {
            _service = service;
        }

        /// <summary>
        /// get the config messagerie
        /// </summary>
        /// <returns>a paged result</returns>
        [HttpGet]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<ConfigMessagerieModel>>> Get()
            => ActionResultFor(await _service.GetConfigMessagerieAsync());

        /// <summary>
        /// create a new config messagerie record
        /// </summary>
        /// <returns>the newly created config messagerie</returns>
        [HttpPost("create")]
        [Permission(Access.Create)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<ConfigMessagerieModel>>> Create(ConfigMessagerieCreateModel createModel)
            => ActionResultFor(await _service.CreateConfigMessagerieAsync(createModel));

        /// <summary>
        /// update the config messagerie with the given model
        /// </summary>
        /// <param name="id">the id of the config messagerie to be updated</param>
        /// <param name="updateModel">the update model</param>
        /// <returns>the updated config messagerie</returns>
        [HttpPut("Update/{id}")]
        [Permission(Access.Update)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<ConfigMessagerieModel>>> Update(string id, [FromBody]ConfigMessagerieUpdateModel updateModel)
            => ActionResultFor(await _service.UpdateConfigMessagerieAsync(id, updateModel));
    }
}
