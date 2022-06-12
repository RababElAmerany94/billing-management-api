namespace COMPANY.Presentation.Controllers.EntitiesControllers
{
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Enums;
    using COMPANY.Application.Models;
    using COMPANY.Application.Models.BusinessEntitiesModels.PrixProduitParAgenceModels;
    using COMPANY.Application.Models.BusinessEntitiesModels.ProduitModels;
    using COMPANY.Application.Services.DataService.ProduitService;
    using COMPANY.Common.Helpers;
    using COMPANY.Domain.Entities.OwnedEntities;
    using COMPANY.Domain.Enums.Authentification;
    using COMPANY.Presentation.Authorization;
    using COMPANY.Presentation.Controllers.Base;
    using COMPANY.Presistence.Implementations;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [Module(Modules.Produits)]
    [ApiController]
    public class ProduitController : BaseController
    {
        private readonly IProduitService _service;

        public ProduitController(IProduitService produitSerivce) => _service = produitSerivce;

        #region produit

        /// <summary>
        /// get the list of produits as paged Result
        /// </summary>
        /// <param name="filterModel">the filter options</param>
        /// <returns>a paged result</returns>
        [HttpPost]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<PagedResult<ProduitModel>>> Get([FromBody] FilterOption filterModel)
            => ActionResultFor(await _service.GeProduitsAsPagedResultAsync(filterModel));

        /// <summary>
        /// get the produit with the given id
        /// </summary>
        /// <param name="id">the id of the produit to retrieve</param>
        /// <returns>the produit</returns>
        [HttpGet("{id}")]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<ProduitModel>>> Get(string id)
            => ActionResultFor(await _service.GetByIdAsync(id));

        /// <summary>
        /// create a produit using the ProduitCreateModel
        /// </summary>
        /// <param name="produitModel">the model to create the produit from it</param>
        /// <returns>the newly created produit</returns>
        [HttpPost("Create")]
        [Permission(Access.Create)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<ProduitModel>>> Create([FromBody] ProduitCreateModel produitModel)
            => ActionResultFor(await _service.CreateAsync(produitModel));

        /// <summary>
        /// update the produit with the given model
        /// </summary>
        /// <param name="id">the id of the produit to be updated</param>
        /// <param name="produitModel">the update model</param>
        /// <returns>the updated produit</returns>
        [HttpPut("Update/{id}")]
        [Permission(Access.Update)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<ProduitModel>>> Update(string id, [FromBody] ProduitUpdateModel produitModel)
            => ActionResultFor(await _service.UpdateAsync(id, produitModel));

        /// <summary>
        /// delete the produit with the given id
        /// </summary>
        /// <param name="id">the id of the produit to be deleted</param>
        /// <returns>a result object</returns>
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
        /// save the given memo to the produit with the given id
        /// </summary>
        /// <param name="id">the id of the produit to save the memo for it</param>
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
        /// change visibility produit
        /// </summary>
        /// <param name="changeVisibilityProduitModel">the change visibility model</param>
        /// <returns>a visibility of produit</returns>
        [HttpPost("ChangeVisibilityProduit")]
        [Permission(Access.Update)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<bool>>> Create([FromBody] ChangeVisibilityProduitModel changeVisibilityProduitModel)
            => ActionResultFor(await _service.ChangeVisibilityProduit(changeVisibilityProduitModel));

        #endregion

        #region prix produit par agence


        /// <summary>
        /// get the prix produit par agence with the given id
        /// </summary>
        /// <param name="produitId">the id of the produit to retrieve</param>
        /// <returns>the produit</returns>
        [HttpGet("PrixProduitParAgence/{ProduitId}")]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<PrixProduitParAgenceModel>>> GetPrixProduitParAgence(string produitId)
        {
            var agenceId = HttpContext.GetAgenceID();

            if (!agenceId.IsValid())
                return Unauthorized();

            // all set, return the value
            return ActionResultFor(await _service.GetPrixProduitParAgenceByIdAsync(produitId, agenceId));
        }

        /// <summary>
        /// create a  prix produit par agence using the produitCreateModel
        /// </summary>
        /// <param name="produitModel">the model to create the produit from it</param>
        /// <returns>the newly created produit</returns>
        [HttpPost("PrixProduitParAgence/Create")]
        [Permission(Access.Create)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<PrixProduitParAgenceModel>>> Create([FromBody] PrixProduitParAgenceCreateModel produitModel)
        {
            var agenceId = HttpContext.GetAgenceID();

            if (!agenceId.IsValid())
                return Unauthorized();

            // all set let return the value
            return ActionResultFor(await _service.CreatePrixProduitParAgenceAsync(produitModel, agenceId));
        }

        /// <summary>
        /// update the  prix produit par agence with the given model
        /// </summary>
        /// <param name="id">the id of the produit to be updated</param>
        /// <param name="produitModel">the update model</param>
        /// <returns>the updated produit</returns>
        [HttpPut("PrixProduitParAgence/Update/{id}")]
        [Permission(Access.Update)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<PrixProduitParAgenceModel>>> Update(string id, [FromBody] PrixProduitParAgenceUpdateModel produitModel)
            => ActionResultFor(await _service.UpdatePrixProduitParAgenceAsync(id, produitModel));

        /// <summary>
        /// delete the prix produit par agence with the given id
        /// </summary>
        /// <param name="id">the id of the produit to be deleted</param>
        /// <returns>a result object</returns>
        [HttpDelete("PrixProduitParAgence/Delete/{id}")]
        [Permission(Access.Delete)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result>> DeletePrixProduitParAgence(string id)
            => ActionResultFor(await _service.DeletePrixProduitParAgenceAsync(id));

        #endregion
    }
}