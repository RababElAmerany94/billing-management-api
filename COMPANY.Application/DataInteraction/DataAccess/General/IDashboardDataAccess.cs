namespace COMPANY.Application.DataInteraction.DataAccess.General
{
    using COMPANY.Application.Data;
    using COMPANY.Application.Models.General.Dashboard;
    using COMPANY.Application.Models.Generals.Dashboard;
    using COMPANY.Domain.Entities;
    using COMPANY.Domain.Entities.Documents;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface IDashboardDataAccess
    {
        /// <summary>
        /// get classement clients
        /// </summary>
        /// <param name="factureRequest">the facture request builder</param>
        /// <param name="avoirRequest">the avoir request</param>
        /// <returns>an enumerable/returns>
        Task<IEnumerable<ClassementClient>> GetClassementClients(
            IDataRequest<Facture> factureRequest,
            IDataRequest<Avoir> avoirRequest
        );

        /// <summary>
        /// function SQL group articles of factures by category
        /// </summary>
        /// <param name="parameters">the parameters of function</param>
        /// <param name="categoryId">the id of category</param>
        /// <returns>an enumerable</returns>
        Task<IEnumerable<FacturesArticlesByCategory>> GetFacturesArticlesByCategory(GetArticlesFacturesParameters parameters, string categoryId);

        /// <summary>
        /// function SQL group articles of factures with quantities
        /// </summary>
        /// <param name="parameters">the parameters of function</param>
        /// <returns>an enumerable</returns>
        Task<IEnumerable<FacturesArticlesQuantities>> GetFacturesArticlesQuantities(GetArticlesFacturesParameters parameters);

        /// <summary>
        /// function SQL group articles of factures with totals
        /// </summary>
        /// <param name="parameters">the parameters of function</param>
        /// <returns>an enumerable</returns>
        Task<IEnumerable<FacturesArticlesTotals>> GetFacturesArticlesTotals(GetArticlesFacturesParameters parameters);

        /// <summary>
        /// get ventilation chiffre affaires commerciaux
        /// </summary>
        /// <param name="predicate">the filter</param>
        /// <returns>a list of ventilation of commerciaux</returns>
        Task<IEnumerable<VentilationChiffreAffairesCommercial>> GetVentilationChiffreAffairesCommerciaux(Expression<Func<Facture, bool>> predicate);

        /// <summary>
        /// get repartition types travaux par technicien
        /// </summary>
        /// <param name="predicate">the predicate for filter</param>
        /// <returns>an enumerable of repartition types travaux par technicien</returns>
        Task<IEnumerable<RepartitionTypesTravauxParTechnicien>> GetRepartitionTypesTravauxParTechnicien(Expression<Func<DossierInstallation, bool>> predicate);

        /// <summary>
        /// get repartition dossiers par technicien
        /// </summary>
        /// <param name="predicate">the predicate for filter</param>
        /// <returns>an enumerable of repartition dossiers par technicien</returns>
        Task<IEnumerable<RepartitionDossiersTechnicien>> GetRepartitionDossiersTechnicien(Expression<Func<DossierInstallation, bool>> predicate);
    }
}
