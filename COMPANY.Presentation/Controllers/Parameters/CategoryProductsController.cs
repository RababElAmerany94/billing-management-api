namespace COMPANY.Controllers.EntitiesControllers
{
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Enums;
    using COMPANY.Application.Models;
    using COMPANY.Application.Models.BusinessEntitiesModels.CategoryProductModels;
    using COMPANY.Application.Services.DataService.CategoryProductService;
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
    [Module(Modules.CategoryProduct)]
    [ApiController]
    public class CategoryProductsController : BaseController
    {
        private readonly ICategoryProductService _service;

        public CategoryProductsController(
            ICategoryProductService service
        ) => _service = service;

        /// <summary>
        /// get the list of all category products
        /// </summary>
        [HttpGet]
        [Permission(Access.Read)]
        public async Task<ActionResult<IEnumerable<CategoryProductModel>>> Get()
            => Ok(await _service.GetAllAsync());

        /// <summary>
        /// get the list of category products as paged Result
        /// </summary>
        /// <param name="filterModel">the filter options</param>
        /// <returns>a paged result</returns>
        [HttpPost]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<PagedResult<CategoryProductModel>>> Get([FromBody]FilterOption filterModel)
            => ActionResultFor(await _service.GeAsPagedResultAsync(filterModel));

        /// <summary>
        /// create a new category product record
        /// </summary>
        /// <returns>the newly created categoryProduct</returns>
        [HttpPost("create")]
        [Permission(Access.Create)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<CategoryProductModel>>> Create(CategoryProductCreateModel categoryProductCreateModel)
            => ActionResultFor(await _service.CreateAsync(categoryProductCreateModel));

        /// <summary>
        /// update the category product with the given model
        /// </summary>
        /// <param name="id">the id of the business origin to be updated</param>
        /// <param name="categoryProductUpdateModel">the update model</param>
        /// <returns>the updated category product</returns>
        [HttpPut("Update/{id}")]
        [Permission(Access.Update)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<CategoryProductModel>>> Update(string id, [FromBody]CategoryProductUpdateModel categoryProductUpdateModel)
            => ActionResultFor(await _service.UpdateAsync(id, categoryProductUpdateModel));

        /// <summary>
        /// delete the category product with the given id
        /// </summary>
        /// <param name="id">the id of the category product to be deleted</param>
        /// <returns>an operation result object</returns>
        [HttpDelete("delete/{id}")]
        [Permission(Access.Delete)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result>> Delete(string id)
            => ActionResultFor(await _service.DeleteAsync(id));

        /// <summary>
        /// check name of category product is unique
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