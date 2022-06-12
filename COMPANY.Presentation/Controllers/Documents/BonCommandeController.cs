namespace COMPANY.Presentation.Controllers.Documents
{
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Enums;
    using COMPANY.Application.Models;
    using COMPANY.Application.Models.BusinessEntities.Documents.BonCommande;
    using COMPANY.Application.Models.BusinessEntitiesModels.DocumentParametersModels;
    using COMPANY.Application.Models.GeneralModels.BodiesModels.MailModels;
    using COMPANY.Application.Models.Generals.FilterOptions;
    using COMPANY.Application.Services.DataService.Documents.BonCommandeService;
    using COMPANY.Domain.Entities.OwnedEntities;
    using COMPANY.Domain.Enums.Authentification;
    using COMPANY.Presentation.Authorization;
    using COMPANY.Presentation.Controllers.Base;
    using COMPANY.Presistence.Implementations;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [Module(Modules.BonCommande)]
    [ApiController]
    public class BonCommandeController : BaseController
    {
        private readonly IBonCommandeService _service;

        public BonCommandeController(IBonCommandeService service)
            => _service = service;

        /// <summary>
        /// get the list of bon commande as paged Result
        /// </summary>
        /// <param name="filterOption">the filter options</param>
        /// <returns>a paged result</returns>
        [HttpPost]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<PagedResult<BonCommandeModel>>> Get([FromBody] BonCommandeFilterOption filterOption)
            => ActionResultFor(await _service.GeAsPagedResultAsync(filterOption));

        /// <summary>
        /// get the bon commande with the given id
        /// </summary>
        /// <param name="id">the id of the bon commande to retrieve</param>
        /// <returns>the bon commande</returns>
        [HttpGet("{id}")]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<BonCommandeModel>>> Get(string id)
            => ActionResultFor(await _service.GetByIdAsync(id));

        /// <summary>
        /// create a bon commande using the BonCommandeCreateModel
        /// </summary>
        /// <param name="model">the model to create the bon commande from it</param>
        /// <returns>the newly created bon commande</returns>
        [HttpPost("Create")]
        [Permission(Access.Create)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<BonCommandeModel>>> Create([FromBody] BonCommandeCreateModel model)
             => ActionResultFor(await _service.CreateAsync(model));

        /// <summary>
        /// update the bon commande with the given model
        /// </summary>
        /// <param name="id">the id of the bon commande to be updated</param>
        /// <param name="model">the update model</param>
        /// <returns>the updated bon commande</returns>
        [HttpPut("Update/{id}")]
        [Permission(Access.Update)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<BonCommandeModel>>> Update(string id, [FromBody] BonCommandeUpdateModel model)
            => ActionResultFor(await _service.UpdateAsync(id, model));

        /// <summary>
        /// delete the bon commande with the given id
        /// </summary>
        /// <param name="id">the id of the bon commande to be deleted</param>
        /// <returns>a result object</returns>
        [HttpDelete("Delete/{id}")]
        [Permission(Access.Delete)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result>> Delete(string id)
            => ActionResultFor(await _service.DeleteAsync(id));

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

        /// <summary>
        /// generate PDF
        /// </summary>
        /// <returns>the result object</returns>
        [HttpGet("GeneratePDF/{id}")]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<byte[]>>> GeneratePDF(string id)
            => ActionResultFor(await _service.GeneratePdf(id));

        /// <summary>
        /// example generate PDF bon commande
        /// </summary>
        /// <returns>the result object</returns>
        [HttpPost("ExampleGeneratePDF")]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ActionResult<Result<byte[]>> ExampleGeneratePDF([FromBody] DocumentParametersModel model)
            => ActionResultFor(_service.ExampleParametersModel(model));

        /// <summary>
        /// send bon commande in email
        /// </summary>
        /// <param name="bonCommandeId">the id of bon commande</param>
        /// <param name="mailModel">the mail model</param>
        /// <returns></returns>
        [HttpPost("SendEmail/{bonCommandeId}")]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<ICollection<MailHistoryModel>>>> SendEmail(string bonCommandeId, [FromBody] MailModel mailModel)
            => ActionResultFor(await _service.SendInEmail(bonCommandeId, mailModel));
    }
}
