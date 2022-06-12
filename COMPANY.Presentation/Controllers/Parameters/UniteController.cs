namespace COMPANY.Presentation.Controllers.EntitiesControllers
{
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Enums;
    using COMPANY.Application.Models;
    using COMPANY.Application.Models.BusinessEntitiesModels.UniteModels;
    using COMPANY.Application.Services.DataService.UniteService;
    using COMPANY.Domain.Enums.Authentification;
    using COMPANY.Presentation.Authorization;
    using COMPANY.Presentation.Controllers.Base;
    using COMPANY.Presistence.Implementations;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [Module(Modules.Parameters)]
    [ApiController]
    public class UniteController : BaseController
    {

        private readonly IUniteService _service;

        public UniteController(IUniteService service)
            => _service = service;

        /// <summary>
        /// get the list of all unite
        /// </summary>
        [HttpGet]
        [Permission(Access.Read)]
        public async Task<ActionResult<IEnumerable<UniteModel>>> Get()
            => Ok(await _service.GetAllAsync());

        /// <summary>
        /// get the list of unite as paged Result
        /// </summary>
        /// <param name="filterOption">the filter options</param>
        /// <returns>a paged result</returns>
        [HttpPost]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<PagedResult<UniteModel>>> Get([FromBody] FilterOption filterOption)
            => ActionResultFor(await _service.GeAsPagedResultAsync(filterOption));
        
        /// <summary>
        /// create a new category product record
        /// </summary>
        /// <returns>the newly created unite</returns>
        [HttpPost("create")]
        [Permission(Access.Create)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<UniteModel>>> Create(UniteCreateModel uniteCreateModel)
            => ActionResultFor(await _service.CreateAsync(uniteCreateModel));

        /// <summary>
        /// update the category product with the given model
        /// </summary>
        /// <param name="id">the id of the unite to be updated</param>
        /// <param name="uniteUpdateModel">the update model</param>
        /// <returns>the updated unite</returns>
        [HttpPut("Update/{id}")]
        [Permission(Access.Update)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<UniteModel>>> Update(string id, [FromBody] UniteUpdateModel uniteUpdateModel)
            => ActionResultFor(await _service.UpdateAsync(id, uniteUpdateModel));

        /// <summary>
        /// delete the unite with the given id
        /// </summary>
        /// <param name="id">the id of the unite to be deleted</param>
        /// <returns>an operation result object</returns>
        [HttpDelete("delete/{id}")]
        [Permission(Access.Delete)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result>> Delete(string id)
            => ActionResultFor(await _service.DeleteAsync(id));

        /// <summary>
        /// check name of unite is unique
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