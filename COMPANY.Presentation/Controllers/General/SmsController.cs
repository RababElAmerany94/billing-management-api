namespace COMPANY.Presentation.Controllers.General
{
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Enums;
    using COMPANY.Application.Models.BusinessEntities.General.Sms;
    using COMPANY.Application.Models.Generals.FilterOptions;
    using COMPANY.Application.Services.DataService.General.SmsService;
    using COMPANY.Domain.Enums.Authentification;
    using COMPANY.Presentation.Authorization;
    using COMPANY.Presentation.Controllers.Base;
    using COMPANY.Presistence.Implementations;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [Module(Modules.ModeleSms)]
    [ApiController]
    public class SmsController : BaseController
    {
        private readonly ISmsService _service;

        public SmsController(ISmsService service)
            => _service = service;

        /// <summary>
        /// get the list of sms as paged Result
        /// </summary>
        /// <param name="filterOption">the filter options</param>
        /// <returns>a paged result</returns>
        [HttpPost]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<PagedResult<SmsModel>>> Get([FromBody] SmsFilterOption filterOption)
            => ActionResultFor(await _service.GeAsPagedResultAsync(filterOption));

        /// <summary>
        /// send a SMS using the EnvoyerSmsModel
        /// </summary>
        /// <param name="model">the model to send the sms</param>
        /// <returns>the newly sent sms</returns>
        [HttpPost("Send")]
        [Permission(Access.Create)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<SmsModel>>> Create([FromBody] EnvoyerSmsModel model)
            => ActionResultFor(await _service.EnvoyerSms(model));
    }
}
