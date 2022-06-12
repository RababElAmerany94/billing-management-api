namespace COMPANY.Controllers.GeneralControllers
{
    using COMPANY.Presentation.Controllers.Base;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class CheckController : BaseController
    {
        /// <summary>
        /// check server is work
        /// </summary>
        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult Get() => Ok(new { Status = "OK" });

    }
}