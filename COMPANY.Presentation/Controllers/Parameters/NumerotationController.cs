namespace COMPANY.Controllers.EntitiesControllers
{
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Enums;
    using COMPANY.Application.Models.BusinessEntities.Documents.DocumentComptable;
    using COMPANY.Application.Models.BusinessEntitiesModels.NumerotationModels;
    using COMPANY.Application.Models.GeneralModels.PagingModels;
    using COMPANY.Application.Services.DataService.NumerotationService;
    using COMPANY.Domain.Enums;
    using COMPANY.Domain.Enums.Authentification;
    using COMPANY.Presentation.Authorization;
    using COMPANY.Presentation.Controllers.Base;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Authorize]
    [Route("api/[controller]")]
    [Module(Modules.Parameters)]
    [ApiController]
    public class NumerotationController : BaseController
    {
        private readonly INumerotationService _service;

        public NumerotationController(INumerotationService service)
         => _service = service ?? throw new ArgumentNullException(nameof(service));

        /// <summary>
        /// get the list of all Numerotations
        /// </summary>
        [HttpGet]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<IEnumerable<NumerotationModel>>>> Get()
            => ActionResultFor(await _service.GetAllNumerotationAsync());

        /// <summary>
        /// get the client with the given id
        /// </summary>
        /// <param name="id">the id of the numerotation to retrieve</param>
        /// <returns>the client</returns>
        [HttpGet("{id}")]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<NumerotationModel>>> Get(string id)
            => ActionResultFor(await _service.GetNumerotationByIdAsync(id));

        /// <summary>
        /// create a client using the NumerotationCreateModel
        /// </summary>
        /// <param name="clientModel">the model to create the client from it</param>
        /// <returns>the newly created client</returns>
        [HttpPost("Create")]
        [Permission(Access.Create)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<NumerotationModel>>> Create([FromBody] NumerotationCreateModel clientModel)
            => ActionResultFor(await _service.CreateNumerotationAsync(clientModel));

        /// <summary>
        /// update the client with the given model
        /// </summary>
        /// <param name="id">the id of the client to be updated</param>
        /// <param name="clientModel">the update model</param>
        /// <returns>the updated client</returns>
        [HttpPut("Update/{id}")]
        [Permission(Access.Update)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<NumerotationModel>>> Update(string id, [FromBody] NumerotationUpdateModel clientModel)
            => ActionResultFor(await _service.UpdateNumerotationAsync(id, clientModel));

        /// <summary>
        /// generate the numerotation with the given type
        /// </summary>
        /// <param name="type">the type of the numerotation to retrieve</param>
        /// <returns>the numerotation</returns>
        [HttpGet("Generate/{type}")]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<string>>> GenerateNumerotation(NumerotationType type)
            => ActionResultFor(await _service.GenerateNumerotationAsync(type));

        /// <summary>
        /// generate reference for accounting documents
        /// </summary>
        /// <param name="filterOption">the filter option</param>
        /// <returns>the result</returns>
        [HttpPost("GenerateReferenceDocumentComptable")]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<ReferenceDocumentComptable>>> GenerateReferenceDocumentComptable(NumerotationDocumentComptableFilterOption filterOption)
            => ActionResultFor(await _service.GenerateReferenceDocumentComptable(filterOption.DateCreation, filterOption.Type));
    }
}