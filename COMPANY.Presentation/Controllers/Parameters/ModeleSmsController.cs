namespace COMPANY.Presentation.Controllers.Parameters
{
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Enums;
    using COMPANY.Application.Models;
    using COMPANY.Application.Models.BusinessEntities.Parameters.ModeleSms;
    using COMPANY.Application.Services.DataService.Parameters.ModeleSmsService;
    using COMPANY.Domain.Enums.Authentification;
    using COMPANY.Presentation.Authorization;
    using COMPANY.Presentation.Controllers.Base;
    using COMPANY.Presistence.Implementations;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [Module(Modules.ModeleSms)]
    [ApiController]
    public class ModeleSmsController : BaseController
    {
        private readonly IModeleSmsService _service;

        public ModeleSmsController(IModeleSmsService service)
            => _service = service;

        /// <summary>
        /// get the list of all Modele Sms
        /// </summary>
        [HttpGet]
        [Permission(Access.Read)]
        public async Task<ActionResult<IEnumerable<ModeleSmsModel>>> Get()
            => Ok(await _service.GetAllAsync());

        /// <summary>
        /// get the list of Modele Sms as paged Result
        /// </summary>
        /// <param name="filterOption">the filter options</param>
        /// <returns>a paged result</returns>
        [HttpPost]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<PagedResult<ModeleSmsModel>>> Get([FromBody] FilterOption filterOption)
            => ActionResultFor(await _service.GeAsPagedResultAsync(filterOption));

        /// <summary>
        /// create a new Modele Sms record
        /// </summary>
        /// <returns>the newly created Modele Sms</returns>
        [HttpPost("create")]
        [Permission(Access.Create)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<ModeleSmsModel>>> Create(ModeleSmsCreateModel ModeleSmsCreateModel)
            => ActionResultFor(await _service.CreateAsync(ModeleSmsCreateModel));

        /// <summary>
        /// update the Modele Sms with the given model
        /// </summary>
        /// <param name="id">the id of the Modele Sms to be updated</param>
        /// <param name="modeleSmsUpdateModel">the update model</param>
        /// <returns>the updated Modele Sms</returns>
        [HttpPut("Update/{id}")]
        [Permission(Access.Update)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<ModeleSmsModel>>> Update(string id, [FromBody] ModeleSmsUpdateModel modeleSmsUpdateModel)
            => ActionResultFor(await _service.UpdateAsync(id, modeleSmsUpdateModel));

        /// <summary>
        /// delete the unite with the given id
        /// </summary>
        /// <param name="id">the id of the Modele Sms to be deleted</param>
        /// <returns>an operation result object</returns>
        [HttpDelete("delete/{id}")]
        [Permission(Access.Delete)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result>> Delete(string id)
            => ActionResultFor(await _service.DeleteAsync(id));
        /// <summary>
        /// check name of Modele Sms is unique
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