namespace COMPANY.Controllers
{
    using Application.Models;
    using Application.Services.DataService;
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Enums;
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
    [Module(Modules.Fournisseurs)]
    [ApiController]
    public class FournisseursController : BaseController
    {
        private readonly IFournisseurService _service;

        public FournisseursController(IFournisseurService service)
            => _service = service;

        /// <summary>
        /// get the list of all founisseurs
        /// </summary>
        [HttpGet]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<IEnumerable<FournisseurModel>>>> Get()
            => ActionResultFor(await _service.GetAllAsync());

        /// <summary>
        /// get the list of founisseurs as paged Result
        /// </summary>
        /// <param name="filterModel">the filter options</param>
        /// <returns>a paged result</returns>
        [HttpPost]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<PagedResult<FournisseurModel>>> Get([FromBody] FilterOption filterModel)
            => ActionResultFor(await _service.GeAsPagedResultAsync(filterModel));

        /// <summary>
        /// get the founisseur with the given id
        /// </summary>
        /// <param name="id">the id of the founisseur to retrieve</param>
        /// <returns>the Supplier</returns>
        [HttpGet("{id}")]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]

        public async Task<ActionResult<Result<FournisseurModel>>> Get(string id)
            => ActionResultFor(await _service.GetByIdAsync(id));

        /// <summary>
        /// create a founrisseur using the FournisseurCreateModel
        /// </summary>
        /// <param name="createModel">the model to create the founisseur from it</param>
        /// <returns>the newly created founisseur</returns>
        [HttpPost("Create")]
        [Permission(Access.Create)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<FournisseurModel>>> Create([FromBody] FournisseurCreateModel createModel)
            => ActionResultFor(await _service.CreateAsync(createModel));

        /// <summary>
        /// update the founisseur with the given model
        /// </summary>
        /// <param name="id">the id of the founisseur to be updated</param>
        /// <param name="updateModel">the update model</param>
        /// <returns>the updated Supplier</returns>
        [HttpPut("Update/{id}")]
        [Permission(Access.Update)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<FournisseurModel>>> Update(string id, [FromBody] FournisseurUpdateModel updateModel)
            => ActionResultFor(await _service.UpdateAsync(id, updateModel));

        /// <summary>
        /// delete the founisseur with the given id
        /// </summary>
        /// <param name="id">the id of the Supplier to be deleted</param>
        /// <returns>a result object</returns>
        [HttpDelete("Delete/{id}")]
        [Permission(Access.Delete)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result>> Delete(string id)
            => ActionResultFor(await _service.DeleteAsync(id));

        /// <summary>
        /// export the list of I as an excel format
        /// </summary>
        /// <returns>the result object</returns>
        [HttpGet("ExporterExcel")]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<byte[]>>> ExporterExcel()
            => ActionResultFor(await _service.ExportFournisseurListAsExcelAsync());

        /// <summary>
        /// check if the given reference is unique, returns true if unique, false if not
        /// </summary>
        /// <param name="reference">the reference to be checked</param>
        /// <returns>true if unique, false if not</returns>
        [HttpGet("CheckUniqueReference/{reference}")]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<bool>>> CheckUniqueReference(string reference)
            => ActionResultFor(await _service.CheckUniqueReferenceAsync(reference));
    }
}