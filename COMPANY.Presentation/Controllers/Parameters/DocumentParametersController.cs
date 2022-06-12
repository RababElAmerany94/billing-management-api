namespace COMPANY.Controllers.EntitiesControllers
{
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Enums;
    using COMPANY.Application.Models.BusinessEntitiesModels.DocumentParametersModels;
    using COMPANY.Application.Services.DataService.DocumentParametersService;
    using COMPANY.Domain.Enums.Authentification;
    using COMPANY.Presentation.Authorization;
    using COMPANY.Presentation.Controllers.Base;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Authorize]
    [Route("api/[controller]")]
    [Module(Modules.Parameters)]
    [ApiController]
    public class DocumentParametersController : BaseController
    {
        private readonly IDocumentParametersService _service;

        public DocumentParametersController(IDocumentParametersService service)
        {
            _service = service;
        }

        /// <summary>
        /// get the document parameters
        /// </summary>
        /// <returns>a paged result</returns>
        [HttpGet]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<DocumentParametersModel>>> Get()
            => ActionResultFor(await _service.GetDocumentParametersByIdAsync());

        /// <summary>
        /// create a new document parameters record
        /// </summary>
        /// <returns>the newly created document parameters</returns>
        [HttpPost("Create")]
        [Permission(Access.Create)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<DocumentParametersModel>>> Create(DocumentParametersCreateModel documentParametersCreateModel)
            => ActionResultFor(await _service.CreateDocumentParametersAsync(documentParametersCreateModel));

        /// <summary>
        /// update the document parameters with the given model
        /// </summary>
        /// <param name="id">the id of the document parameters to be updated</param>
        /// <param name="documentParametersUpdateModel">the update model</param>
        /// <returns>the updated document parameters</returns>
        [HttpPut("Update/{id}")]
        [Permission(Access.Update)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<DocumentParametersModel>>> Update(string id, [FromBody]DocumentParametersUpdateModel documentParametersUpdateModel)
            => ActionResultFor(await _service.UpdateDocumentParametersAsync(id, documentParametersUpdateModel));
    }
}