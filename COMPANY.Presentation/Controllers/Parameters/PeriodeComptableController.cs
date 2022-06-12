namespace COMPANY.Controllers.EntitiesControllers
{
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Enums;
    using COMPANY.Application.Models;
    using COMPANY.Application.Models.BusinessEntitiesModels.AccountingPeriodModals;
    using COMPANY.Application.Services.DataService.PeriodeComptableService;
    using COMPANY.Domain.Enums.Authentification;
    using COMPANY.Presentation.Authorization;
    using COMPANY.Presentation.Controllers.Base;
    using COMPANY.Presistence.Implementations;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Authorize]
    [Route("api/[controller]")]
    [Module(Modules.Parameters)]
    [ApiController]
    public class PeriodeComptableController : BaseController
    {
        private readonly IPeriodeComptableService _service;

        public PeriodeComptableController(IPeriodeComptableService service)
        {
            _service = service;
        }

        /// <summary>
        /// get the list of accounting periods as paged Result
        /// </summary>
        /// <param name="filterModel">the filter options</param>
        /// <returns>a paged result</returns>
        [HttpPost]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<PagedResult<PeriodeComptableModel>>> Get([FromBody] FilterOption filterModel)
            => Ok(await _service.GeAsPagedResultAsync(filterModel));

        /// <summary>
        /// get the accounting period with the given id
        /// </summary>
        /// <param name="id">the id of the accounting period to retrieve</param>
        /// <returns>the accounting period</returns>
        [HttpGet("{id}")]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<PeriodeComptableModel>>> Get(string id)
            => ActionResultFor(await _service.GetByIdAsync(id));

        /// <summary>
        /// create a accounting period using the PeriodeComptableCreateModel
        /// </summary>
        /// <param name="accountingPeriodCreateModel">the model to create the accounting period from it</param>
        /// <returns>the newly created accounting period</returns>
        [HttpPost("Create")]
        [Permission(Access.Create)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<PeriodeComptableModel>>> Create([FromBody] PeriodeComptableCreateModel accountingPeriodCreateModel)
            => ActionResultFor(await _service.CreateAsync(accountingPeriodCreateModel));

        /// <summary>
        /// update the accounting period with the given model
        /// </summary>
        /// <param name="id">the id of the accounting period to be updated</param>
        /// <param name="accountingPeriodUpdateModel">the update model</param>
        /// <returns>the updated accounting period</returns>
        [HttpPut("Update/{id}")]
        [Permission(Access.Update)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<PeriodeComptableModel>>> Update(string id, [FromBody] PeriodeComptableUpdateModel accountingPeriodUpdateModel)
            => ActionResultFor(await _service.UpdateAsync(id, accountingPeriodUpdateModel));

        /// <summary>
        /// closing accounting period
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("ClosingPeriodeComptable/{id}")]
        [Permission(Access.Update)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result>> ClosingPeriodeComptable(string id)
            => ActionResultFor(await _service.ClosingPeriodComptable(id));
    }
}