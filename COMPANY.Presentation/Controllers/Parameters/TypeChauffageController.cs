namespace COMPANY.Presentation.Controllers.Parameters
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Enums;
    using COMPANY.Application.Models;
    using COMPANY.Application.Models.BusinessEntities.Parameters.TypeChauffage;
    using COMPANY.Application.Services.DataService.Parameters.TypeChauffageService;
    using COMPANY.Domain.Enums.Authentification;
    using COMPANY.Presentation.Authorization;
    using COMPANY.Presentation.Controllers.Base;
    using COMPANY.Presistence.Implementations;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [Module(Modules.TypeChauffage)]
    [ApiController]
    public class TypeChauffageController : BaseController
    {
        private readonly ITypeChauffageService _service;

        public TypeChauffageController(ITypeChauffageService service)
            => _service = service;

        /// <summary>
        /// get the list of all chauffage type
        /// </summary>
        [HttpGet]
        [Permission(Access.Read)]
        public async Task<ActionResult<IEnumerable<TypeChauffageModel>>> Get()
            => Ok(await _service.GetAllAsync());

        /// <summary>
        /// get the list of chauffage type as paged Result
        /// </summary>
        /// <param name="filterOption">the filter options</param>
        /// <returns>a paged result</returns>
        [HttpPost]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<PagedResult<TypeChauffageModel>>> Get([FromBody] FilterOption filterOption)
            => ActionResultFor(await _service.GeAsPagedResultAsync(filterOption));

        /// <summary>
        /// create a new chauffage type record
        /// </summary>
        /// <returns>the newly created chauffage type</returns>
        [HttpPost("create")]
        [Permission(Access.Create)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<TypeChauffageModel>>> Create(TypeChauffageCreateModel chauffageTypeCreateModel)
            => ActionResultFor(await _service.CreateAsync(chauffageTypeCreateModel));

        /// <summary>
        /// update the chauffage type with the given model
        /// </summary>
        /// <param name="id">the id of the chauffage type to be updated</param>
        /// <param name="chauffageTypeUpdateModel">the update model</param>
        /// <returns>the updated chauffage type</returns>
        [HttpPut("Update/{id}")]
        [Permission(Access.Update)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<TypeChauffageModel>>> Update(string id, [FromBody] TypeChauffageUpdateModel chauffageTypeUpdateModel)
            => ActionResultFor(await _service.UpdateAsync(id, chauffageTypeUpdateModel));

        /// <summary>
        /// delete the unite with the given id
        /// </summary>
        /// <param name="id">the id of the chauffage type to be deleted</param>
        /// <returns>an operation result object</returns>
        [HttpDelete("delete/{id}")]
        [Permission(Access.Delete)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result>> Delete(string id)
            => ActionResultFor(await _service.DeleteAsync(id));

        /// <summary>
        /// check name of chauffage type is unique
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