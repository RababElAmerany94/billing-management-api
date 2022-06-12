namespace COMPANY.Application.DataInteraction.DataAccess.Accounting
{
    using COMPANY.Application.Data;
    using COMPANY.Application.Models.BusinessEntities.Accounting.Comptabilite;
    using COMPANY.Application.Models.General.FilterOptions;
    using COMPANY.Domain.Entities.Documents;
    using COMPANY.Presistence.Implementations;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// an interface that defines the dataAccess Layer for the accounting document
    /// </summary>
    public interface IComptabiliteDataAccess
    {
        /// <summary>
        /// get sales journal as paged result
        /// </summary>
        /// <param name="factureRequest">the facture request builder</param>
        /// <param name="avoirRequest">the avoir request</param>
        /// <param name="filterOption">the filter options</param>
        /// <returns>a paged result</returns>
        Task<PagedResult<VentesJournalSelectModel>> GetVentesJournalAsPagedResultAsync(
            IDataRequest<Facture> factureRequest,
            IDataRequest<Avoir> avoirRequest,
            VentesJournalFilterOption filterOption);

        /// <summary>
        /// get list sales journal as IEnumerable
        /// </summary>
        /// <param name="factureRequest">the facture request builder</param>
        /// <param name="avoirRequest">the avoir request</param>
        /// <returns>a result instance</returns>
        Task<IEnumerable<VentesJournalSelectModel>> GetVentesJournalAsIEnumerableAsync(
            IDataRequest<Facture> factureRequest,
            IDataRequest<Avoir> avoirRequest);
    }
}
