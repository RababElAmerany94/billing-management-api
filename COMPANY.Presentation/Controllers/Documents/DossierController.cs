namespace COMPANY.Presentation.Controllers.EntitiesControllers
{
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Enums;
    using COMPANY.Application.Models;
    using COMPANY.Application.Models.BusinessEntities.Documents.DossierPV;
    using COMPANY.Application.Models.BusinessEntities.Documents.FicheControle;
    using COMPANY.Application.Models.General.FilterOptions;
    using COMPANY.Application.Services.DataService.Documents.DossierPVService;
    using COMPANY.Application.Services.DataService.Documents.FicheControleService;
    using COMPANY.Application.Services.DataService.DossierService;
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
    [Module(Modules.Dossiers)]
    [ApiController]
    public class DossierController : BaseController
    {
        private readonly IDossierService _service;
        private readonly IDossierPVService _dossierPVService;
        private readonly IFicheControleService _ficheControleService;

        public DossierController(
            IDossierService service,
            IDossierPVService dossierPVService,
            IFicheControleService ficheControleService)
        {
            _service = service;
            _dossierPVService = dossierPVService;
            _ficheControleService = ficheControleService;
        }

        #region Dossier

        /// <summary>
        /// get the list of dossier as paged Result
        /// </summary>
        /// <param name="filterModel">the filter options</param>
        /// <returns>a dossier paged result</returns>
        [HttpPost]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<PagedResult<DossierModel>>> Get([FromBody] DossierFilterOption filterModel)
            => ActionResultFor(await _service.GeAsPagedResultAsync(filterModel));

        /// <summary>
        /// get the dossier with the given id
        /// </summary>
        /// <param name="id">the id of the dossier to retrieve</param>
        /// <returns>a result instance contains dossier</returns>
        [HttpGet("{id}")]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<DossierModel>>> Get(string id)
            => ActionResultFor(await _service.GetByIdAsync(id));

        /// <summary>
        /// create a new dossier record
        /// </summary>
        /// <returns>the newly created dossier</returns>
        [HttpPost("Create")]
        [Permission(Access.Create)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<DossierModel>>> Create(DossierCreateModel createModel)
            => ActionResultFor(await _service.CreateAsync(createModel));

        /// <summary>
        /// update the dossier with the given model
        /// </summary>
        /// <param name="id">the id of the dossier to be updated</param>
        /// <param name="updateModel">the update model</param>
        /// <returns>the updated dossier</returns>
        [HttpPut("Update/{id}")]
        [Permission(Access.Update)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<DossierModel>>> Update(string id, [FromBody] DossierUpdateModel updateModel)
            => ActionResultFor(await _service.UpdateAsync(id, updateModel));

        /// <summary>
        /// delete the dossier with the given id
        /// </summary>
        /// <param name="id">the id of the dossier to be deleted</param>
        /// <returns>an operation result object</returns>
        [HttpDelete("Delete/{id}")]
        [Permission(Access.Delete)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result>> Delete(string id)
            => ActionResultFor(await _service.DeleteAsync(id));

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

        /// <summary>
        /// save the given memo to the dossier with the given id
        /// </summary>
        /// <param name="id">the id of the dossier to save the memo dossier for it</param>
        /// <param name="memos">the memo dossier to be saved</param>
        /// <returns>a result object</returns>
        [HttpPost("MemosDossier/Save/{id}")]
        [Permission(Access.Create)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result>> SaveMemos(string id, [FromBody] ICollection<MemoDossier> memos)
            => ActionResultFor(await _service.SaveMemosDossierAsync(id, memos));

        /// <summary>
        /// retrieve articles of dossier
        /// </summary>
        /// <returns>a list of articles</returns>
        [HttpGet("GetArticle/{dossierId}")]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<List<Article>>>> GetArticle(string dossierId)
            => ActionResultFor(await _service.GetDossierArticles(dossierId));

        /// <summary>
        /// check user already assigned to another dossier in the same date and hour
        /// </summary>
        /// <returns>a boolean</returns>
        [HttpPost("CheckUserAssignedSameDateAndHour")]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<bool>>> CheckUserAssignedSameDateAndHour(CheckUserAssignedSameDateAndHourFilterOption filterOption)
            => ActionResultFor(await _service.CheckUserAssignedSameDateAndHour(filterOption));

        /// <summary>
        /// mark dossier à planifier
        /// </summary>
        /// <param name="dossierId">the id of dossier</param>
        /// <returns>a result instance</returns>
        [HttpPost("MarkDossierAplanifier/{dossierId}")]
        [Permission(Access.Update)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result>> MarkDossierAplanifier(string dossierId)
            => ActionResultFor(await _service.MarkDossierAplanifier(dossierId));

        /// <summary>
        /// synchronize order of antsroute with our dossier
        /// </summary>
        /// <returns>a result instance contains dossier updated</returns>
        [HttpPost("SynchronizeWithAntsroute/{dossierId}")]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<DossierModel>>> SynchronizeWithAntsroute(string dossierId)
            => ActionResultFor(await _service.SynchronizeWithAntsroute(dossierId));

        /// <summary>
        /// synchronize orders of antsroute with our dossiers
        /// </summary>
        /// <returns>a result instance</returns>
        [HttpPost("SynchronizeWithAntsroute")]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result>> SynchronizeWithAntsroute()
            => ActionResultFor(await _service.SynchronizeWithAntsroute());

        /// <summary>
        /// save the given viste technique to the dossier
        /// </summary>
        /// <param name="id">the id of the dossier to save the viste technique for him</param>
        /// <param name="visteTechnique">the viste technique to be saved</param>
        /// <returns>an operation result</returns>
        [HttpPost("VisteTechnique/Save/{id}")]
        [Permission(Access.Create)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result>> SaveVisteTechnique(string id, [FromBody] VisteTechnique visteTechnique)
            => ActionResultFor(await _service.SaveVisteTechnique(id, visteTechnique));

        #endregion

        #region pv

        /// <summary>
        /// create a PV with the given model
        /// </summary>
        /// <returns>the newly created PV</returns>
        [HttpPost("PV/Create")]
        [Permission(Access.Create)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Result<DossierPVModel>>> CreatePV(DossierPVCreateModel createModel)
            => ActionResultFor(await _dossierPVService.CreateAsync(createModel));

        /// <summary>
        /// update the PV with the given model
        /// </summary>
        /// <param name="id">the id of the PV to be updated</param>
        /// <param name="updateModel">the update model</param>
        /// <returns>the updated PV</returns>
        [HttpPut("PV/Update/{id}")]
        [Permission(Access.Update)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<DossierPVModel>>> UpdatePV(string id, [FromBody] DossierPVUpdateModel updateModel)
            => ActionResultFor(await _dossierPVService.UpdateAsync(id, updateModel));

        /// <summary>
        /// delete the PV with the given id
        /// </summary>
        /// <param name="id">the id of the PV to be deleted</param>
        /// <returns>an operation result object</returns>
        [HttpDelete("PV/Delete/{id}")]
        [Permission(Access.Delete)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result>> DeletePV(string id)
            => ActionResultFor(await _dossierPVService.DeleteAsync(id));

        #endregion

        #region fiche controle

        /// <summary>
        /// create a fiche controle with the given model
        /// </summary>
        /// <returns>the newly created fiche controle</returns>
        [HttpPost("FicheControle/Create")]
        [Permission(Access.Create)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<FicheControleModel>>> CreateFicheControle(FicheControleCreateModel createModel)
            => ActionResultFor(await _ficheControleService.CreateAsync(createModel));

        /// <summary>
        /// update the fiche controle with the given model
        /// </summary>
        /// <param name="id">the id of the fiche controle to be updated</param>
        /// <param name="updateModel">the update model</param>
        /// <returns>the updated fiche controle</returns>
        [HttpPut("FicheControle/Update/{id}")]
        [Permission(Access.Update)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<FicheControleModel>>> UpdateFicheControle(string id, [FromBody] FicheControleUpdateModel updateModel)
            => ActionResultFor(await _ficheControleService.UpdateAsync(id, updateModel));

        /// <summary>
        /// delete the fiche controle with the given id
        /// </summary>
        /// <param name="id">the id of the fiche controle to be deleted</param>
        /// <returns>an operation result object</returns>
        [HttpDelete("FicheControle/Delete/{id}")]
        [Permission(Access.Delete)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result>> DeleteFicheControle(string id)
            => ActionResultFor(await _ficheControleService.DeleteAsync(id));

        #endregion

    }
}
