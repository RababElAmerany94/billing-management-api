namespace COMPANY.Presentation.Controllers.Documents
{
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Enums;
    using COMPANY.Application.Models.BusinessEntities.Documents.Facture;
    using COMPANY.Application.Models.BusinessEntitiesModels.DocumentParametersModels;
    using COMPANY.Application.Models.General.FilterOptions;
    using COMPANY.Application.Models.GeneralModels.BodiesModels.MailModels;
    using COMPANY.Application.Services.DataService.Documents.FactureService;
    using COMPANY.Domain.Entities.OwnedEntities;
    using COMPANY.Domain.Enums.Authentification;
    using COMPANY.Presentation.Authorization;
    using COMPANY.Presentation.Controllers.Base;
    using COMPANY.Presistence.Implementations;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [Module(Modules.Facture)]
    [ApiController]
    public class FactureController : BaseController
    {
        private readonly IFactureService _service;

        public FactureController(IFactureService service)
        {
            _service = service;
        }

        /// <summary>
        /// get the list of factures as paged Result
        /// </summary>
        /// <param name="filterModel">the filter options</param>
        /// <returns>a paged result</returns>
        [HttpPost]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<PagedResult<FactureModel>>> Get([FromBody] FactureFilterOption filterModel)
            => ActionResultFor(await _service.GeAsPagedResultAsync(filterModel));

        /// <summary>
        /// get the facture with the given id
        /// </summary>
        /// <param name="id">the id of the facture to retrieve</param>
        /// <returns>the facture</returns>
        [HttpGet("{id}")]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<FactureModel>>> Get(string id)
            => ActionResultFor(await _service.GetByIdAsync(id));

        /// <summary>
        /// create a facture using the Facture Create Model
        /// </summary>
        /// <param name="factureModel">the model to create the facture from it</param>
        /// <returns>the newly created facture</returns>
        [HttpPost("Create")]
        [Permission(Access.Create)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<FactureModel>>> Create([FromBody] FactureCreateModel factureModel)
            => ActionResultFor(await _service.CreateAsync(factureModel));

        /// <summary>
        /// update the facture with the given model
        /// </summary>
        /// <param name="id">the id of the facture to be updated</param>
        /// <param name="factureModel">the update model</param>
        /// <returns>the updated facture</returns>
        [HttpPut("Update/{id}")]
        [Permission(Access.Update)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<FactureModel>>> Update(string id, [FromBody] FactureUpdateModel factureModel)
            => ActionResultFor(await _service.UpdateAsync(id, factureModel));

        /// <summary>
        /// delete the facture with the given id
        /// </summary>
        /// <param name="id">the id of the facture to be deleted</param>
        /// <returns>a result object</returns>
        [HttpDelete("Delete/{id}")]
        [Permission(Access.Delete)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result>> Delete(string id)
            => ActionResultFor(await _service.DeleteAsync(id));

        /// <summary>
        /// save the given memo to the facture with the given id
        /// </summary>
        /// <param name="id">the id of the facture to save the memo for it</param>
        /// <param name="memos">the memo to be saved</param>
        /// <returns>a result object</returns>
        [HttpPost("Memos/Save/{id}")]
        [Permission(Access.Create)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result>> SaveMemos(string id, [FromBody] ICollection<Memo> memos)
            => ActionResultFor(await _service.SaveMemosAsync(id, memos));

        /// <summary>
        /// cancel facture
        /// </summary>
        /// <param name="id">the id of the facture to cancel</param>
        /// <returns>a result object</returns>
        [HttpGet("Cancel/{id}")]
        [Permission(Access.Update)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<FactureModel>>> CancelFacture(string id)
            => ActionResultFor(await _service.CancelFacture(id));

        /// <summary>
        /// generate PDF Facture
        /// </summary>
        /// <returns>the result object</returns>
        [HttpGet("GeneratePDF/{id}")]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<byte[]>>> GeneratePDF(string id)
            => ActionResultFor(await _service.GeneratePdfFactureAsync(id));

        /// <summary>
        /// example generate PDF facture
        /// </summary>
        /// <returns>the result object</returns>
        [HttpPost("ExampleGeneratePDF")]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ActionResult<Result<byte[]>> ExampleGeneratePDF([FromBody] DocumentParametersModel documentParametersModel)
            => ActionResultFor(_service.ExampleFacturePdfAsync(documentParametersModel));

        /// <summary>
        /// send facture in email
        /// </summary>
        /// <param name="factureId">the id of facture</param>
        /// <param name="mailModel">the mail model</param>
        /// <returns></returns>
        [HttpPost("SendEmail/{factureId}")]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<ICollection<MailHistoryModel>>>> SendEmail(string factureId, [FromBody] MailModel mailModel)
            => ActionResultFor(await _service.SendFactureInEmail(factureId, mailModel));

        /// <summary>
        /// export releve factures format PDF
        /// </summary>
        /// <param name="filterOption">the filter option</param>
        /// <returns>a result instant</returns>
        [HttpPost("ExportReleveFacturesPDF")]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<ExportReleveFacturesModel>>> ExportReleveFacturesPDF([FromBody] ReleveFacturesFilterOption filterOption)
         => ActionResultFor(await _service.ExportReleveFacturesPDFAsync(filterOption));

    }
}
