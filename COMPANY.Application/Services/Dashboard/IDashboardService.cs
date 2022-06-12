namespace COMPANY.Application.Services.Dashboard
{
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Models.General.Dashboard;
    using COMPANY.Application.Models.Generals.Dashboard;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IDashboardService
    {
        /// <summary>
        /// get statistic devis group by status
        /// </summary>
        /// <param name="filterOption">the filter option</param>
        /// <returns>a result instance</returns>
        Task<Result<IEnumerable<DocumentStatisticByStatus>>> GetDevisStatistic(DashboardFilterOption filterOption);

        /// <summary>
        /// get statistic facture group by status
        /// </summary>
        /// <param name="filterOption">the filter option</param>
        /// <returns>a result instance</returns>
        Task<Result<IEnumerable<DocumentStatisticByStatus>>> GetFactureStatistic(DashboardFilterOption filterOption);

        /// <summary>
        /// get statistic dossier group by status
        /// </summary>
        /// <param name="filterOption">the filter option</param>
        /// <returns>a result instance</returns>
        Task<Result<IEnumerable<DocumentStatisticByStatus>>> GetDossierStatistic(DashboardFilterOption filterOption);

        /// <summary>
        /// get statistic avoir group by status
        /// </summary>
        /// <param name="filterOption">the filter option</param>
        /// <returns>a result instance</returns>
        Task<Result<IEnumerable<DocumentStatisticByStatus>>> GetAvoirStatistic(DashboardFilterOption filterOption);

        /// <summary>
        /// get chiffre d'affaire
        /// </summary>
        /// <param name="filterOption">the filter option</param>
        /// <returns>a result dashboard model</returns>
        Task<Result<ChartData>> GetChiffreAffaire(DashboardFilterOption filterOption);

        /// <summary>
        /// get classsement clietns
        /// </summary>
        /// <param name="filterOption">the filter option</param>
        /// <returns>a result instance</returns>
        Task<Result<IEnumerable<ClassementClient>>> GetClassementClients(DashboardFilterOption filterOption);

        /// <summary>
        /// get chiffre d'affaire restant à encaisser
        /// </summary>
        /// <param name="filterOption">the filter option</param>
        /// <returns>a result instance</returns>
        Task<Result<decimal>> GetChiffreAffaireRestantAencaisser(DashboardFilterOption filterOption);

        /// <summary>
        /// get articles of factures by category
        /// </summary>
        /// <param name="filterOption">the filter option</param>
        /// <returns>an result instance</returns>
        Task<Result<IEnumerable<FacturesArticlesByCategory>>> GetFacturesArticlesByCategory(FacturesArticlesByCategoryFilterOption filterOption);

        /// <summary>
        /// get articles of factures with totals
        /// </summary>
        /// <param name="filterOption">the filter option</param>
        /// <returns>an result instance</returns>
        Task<Result<IEnumerable<FacturesArticlesTotals>>> GetFacturesArticlesTotals(AdvanceDashboardFilterOption filterOption);

        /// <summary>
        /// get articles of factures with quantities
        /// </summary>
        /// <param name="filterOption">the filter option</param>
        /// <returns>an result instance</returns>
        Task<Result<IEnumerable<FacturesArticlesQuantities>>> GetFacturesArticlesQuantities(AdvanceDashboardFilterOption filterOption);

        /// <summary>
        /// get ventilation chiffre affaires commerciaux
        /// </summary>
        /// <param name="filterOption">the filter option</param>
        /// <returns>a list of ventilation of commerciaux</returns>
        Task<Result<IEnumerable<VentilationChiffreAffairesCommercial>>> GetVentilationChiffreAffairesCommerciaux(AdvanceDashboardFilterOption filterOption);

        /// <summary>
        /// get repartition types travaux par technicien
        /// </summary>
        /// <param name="filterOption">the filter option</param>
        /// <returns>an enumerable of repartition types travaux par technicien</returns>
        Task<Result<IEnumerable<RepartitionTypesTravauxParTechnicien>>> GetRepartitionTypesTravauxParTechnicien(AdvanceDashboardFilterOption filterOption);

        /// <summary>
        /// get repartition dossiers par technicien
        /// </summary>
        /// <param name="filterOption">the filter option</param>
        /// <returns>a result enumerable of repartition dossiers par technicien</returns>
        Task<Result<IEnumerable<RepartitionDossiersTechnicien>>> GetRepartitionDossiersTechnicien(AdvanceDashboardFilterOption filterOption);

        /// <summary>
        /// count dossiers of a client
        /// </summary>
        /// <param name="filterOption">the filter option</param>
        /// <returns>a result count</returns>
        Task<Result<int>> GetCountDossiers(DashboardFilterOption filterOption);
    }
}
