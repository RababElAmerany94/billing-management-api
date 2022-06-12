namespace COMPANY.Presentation.Controllers.EntitiesControllers
{
    using COMPANY.Application.Data.Enums;
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Enums;
    using COMPANY.Application.Models;
    using COMPANY.Application.Models.BusinessEntitiesModels.CategoryDocumentsModels;
    using COMPANY.Application.Services.DataService.CategoryDocumentsService;
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
    public class CategoryDocumentsController : BaseController
    {
        private readonly ICategoryDocumentsService _service;

        public CategoryDocumentsController(
            ICategoryDocumentsService service
        ) => _service = service;

        /// <summary>
        /// get the list of all category documents
        /// </summary>
        [HttpGet]
        [Permission(Access.Read)]
        public async Task<ActionResult<IEnumerable<CategoryDocumentModel>>> Get()
            => Ok(await _service.GetAllAsync());

        /// <summary>
        /// get the list of category documents as paged Result
        /// </summary>
        /// <param name="filterModel">the filter options</param>
        /// <returns>a paged result</returns>
        [HttpPost]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<PagedResult<CategoryDocumentModel>>> Get([FromBody]FilterOption filterModel)
            => ActionResultFor(await _service.GeAsPagedResultAsync(filterModel));

        /// <summary>
        /// create a new category document record
        /// </summary>
        /// <param name="categoryDocumentCreateModel">the model to create the category document from it</param>
        /// <returns>the newly created categoryDocuments</returns>
        [HttpPost("create")]
        [Permission(Access.Create)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<CategoryDocumentModel>>> Create(CategoryDocumentCreateModel categoryDocumentCreateModel)
             => ActionResultFor(await _service.CreateAsync(categoryDocumentCreateModel));

        /// <summary>
        /// update the category document with the given model
        /// </summary>
        /// <param name="id">the id of the document to be updated</param>
        /// <param name="categoryDocumentUpdateModel">the update model</param>
        /// <returns>the updated category document</returns>
        [HttpPut("Update/{id}")]
        [Permission(Access.Update)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<CategoryDocumentModel>>> Update(string id, [FromBody]CategoryDocumentUpdateModel categoryDocumentUpdateModel)
             => ActionResultFor(await _service.UpdateAsync(id, categoryDocumentUpdateModel));

        /// <summary>
        /// delete the category document with the given id
        /// </summary>
        /// <param name="id">the id of the category document to be deleted</param>
        /// <returns>an operation result object</returns>
        [HttpDelete("delete/{id}")]
        [Permission(Access.Delete)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result>> Delete(string id)
            => ActionResultFor(await _service.DeleteAsync(id));

        /// <summary>
        /// check name of category document is unique
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