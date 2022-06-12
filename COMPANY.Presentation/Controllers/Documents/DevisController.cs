namespace COMPANY.Presentation.Controllers.Documents
{
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Enums;
    using COMPANY.Application.Models.BusinessEntities.Documents.Devis;
    using COMPANY.Application.Models.BusinessEntitiesModels.DocumentParametersModels;
    using COMPANY.Application.Models.BusinessEntitiesModels.Documents.Devis;
    using COMPANY.Application.Models.General.FilterOptions;
    using COMPANY.Application.Models.GeneralModels.BodiesModels.MailModels;
    using COMPANY.Application.Services.DataService.DevisService;
    using COMPANY.Domain.Entities.OwnedEntities;
    using COMPANY.Domain.Enums.Authentification;
    using COMPANY.Presentation.Authorization;
    using COMPANY.Presentation.Controllers.Base;
    using COMPANY.Presistence.Implementations;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [Module(Modules.Devis)]
    [ApiController]
    public class DevisController : BaseController
    {
        private readonly IDevisService _service;

        public DevisController(IDevisService service) => _service = service;

        /// <summary>
        /// get the list of devis as paged Result
        /// </summary>
        /// <param name="filterModel">the filter options</param>
        /// <returns>a paged result</returns>
        [HttpPost]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<PagedResult<DevisModel>>> Get([FromBody] DevisFilterOption filterModel)
            => ActionResultFor(await _service.GeAsPagedResultAsync(filterModel));

        /// <summary>
        /// get the devis with the given id
        /// </summary>
        /// <param name="id">the id of the devis to retrieve</param>
        /// <returns>the devis</returns>
        [HttpGet("{id}")]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<DevisModel>>> Get(string id)
            => ActionResultFor(await _service.GetByIdAsync(id));

        /// <summary>
        /// create a devis using the ClientCreateModel
        /// </summary>
        /// <param name="devisModel">the model to create the devis from it</param>
        /// <returns>the newly created devis</returns>
        [HttpPost("Create")]
        [Permission(Access.Create)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<DevisModel>>> Create([FromBody]DevisCreateModel devisModel)
             => ActionResultFor(await _service.CreateAsync(devisModel));

        /// <summary>
        /// update the devis with the given model
        /// </summary>
        /// <param name="id">the id of the devis to be updated</param>
        /// <param name="devisModel">the update model</param>
        /// <returns>the updated devis</returns>
        [HttpPut("Update/{id}")]
        [Permission(Access.Update)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<DevisModel>>> Update(string id, [FromBody]DevisUpdateModel devisModel)
            => ActionResultFor(await _service.UpdateAsync(id, devisModel));

        /// <summary>
        /// delete the devis with the given id
        /// </summary>
        /// <param name="id">the id of the devis to be deleted</param>
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
        /// generate PDF pdf
        /// </summary>
        /// <returns>the result object</returns>
        [HttpGet("GeneratePDF/{id}")]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<byte[]>>> GeneratePDF(string id)
            => ActionResultFor(await _service.GeneratePDFDevis(id));

        /// <summary>
        /// example generate PDF devis
        /// </summary>
        /// <returns>the result object</returns>
        [HttpPost("ExampleGeneratePDF")]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ActionResult<Result<byte[]>> ExampleGeneratePDF([FromBody] DocumentParametersModel documentParametersModel)
            => ActionResultFor(_service.ExampleDevisParametersModel(documentParametersModel));

        /// <summary>
        /// send devis in email
        /// </summary>
        /// <param name="devisId">the id of devis</param>
        /// <param name="mailModel">the mail model</param>
        /// <returns></returns>
        [HttpPost("SendEmail/{devisId}")]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<ICollection<MailHistoryModel>>>> SendEmail(string devisId, [FromBody]MailModel mailModel)
            => ActionResultFor(await _service.SendDevisInEmail(devisId, mailModel));

        /// <summary>
        /// sign a devis
        /// </summary>
        /// <param name="devisSignature">the devis signature model</param>
        /// <returns>a devis result</returns>
        [HttpPost("SignDevis")]
        [Permission(Access.Update)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<DevisModel>>> SignDevis([FromBody] DevisSignatureModel devisSignature)
            => ActionResultFor(await _service.SignDevis(devisSignature));
    }

}
