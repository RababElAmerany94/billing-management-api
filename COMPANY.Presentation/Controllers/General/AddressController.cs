namespace COMPANY.Controllers
{
    using Application.Data.Enums;
    using Application.Models;
    using Application.Services.DataService;
    using COMPANY.Application.Models.GeneralModels.PagingModels;
    using COMPANY.Presentation.Controllers.Base;
    using COMPANY.Presistence.Implementations;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : BaseController
    {
        private readonly IAddressService _service;

        public AddressController(IAddressService service) => _service = service;

        /// <summary>
        /// get the list of all countries in the database
        /// </summary>
        /// <returns>list of all countries</returns>
        [HttpGet("Countries")]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<CountryModel>>> GetCountries()
        {
            var result = await _service.GetAllCountriesAsync();

            // the operation failed something went wrong
            if (result.Status == ResultStatus.Failed && result.HasError)
                return StatusCode(500, result);

            // no value, couldn't find the entity
            if (!result.HasValue)
                return NotFound(result);

            // all set, return the value
            return Ok(result);
        }

        /// <summary>
        /// list of countries as paged result
        /// </summary>
        /// <param name="filterOption">the filter option</param>
        /// <returns>list of countries as paged result</returns>
        [HttpPost("Countries")]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<ActionResult<PagedResult<CountryModel>>> GetCountries([FromBody] FilterOption filterOption)
        {
            var result = await _service.GetCountriesAsPagedResultAsync(filterOption);

            // the operation failed something went wrong
            if (result.Status == ResultStatus.Failed && result.HasError)
                return StatusCode(500, result);

            // no value, couldn't find the entity
            if (!result.HasValue)
                return NotFound(result);

            // all set, return the value
            return Ok(result);
        }

        /// <summary>
        /// get the country with the given id
        /// </summary>
        /// <param name="id">the id of the country to be retrieved</param>
        /// <returns>the country with the given id</returns>
        [HttpGet("Country/{id}")]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<ActionResult<CountryModel>> GetCountry(string id)
        {
            var result = await _service.GetCountryByIdAsync(id);

            // the operation failed something went wrong
            if (result.Status == ResultStatus.Failed && result.HasError)
                return StatusCode(500, result);

            // no value, couldn't find the entity
            if (!result.HasValue)
                return NotFound(result);

            // all set, return the value
            return Ok(result);
        }

        /// <summary>
        /// get the list of departements in the database
        /// </summary>
        /// <returns>list of departements</returns>
        [HttpGet("Departements")]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<DepartementModel>>> GetDepartements()
        {
            var result = await _service.GetAllDepartementsAsync();

            // the operation failed something went wrong
            if (result.Status == ResultStatus.Failed && result.HasError)
                return StatusCode(500, result);

            // no value, couldn't find the entity
            if (!result.HasValue)
                return NotFound(result);

            // all set, return the value
            return Ok(result);
        }

        /// <summary>
        /// get the list of departements as PagedResult
        /// </summary>
        /// <param name="filterOption">the filter option</param>
        /// <returns>list of departements as paged result</returns>
        [HttpPost("Departements")]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<ActionResult<PagedResult<DepartementModel>>> GetDepartements([FromBody] DepartmentFilterOption filterOption)
        {
            var result = await _service.GetDepartementsAsPagedResultAsync(filterOption);

            // the operation failed something went wrong
            if (result.Status == ResultStatus.Failed && result.HasError)
                return StatusCode(500, result);

            // no value, couldn't find the entity
            if (!result.HasValue)
                return NotFound(result);

            // all set, return the value
            return Ok(result);
        }

        /// <summary>
        /// get the departement with the given id
        /// </summary>
        /// <param name="id">the id of department to be retrieved</param>
        /// <returns>the departements with the given id</returns>
        [HttpGet("Departement/{id}")]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<ActionResult<DepartementModel>> GetDepartement(string id)
        {
            var result = await _service.GetDepartementByIdAsync(id);

            // the operation failed something went wrong
            if (result.Status == ResultStatus.Failed && result.HasError)
                return StatusCode(500, result);

            // no value, couldn't find the entity
            if (!result.HasValue)
                return NotFound(result);

            // all set, return the value
            return Ok(result);
        }
    }
}