namespace COMPANY.Presentation.Controllers.General
{
    using COMPANY.Application.Services.Generals.SpotHitHooksService;
    using COMPANY.Presentation.Controllers.Base;
    using Company.SpotHit.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class SpotHitHooksController : BaseController
    {
        private readonly ISpotHitHooksService _service;

        public SpotHitHooksController(ISpotHitHooksService service)
            => _service = service;

        /// <summary>
        /// reception response sms
        /// </summary>
        /// <param name="reponse"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("ReceptionResponse")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> ReceptionResponse([FromQuery] PushResponse reponse)
        {
            await _service.ReceptionResponse(reponse);
            return Ok();
        }

        /// <summary>
        /// reception stop sms
        /// </summary>
        /// <param name="reponse"></param>
        [AllowAnonymous]
        [HttpGet("ReceptionStop")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> ReceptionStop([FromQuery] PushStop reponse)
        {
            await _service.ReceptionStop(reponse);
            return Ok();
        }

    }
}
