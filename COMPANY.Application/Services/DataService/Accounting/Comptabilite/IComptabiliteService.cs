namespace COMPANY.Application.Services.DataService.Accounting.Comptabilite
{
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Models.BusinessEntities.Accounting.Comptabilite;
    using COMPANY.Application.Models.General.FilterOptions;
    using COMPANY.Presistence.Implementations;
    using System.Threading.Tasks;

    /// <summary>
    /// the interface that defines a set of services for the Accounting
    /// </summary>
    public interface IComptabiliteService
    {
        /// <summary>
        /// get the list of sales journal as paged Result
        /// </summary>
        /// <param name="filterOption">the filter option</param>
        /// <returns>a paged result</returns>
        Task<PagedResult<VentesJournalModel>> GetVentesJournalAsPagedResultAsync(VentesJournalFilterOption filterOption);

        /// <summary>
        /// export the list of sales journal as an excel file
        /// </summary>
        /// <param name="filterOption">the filter option</param>
        /// <returns>the result instant</returns>
        Task<Result<byte[]>> ExportVentesJournalListAsExcelAsync(VentesJournalFilterOption filterOption);

        /// <summary>
        /// get the list of accounts journal as paged Result
        /// </summary>
        /// <param name="filterOption">the filter option</param>
        /// <returns>a paged result</returns>
        Task<PagedResult<ComptesJournalModel>> GetComptesJournalAsPagedResultAsync(ComptesJournalFilterOption filterOption);

        /// <summary>
        /// export the list of accounts journal as an excel file
        /// </summary>
        /// <param name="filterOption">the filter option</param>
        /// <returns>the result instant</returns>
        Task<Result<byte[]>> ExportComptesJournalListAsExcelAsync(ComptesJournalFilterOption filterOption);
    }
}
