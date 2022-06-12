namespace COMPANY.Presentation.Controllers.Documents
{
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Enums;
    using COMPANY.Application.Models.BusinessEntities.Documents.Paiement;
    using COMPANY.Application.Services.DataService.Documents.PaiementService;
    using COMPANY.Domain.Enums.Authentification;
    using COMPANY.Presentation.Authorization;
    using COMPANY.Presentation.Controllers.Base;
    using COMPANY.Presistence.Implementations;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using Xterme.Application.Models.GeneralModels.PagingModels;

    [Route("api/[controller]")]
    [Module(Modules.Paiement)]
    [ApiController]
    public class PaiementController : BaseController
    {

        private readonly IPaiementService _service;

        public PaiementController(IPaiementService service) => _service = service;

        /// <summary>
        /// get the list of paiement as paged Result
        /// </summary>
        /// <param name="filterModel">the filter options</param>
        /// <returns>a paged result</returns>
        [HttpPost]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<PagedResult<PaiementModel>>> Get([FromBody] PaiementFilterOption filterModel)
            => ActionResultFor(await _service.GeAsPagedResultAsync(filterModel));

        /// <summary>
        /// get the paiement with the given id
        /// </summary>
        /// <param name="id">the id of the paiement to retrieve</param>
        /// <returns>the paiement</returns>
        [HttpGet("{id}")]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<PaiementModel>>> Get(string id)
            => ActionResultFor(await _service.GetByIdAsync(id));

        /// <summary>
        /// create a paiement using the ClientCreateModel
        /// </summary>
        /// <param name="paiementModel">the model to create the paiement from it</param>
        /// <returns>the newly created paiement</returns>
        [HttpPost("Create")]
        [Permission(Access.Create)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<PaiementModel>>> Create([FromBody] PaiementCreateModel paiementModel)
            => ActionResultFor(await _service.CreateAsync(paiementModel));

        /// <summary>
        /// update the paiement with the given model
        /// </summary>
        /// <param name="id">the id of the paiement to be updated</param>
        /// <param name="paiementModel">the update model</param>
        /// <returns>the updated paiement</returns>
        [HttpPut("Update/{id}")]
        [Permission(Access.Update)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<PaiementModel>>> Update(string id, [FromBody] PaiementUpdateModel paiementModel)
            => ActionResultFor(await _service.UpdateAsync(id, paiementModel));

        /// <summary>
        /// delete the paiement with the given id
        /// </summary>
        /// <param name="id">the id of the paiement to be deleted</param>
        /// <returns>a result object</returns>
        [HttpDelete("Delete/{id}")]
        [Permission(Access.Delete)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result>> Delete(string id)
            => ActionResultFor(await _service.DeleteAsync(id));

        /// <summary>
        /// movement amount from account to another account
        /// </summary>
        /// <param name="model">the model describe movement</param>
        /// <returns>a result instant</returns>
        [HttpPost("MovementCompteToCompte")]
        [Permission(Access.Create)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result>> MovementCompteToCompte([FromBody] PaiementMovementCompteToCompteModel model)
            => ActionResultFor(await _service.MovementCompteToCompte(model));

        /// <summary>
        /// get total payments
        /// </summary>
        /// <param name="filterOption">the filter option</param>
        /// <returns>a result instant</returns>
        [HttpPost("GetTotalPaiments")]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<decimal>>> GetTotalPaiments(PaiementFilterOption filterOption)
            => ActionResultFor(await _service.GetTotalPaiementsAsync(filterOption));

        /// <summary>
        /// paiement groupe of obligé
        /// </summary>
        /// <param name="model"></param>
        /// <returns>a result instant</returns>
        [HttpPost("PaiementGroupeOblige")]
        [Permission(Access.Create)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result>> PaiementGroupeOblige(PaiementGroupeObligeModel model)
            => ActionResultFor(await _service.PaiementGroupeOblige(model));
    }
}
