namespace COMPANY.Controllers.GeneralControllers
{
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Enums;
    using COMPANY.Application.Models;
    using COMPANY.Application.Models.BusinessEntities.General.Notification;
    using COMPANY.Application.Services.DataService.General.NotificationService;
    using COMPANY.Domain.Enums.Authentification;
    using COMPANY.Presentation.Authorization;
    using COMPANY.Presentation.Controllers.Base;
    using COMPANY.Presistence.Implementations;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [Module(Modules.Home)]
    [ApiController]
    public class NotificationsController : BaseController
    {
        private readonly INotificationService _service;

        public NotificationsController(INotificationService service)
            => _service = service;

        /// <summary>
        /// get the list of notifications as paged result
        /// </summary>
        /// <param name="filterOption">the filter options</param>
        /// <returns>a paged result</returns>
        [HttpPost]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<PagedResult<NotificationModel>>> Get([FromBody] FilterOption filterOption)
            => ActionResultFor(await _service.GeAsPagedResultAsync(filterOption));

        /// <summary>
        /// mark seen notification
        /// </summary>
        /// <param name="id">the id of the notification</param>
        /// <returns>a result instance</returns>
        [HttpGet("{id}")]
        [Permission(Access.Update)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result>> MarkAsSeen(string id)
             => ActionResultFor(await _service.MarkAsSeen(id));

        /// <summary>
        /// mark all as seen notification
        /// </summary>o
        /// <returns>a result instance</returns>
        [HttpGet("MarkAllAsSeen")]
        [Permission(Access.Update)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result>> MarkAllAsSeen()
             => ActionResultFor(await _service.MarkAllAsSeen());
    }
}
