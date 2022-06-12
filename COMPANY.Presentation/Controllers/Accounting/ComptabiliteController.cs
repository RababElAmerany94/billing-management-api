namespace COMPANY.Presentation.Controllers.Accounting
{
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Enums;
    using COMPANY.Application.Models.BusinessEntities.Accounting.Comptabilite;
    using COMPANY.Application.Models.General.FilterOptions;
    using COMPANY.Application.Services.DataService.Accounting.Comptabilite;
    using COMPANY.Domain.Enums.Authentification;
    using COMPANY.Presentation.Authorization;
    using COMPANY.Presentation.Controllers.Base;
    using COMPANY.Presistence.Implementations;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [Module(Modules.Accounting)]
    [ApiController]
    public class ComptabiliteController : BaseController
    {
        private readonly IComptabiliteService _service;

        public ComptabiliteController(IComptabiliteService service)
            => _service = service;

        /// <summary>
        /// get the list of sales journal as paged Result
        /// </summary>
        /// <param name="filterOption">the filter options</param>
        /// <returns>a paged result</returns>
        [HttpPost("VentesJournal")]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<PagedResult<VentesJournalModel>>> Get([FromBody] VentesJournalFilterOption filterOption)
            => ActionResultFor(await _service.GetVentesJournalAsPagedResultAsync(filterOption));

        /// <summary>
        /// export the list of sales journal as an excel format
        /// </summary>
        /// <returns>the result object</returns>
        [HttpPost("VentesJournal/ExporterExcel")]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<byte[]>>> ExporterExcel([FromBody] VentesJournalFilterOption filterOption)
            => ActionResultFor(await _service.ExportVentesJournalListAsExcelAsync(filterOption));

        /// <summary>
        /// get the list of accounts journal as paged Result
        /// </summary>
        /// <param name="filterOption">the filter options</param>
        /// <returns>a paged result</returns>
        [HttpPost("ComptesJournal")]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<PagedResult<ComptesJournalModel>>> Get([FromBody] ComptesJournalFilterOption filterOption)
            => ActionResultFor(await _service.GetComptesJournalAsPagedResultAsync(filterOption));

        /// <summary>
        /// export the list of accounts journal as an excel format
        /// </summary>
        /// <returns>the result object</returns>
        [HttpPost("ComptesJournal/ExporterExcel")]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<byte[]>>> ExporterExcel([FromBody] ComptesJournalFilterOption filterOption)
            => ActionResultFor(await _service.ExportComptesJournalListAsExcelAsync(filterOption));

    }
}
