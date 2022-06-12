namespace COMPANY.Presentation.Controllers.Documents
{
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Enums;
    using COMPANY.Application.Models.BusinessEntities.Documents.Avoir;
    using COMPANY.Application.Models.BusinessEntitiesModels.DocumentParametersModels;
    using COMPANY.Application.Models.General.FilterOptions;
    using COMPANY.Application.Models.GeneralModels.BodiesModels.MailModels;
    using COMPANY.Application.Services.DataService.Documents;
    using COMPANY.Domain.Entities.OwnedEntities;
    using COMPANY.Domain.Enums.Authentification;
    using COMPANY.Presentation.Authorization;
    using COMPANY.Presentation.Controllers.Base;
    using COMPANY.Presistence.Implementations;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [Module(Modules.Avoir)]
    [ApiController]
    public class AvoirController : BaseController
    {
        private readonly IAvoirService _service;

        public AvoirController(IAvoirService service)
            => _service = service;

        /// <summary>
        /// get the list of avoirs as paged Result
        /// </summary>
        /// <param name="filterModel">the filter options</param>
        /// <returns>a paged result</returns>
        [HttpPost]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<PagedResult<AvoirModel>>> Get([FromBody] AvoirFilterOption filterModel)
            => ActionResultFor(await _service.GeAsPagedResultAsync(filterModel));

        /// <summary>
        /// get the avoir with the given id
        /// </summary>
        /// <param name="id">the id of the avoir to retrieve</param>
        /// <returns>the avoir</returns>
        [HttpGet("{id}")]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<AvoirModel>>> Get(string id)
            => ActionResultFor(await _service.GetByIdAsync(id));

        /// <summary>
        /// create a avoir using the AvoirCreateModel
        /// </summary>
        /// <param name="avoirModel">the model to create the avoir from it</param>
        /// <returns>the newly created avoir</returns>
        [HttpPost("Create")]
        [Permission(Access.Create)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<AvoirModel>>> Create([FromBody] AvoirCreateModel avoirModel)
            => ActionResultFor(await _service.CreateAsync(avoirModel));

        /// <summary>
        /// update the avoir with the given model
        /// </summary>
        /// <param name="id">the id of the avoir to be updated</param>
        /// <param name="avoirModel">the update model</param>
        /// <returns>the updated avoir</returns>
        [HttpPut("Update/{id}")]
        [Permission(Access.Update)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<AvoirModel>>> Update(string id, [FromBody] AvoirUpdateModel avoirModel)
            => ActionResultFor(await _service.UpdateAsync(id, avoirModel));

        /// <summary>
        /// delete the avoir with the given id
        /// </summary>
        /// <param name="id">the id of the avoir to be deleted</param>
        /// <returns>a result object</returns>
        [HttpDelete("Delete/{id}")]
        [Permission(Access.Delete)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result>> Delete(string id)
            => ActionResultFor(await _service.DeleteAsync(id));

        /// <summary>
        /// save the given memo to the avoir with the given id
        /// </summary>
        /// <param name="id">the id of the avoir to save the memo for it</param>
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
        /// generate PDF Avoir
        /// </summary>
        /// <returns>the result object</returns>
        [HttpGet("GeneratePDF/{id}")]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<byte[]>>> GeneratePDF(string id)
            => ActionResultFor(await _service.GeneratePdfAvoirAsync(id));

        /// <summary>
        /// example generate PDF avoir
        /// </summary>
        /// <returns>the result object</returns>
        [HttpPost("ExampleGeneratePDF")]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ActionResult<Result<byte[]>> ExampleGeneratePDF([FromBody] DocumentParametersModel documentParametersModel)
            => ActionResultFor(_service.ExampleAvoirPdfAsync(documentParametersModel));

        /// <summary>
        /// send avoir in email
        /// </summary>
        /// <param name="avoirId">the id of facture</param>
        /// <param name="mailModel">the mail model</param>
        /// <returns></returns>
        [HttpPost("SendEmail/{factureId}")]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<ICollection<MailHistoryModel>>>> SendEmail(string avoirId, [FromBody] MailModel mailModel)
            => ActionResultFor(await _service.SendAvoirInEmail(avoirId, mailModel));

    }
}
