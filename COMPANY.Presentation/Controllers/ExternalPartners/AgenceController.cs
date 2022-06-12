namespace COMPANY.Presentation.Controllers
{
    using Application.Models;
    using Application.Services.DataService;
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Enums;
    using COMPANY.Application.Models.BusinessEntities.ExternalPartners.Agence;
    using COMPANY.Domain.Entities.OwnedEntities;
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
    [Module(Modules.Agences)]
    [ApiController]
    public class AgenceController : BaseController
    {
        private readonly IAgenceService _service;

        public AgenceController(
            IAgenceService service)
        {
            _service = service;
        }

        /// <summary>
        /// get all the list of agences
        /// </summary>
        /// <returns>list of agences</returns>
        [HttpGet]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<IEnumerable<AgenceModel>>>> Get()
            => ActionResultFor(await _service.GetAllAsync());

        /// <summary>
        /// get the list of Agence as paged Result
        /// </summary>
        /// <param name="filterModel">the filter options</param>
        /// <returns>a paged result</returns>
        [HttpPost]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<PagedResult<AgenceModel>>> Get([FromBody] FilterOption filterModel)
            => ActionResultFor(await _service.GeAsPagedResultAsync(filterModel));

        /// <summary>
        /// get the agence by the given id
        /// </summary>
        /// <param name="id">the id of the agence</param>
        /// <returns>one agence base of his id</returns>
        [HttpGet("{id}")]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<AgenceModel>>> Get(string id)
            => ActionResultFor(await _service.GetByIdAsync(id));

        /// <summary>
        /// create a new agence record
        /// </summary>
        /// <returns>the newly created agence</returns>
        [HttpPost("create")]
        [Permission(Access.Create)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<AgenceModel>>> Create(AgenceCreateModel agenceModel)
            => ActionResultFor(await _service.CreateAsync(agenceModel));

        /// <summary>
        /// update the agence with the given model
        /// </summary>
        /// <param name="id">the id of the agence to be updated</param>
        /// <param name="AgenceModel">the update model</param>
        /// <returns>the updated agence</returns>
        [HttpPut("Update/{id}")]
        [Permission(Access.Update)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<AgenceModel>>> Update(string id, [FromBody] AgenceUpdateModel AgenceModel)
            => ActionResultFor(await _service.UpdateAsync(id, AgenceModel));

        /// <summary>
        /// delete the agence with the given id
        /// </summary>
        /// <param name="id">the id of the agence to be deleted</param>
        /// <returns>an operation result object</returns>
        [HttpDelete("delete/{id}")]
        [Permission(Access.Delete)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result>> Delete(string id)
            => ActionResultFor(await _service.DeleteAsync(id));

        /// <summary>
        /// save the given memo to the Agence with the given id
        /// </summary>
        /// <param name="id">the id of the Agence to save the memo for it</param>
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
        /// export the list of Agences as an excel format
        /// </summary>
        /// <returns>the result object</returns>
        [HttpGet("ExporterExcel")]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<byte[]>>> ExporterExcel()
            => ActionResultFor(await _service.ExportAgencesListAsExcelAsync());

        /// <summary>
        /// create a login for the Agence
        /// </summary>
        /// <param name="loginModel">the login model</param>
        /// <returns></returns>
        [HttpPost("CreateLogin")]
        [Permission(Access.ManipulationLogin)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<UserModel>>> CreateLogin([FromBody] CreateLoginModel loginModel)
            => ActionResultFor(await _service.CreateLoginForAgenceAsync(loginModel));
        
        /// <summary>
        /// get the login of given agence
        /// </summary>
        /// <param name="id">the agence to retrieve the login for it</param>
        /// <returns>the user model of the agence</returns>
        [HttpPost("GetLogin/{id}")]
        [Permission(Access.ManipulationLogin)]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<UserModel>>> GetLogin(string id)
            => ActionResultFor(await _service.GetAgenceLoginAsync(id));

        /// <summary>
        /// delete the login for the agence with the given id
        /// </summary>
        /// <param name="id">the id of the agence to delete the login for it</param>
        /// <returns>the user model of the agence</returns>
        [HttpDelete("DeleteLogin/{id}")]
        [Permission(Access.ManipulationLogin)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result>> DeleteLogin(string id)
            => ActionResultFor(await _service.DeleteLoginForAgenceAsync(id));

        /// <summary>
        /// change activation of agence
        /// </summary>
        /// <param name="changeActivationAgenceModel">the change visibility model</param>
        /// <returns>a activation of agence</returns>
        [HttpPost("ChangeActivateAgence")]
        [Permission(Access.Update)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<bool>>> Create([FromBody] ChangeActivationAgenceModel changeActivationAgenceModel)
            => ActionResultFor(await _service.ChangeActivateAgence(changeActivationAgenceModel));
        
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
