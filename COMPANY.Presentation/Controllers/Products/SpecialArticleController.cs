namespace COMPANY.Presentation.Controllers.EntitiesControllers
{
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Enums;
    using COMPANY.Application.Models;
    using COMPANY.Application.Models.BusinessEntitiesModels.SpecialArticleModels;
    using COMPANY.Application.Services.DataService.MarqueService;
    using COMPANY.Domain.Enums.Authentification;
    using COMPANY.Presentation.Authorization;
    using COMPANY.Presentation.Controllers.Base;
    using COMPANY.Presistence.Implementations;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Configuration management API controller
    /// </summary>
    [Route("api/[controller]")]
    [Module(Modules.Parameters)]
    [ApiController]
    public class SpecialArticleController : BaseController
    {
        private readonly ISpecialArticleService _service;

        public SpecialArticleController(ISpecialArticleService service) => _service = service;

        /// <summary>
        /// get the list of all marques
        /// </summary>
        [HttpGet]
        [Permission(Access.Read)]
        public async Task<ActionResult<IEnumerable<SpecialArticleModel>>> Get()
            => Ok(await _service.GetAllAsync());

        /// <summary>
        /// get the list of special articles as paged Result
        /// </summary>
        /// <param name="filterModel">the filter options</param>
        /// <returns>a paged result</returns>
        [HttpPost]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<PagedResult<SpecialArticleModel>>> Get([FromBody] FilterOption filterModel)
            => ActionResultFor(await _service.GeAsPagedResultAsync(filterModel));

        /// <summary>
        /// create a new special article record
        /// </summary>
        /// <returns>the newly created special article</returns>
        [HttpPost("create")]
        [Permission(Access.Create)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<SpecialArticleModel>>> Create(SpecialArticleCreateModel specialArticleModel)
            => ActionResultFor(await _service.CreateAsync(specialArticleModel));

        /// <summary>
        /// update the special article with the given model
        /// </summary>
        /// <param name="id">the id of the business origin to be updated</param>
        /// <param name="specialArticleUpdateModel">the update model</param>
        /// <returns>the updated special article</returns>
        [HttpPut("Update/{id}")]
        [Permission(Access.Update)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<SpecialArticleModel>>> Update(string id, [FromBody] SpecialArticleUpdateModel specialArticleUpdateModel)
            => ActionResultFor(await _service.UpdateAsync(id, specialArticleUpdateModel));

        /// <summary>
        /// delete the special article with the given id
        /// </summary>
        /// <param name="id">the id of the special article to be deleted</param>
        /// <returns>an operation result object</returns>
        [HttpDelete("delete/{id}")]
        [Permission(Access.Delete)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result>> Delete(string id)
            => ActionResultFor(await _service.DeleteAsync(id));

        /// <summary>
        /// check designation of special article is unique
        /// </summary>
        /// <param name="name">the designation to check is unique</param>
        /// <returns></returns>
        [HttpGet("IsUnique/{name}")]
        [Permission(Access.Create)]
        [ProducesResponseType(200)]
        public async Task<ActionResult<Result<bool>>> IsUnique(string name)
            => ActionResultFor(await _service.IsUniqueAsync(name));
    }
}