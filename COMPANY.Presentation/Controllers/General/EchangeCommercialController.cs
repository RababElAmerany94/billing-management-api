namespace COMPANY.Presentation.Controllers.EntitiesControllers
{
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Enums;
    using COMPANY.Application.Models.BusinessEntities.General.EchangeCommercial;
    using COMPANY.Application.Models.GeneralModels.PagingModels;
    using COMPANY.Application.Services.DataService.TacheService;
    using COMPANY.Domain.Entities.OwnedEntities;
    using COMPANY.Domain.Enums.Authentification;
    using COMPANY.Presentation.Authorization;
    using COMPANY.Presentation.Controllers.Base;
    using COMPANY.Presistence.Implementations;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Authorize]
    [Route("api/[controller]")]
    [Module(Modules.AgendaCommercial)]
    [ApiController]
    public class EchangeCommercialController : BaseController
    {
        private readonly IEchangeCommercialService _service;

        public EchangeCommercialController(IEchangeCommercialService service)
            => _service = service;

        /// <summary>
        /// get the list of commercial exchange paged Result
        /// </summary>
        /// <param name="filterModel">the filter options</param>
        /// <returns>a paged result</returns>
        [HttpPost]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<PagedResult<EchangeCommercialModel>>> Get([FromBody] EchangeCommercialFilterOption filterModel)
            => ActionResultFor(await _service.GeAsPagedResultAsync(filterModel));

        /// <summary>
        /// get the commercial exchange with the given id
        /// </summary>
        /// <param name="id">the id of the commercial exchange to retrieve</param>
        /// <returns>the commercial exchange</returns>
        [HttpGet("{id}")]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<EchangeCommercialModel>>> Get(string id)
            => ActionResultFor(await _service.GetByIdAsync(id));

        /// <summary>
        /// create a new commercial exchange record
        /// </summary>
        /// <param name="createModel">the create model</param>
        /// <returns>the newly created commercial exchange</returns>
        [HttpPost("create")]
        [Permission(Access.Create)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<EchangeCommercialModel>>> Create(EchangeCommercialCreateModel createModel)
            => ActionResultFor(await _service.CreateAsync(createModel));

        /// <summary>
        /// update the commercial exchange with the given model
        /// </summary>
        /// <param name="id">the id of the commercial exchange to be updated</param>
        /// <param name="updateModel">the update model</param>
        /// <returns>the updated commercial exchange</returns>
        [HttpPut("Update/{id}")]
        [Permission(Access.Update)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<EchangeCommercialModel>>> Update(string id, [FromBody] EchangeCommercialUpdateModel updateModel)
            => ActionResultFor(await _service.UpdateAsync(id, updateModel));

        /// <summary>
        /// delete the commercial exchange with the given id
        /// </summary>
        /// <param name="id">the id of the commercial exchange to be deleted</param>
        /// <returns>an operation result object</returns>
        [HttpDelete("delete/{id}")]
        [Permission(Access.Delete)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result>> Delete(string id)
            => ActionResultFor(await _service.DeleteAsync(id));

        /// <summary>
        /// save the given memo to the commercial exchange with the given id
        /// </summary>
        /// <param name="id">the id of the commercial exchange to save the memo for it</param>
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
        /// synchronization commercial exchanges with Google Calendar
        /// </summary>
        /// <returns>a result object</returns>
        [HttpPost("SynchronizationWithGoogleCalendar")]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result>> SynchronisationWithGoogleCalendar()
            => ActionResultFor(await _service.SynchronizationWithGoogleCalendar());

        /// <summary>
        /// update date event
        /// </summary>
        /// <param name="changeDateEventModel">the model</param>
        /// <returns>a result instance</returns>
        [HttpPost("UpdateDateEvent")]
        [Permission(Access.Update)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result>> UpdateDateEvent(ChangeDateEventModel changeDateEventModel)
            => ActionResultFor(await _service.UpdateDateEvent(changeDateEventModel));

        /// <summary>
        /// check RDV is exist
        /// </summary>
        /// <param name="model">the model represent criteria</param>
        /// <returns>a bool result</returns>
        [HttpPost("CheckRdvIsExist")]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<bool>>> CheckRdvIsExist([FromBody] CheckRdvIsExistModel model)
           => ActionResultFor(await _service.CheckRdvIsExist(model));
    }
}
