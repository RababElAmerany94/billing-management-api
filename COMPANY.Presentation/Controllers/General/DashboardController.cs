namespace COMPANY.Presentation.Controllers.General
{
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Enums;
    using COMPANY.Application.Models.General.Dashboard;
    using COMPANY.Application.Models.Generals.Dashboard;
    using COMPANY.Application.Services.Dashboard;
    using COMPANY.Domain.Enums.Authentification;
    using COMPANY.Presentation.Authorization;
    using COMPANY.Presentation.Controllers.Base;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [Module(Modules.Home)]
    [ApiController]
    public class DashboardController : BaseController
    {
        private readonly IDashboardService _service;

        public DashboardController(IDashboardService service)
            => _service = service;

        /// <summary>
        /// get statistic devis group by status
        /// </summary>
        /// <param name="filterOption">the filter option</param>
        /// <returns>a result instance</returns>
        [HttpPost("DevisStatistic")]
        [Permission(Access.Read)]
        [ProducesResponseType(500)]
        [ProducesResponseType(200)]
        public async Task<ActionResult<Result<IEnumerable<DocumentStatisticByStatus>>>> GetDevisStatistic(DashboardFilterOption filterOption)
            => ActionResultFor(await _service.GetDevisStatistic(filterOption));

        /// <summary>
        /// get statistic facture group by status
        /// </summary>
        /// <param name="filterOption">the filter option</param>
        /// <returns>a result instance</returns>
        [HttpPost("FactureStatistic")]
        [Permission(Access.Read)]
        [ProducesResponseType(500)]
        [ProducesResponseType(200)]
        public async Task<ActionResult<Result<IEnumerable<DocumentStatisticByStatus>>>> GetFactureStatistic(DashboardFilterOption filterOption)
            => ActionResultFor(await _service.GetFactureStatistic(filterOption));

        /// <summary>
        /// get statistic avoir group by status
        /// </summary>
        /// <param name="filterOption">the filter option</param>
        /// <returns>a result instance</returns>
        [HttpPost("AvoirStatistic")]
        [Permission(Access.Read)]
        [ProducesResponseType(500)]
        [ProducesResponseType(200)]
        public async Task<ActionResult<Result<IEnumerable<DocumentStatisticByStatus>>>> GetAvoirStatistic(DashboardFilterOption filterOption)
            => ActionResultFor(await _service.GetAvoirStatistic(filterOption));

        /// <summary>
        /// get statistic dossier group by status
        /// </summary>
        /// <param name="filterOption">the filter option</param>
        /// <returns>a result instance</returns>
        [HttpPost("DossierStatistic")]
        [Permission(Access.Read)]
        [ProducesResponseType(500)]
        [ProducesResponseType(200)]
        public async Task<ActionResult<Result<IEnumerable<DocumentStatisticByStatus>>>> GetDossierStatistic(DashboardFilterOption filterOption)
            => ActionResultFor(await _service.GetDossierStatistic(filterOption));

        /// <summary>
        /// get chiffre d'affaire
        /// </summary>
        /// <param name="filterOption">the filter option</param>
        /// <returns>a result instance</returns>
        [HttpPost("ChiffreAffaire")]
        [Permission(Access.Read)]
        [ProducesResponseType(500)]
        [ProducesResponseType(200)]
        public async Task<ActionResult<Result<ChartData>>> GetChiffreAffaire(DashboardFilterOption filterOption)
            => ActionResultFor(await _service.GetChiffreAffaire(filterOption));

        /// <summary>
        /// get classsement clietns
        /// </summary>
        /// <param name="filterOption">the filter option</param>
        /// <returns>a result instance</returns>
        [HttpPost("ClassementClients")]
        [Permission(Access.Read)]
        [ProducesResponseType(500)]
        [ProducesResponseType(200)]
        public async Task<ActionResult<Result<IEnumerable<ClassementClient>>>> GetClassementClients(DashboardFilterOption filterOption)
            => ActionResultFor(await _service.GetClassementClients(filterOption));

        /// <summary>
        ///  get chiffre d'affaire restant à encaisser
        /// </summary>
        /// <param name="filterOption">the filter option</param>
        /// <returns>a result instance</returns>
        [HttpPost("ChiffreAffaireRestantAencaisser")]
        [Permission(Access.Read)]
        [ProducesResponseType(500)]
        [ProducesResponseType(200)]
        public async Task<ActionResult<Result<decimal>>> GetChiffreAffaireRestantAencaisser(DashboardFilterOption filterOption)
            => ActionResultFor(await _service.GetChiffreAffaireRestantAencaisser(filterOption));

        /// <summary>
        /// get articles of factures by category
        /// </summary>
        /// <param name="filterOption">the filter option</param>
        /// <returns>an result instance</returns>
        [HttpPost("FacturesArticlesByCategory")]
        [Permission(Access.Read)]
        [ProducesResponseType(500)]
        [ProducesResponseType(200)]
        public async Task<ActionResult<Result<IEnumerable<FacturesArticlesByCategory>>>> GetFacturesArticlesByCategory(FacturesArticlesByCategoryFilterOption filterOption)
            => ActionResultFor(await _service.GetFacturesArticlesByCategory(filterOption));

        /// <summary>
        /// get articles of factures with totals
        /// </summary>
        /// <param name="filterOption">the filter option</param>
        /// <returns>an result instance</returns>
        [HttpPost("FacturesArticlesTotals")]
        [Permission(Access.Read)]
        [ProducesResponseType(500)]
        [ProducesResponseType(200)]
        public async Task<ActionResult<Result<IEnumerable<FacturesArticlesTotals>>>> GetFacturesArticlesTotals(AdvanceDashboardFilterOption filterOption)
            => ActionResultFor(await _service.GetFacturesArticlesTotals(filterOption));

        /// <summary>
        /// get articles of factures with quantities
        /// </summary>
        /// <param name="filterOption">the filter option</param>
        /// <returns>an result instance</returns>
        [HttpPost("FacturesArticlesQuantities")]
        [Permission(Access.Read)]
        [ProducesResponseType(500)]
        [ProducesResponseType(200)]
        public async Task<ActionResult<Result<IEnumerable<FacturesArticlesQuantities>>>> GetFacturesArticlesQuantities(AdvanceDashboardFilterOption filterOption)
            => ActionResultFor(await _service.GetFacturesArticlesQuantities(filterOption));

        /// <summary>
        /// get ventilation chiffre affaires commerciaux
        /// </summary>
        /// <param name="filterOption">the filter option</param>
        /// <returns>an result instance</returns>
        [HttpPost("GetVentilationChiffreAffairesParCommercial")]
        [Permission(Access.Read)]
        [ProducesResponseType(500)]
        [ProducesResponseType(200)]
        public async Task<ActionResult<Result<IEnumerable<VentilationChiffreAffairesCommercial>>>> GetVentilationChiffreAffairesCommerciaux(AdvanceDashboardFilterOption filterOption)
            => ActionResultFor(await _service.GetVentilationChiffreAffairesCommerciaux(filterOption));

        /// <summary>
        /// get repartition types travaux par technicien
        /// </summary>
        /// <param name="filterOption">the filter option</param>
        /// <returns>an enumerable of repartition types travaux par technicien</returns>
        [HttpPost("GetRepartitionTypesTravauxParTechnicien")]
        [Permission(Access.Read)]
        [ProducesResponseType(500)]
        [ProducesResponseType(200)]
        public async Task<ActionResult<Result<IEnumerable<RepartitionTypesTravauxParTechnicien>>>> GetRepartitionTypesTravauxParTechnicien(AdvanceDashboardFilterOption filterOption)
            => ActionResultFor(await _service.GetRepartitionTypesTravauxParTechnicien(filterOption));

        /// <summary>
        /// get repartition dossiers par technicien
        /// </summary>
        /// <param name="filterOption">the filter option</param>
        /// <returns>a result enumerable of repartition dossiers par technicien</returns>
        [HttpPost("GetRepartitionDossiersTechnicien")]
        [Permission(Access.Read)]
        [ProducesResponseType(500)]
        [ProducesResponseType(200)]
        public async Task<ActionResult<Result<IEnumerable<RepartitionDossiersTechnicien>>>> GetRepartitionDossiersTechnicien(AdvanceDashboardFilterOption filterOption)
            => ActionResultFor(await _service.GetRepartitionDossiersTechnicien(filterOption));

        /// <summary>
        /// get count dossiers of a client
        /// </summary>
        /// <param name="filterOption">the filter option</param>
        /// <returns>count dossiers</returns>
        [HttpPost("GetCountDossiers")]
        [Permission(Access.Read)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Result<int>>> GetCountDossiers(DashboardFilterOption filterOption)
            => ActionResultFor(await _service.GetCountDossiers(filterOption));
    }
}
