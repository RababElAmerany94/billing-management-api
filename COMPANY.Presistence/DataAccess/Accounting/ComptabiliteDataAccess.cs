namespace COMPANY.Presistence.DataAccess.Accounting
{
    using COMPANY.Application.Data;
    using COMPANY.Application.DataInteraction.DataAccess.Accounting;
    using COMPANY.Application.Enums;
    using COMPANY.Application.Models.BusinessEntities.Accounting.Comptabilite;
    using COMPANY.Application.Models.General.FilterOptions;
    using COMPANY.Domain.Entities.Documents;
    using COMPANY.Domain.Enums.Documents;
    using COMPANY.Presistence.DataContext;
    using COMPANY.Presistence.Implementations;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ComptabiliteDataAccess : IComptabiliteDataAccess
    {
        private readonly IDataSource _dataSource;

        public ComptabiliteDataAccess(IDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        /// <summary>
        /// get sales journal as paged result
        /// </summary>
        /// <param name="factureRequest">the facture request builder</param>
        /// <param name="avoirRequest">the avoir request</param>
        /// <param name="filterOption">the filter options</param>
        /// <returns>a paged result</returns>
        public async Task<PagedResult<VentesJournalSelectModel>> GetVentesJournalAsPagedResultAsync(
            IDataRequest<Facture> factureRequest,
            IDataRequest<Avoir> avoirRequest,
            VentesJournalFilterOption filterOption)
        {
            return await GetSalesJournalAsIQueryable(factureRequest, avoirRequest)
                        .AsPagedResultAsync(filterOption.Page, filterOption.PageSize);
        }

        /// <summary>
        /// get list sales journal as IEnumerable
        /// </summary>
        /// <param name="factureRequest">the facture request builder</param>
        /// <param name="avoirRequest">the avoir request</param>
        /// <param name="filterOption">the filter options</param>
        /// <returns>a result instance</returns>
        public async Task<IEnumerable<VentesJournalSelectModel>> GetVentesJournalAsIEnumerableAsync(
            IDataRequest<Facture> factureRequest,
            IDataRequest<Avoir> avoirRequest
        )
        {
            return await GetSalesJournalAsIQueryable(factureRequest, avoirRequest)
                        .ToIEnumerableAsync();
        }

        #region private methods

        /// <summary>
        /// get list sales journal as IQueryable
        /// </summary>
        /// <param name="factureRequest">the facture request builder</param>
        /// <param name="avoirRequest">the avoir request</param>
        /// <returns>IQueryable result</returns>
        private IQueryable<VentesJournalSelectModel> GetSalesJournalAsIQueryable(
            IDataRequest<Facture> factureRequest,
            IDataRequest<Avoir> avoirRequest
        )
        {
            var result = _dataSource.Factures
                        .GetWithDataRequest(factureRequest)
                        .Select(facture => new VentesJournalSelectModel
                        {
                            AccountingDocumentId = facture.Id,
                            DateCreation = facture.DateCreation,
                            Reference = facture.Reference,
                            ClientName = $"{facture.Client.FirstName} {facture.Client.LastName}",
                            ClientAccountingCode = facture.Client.CodeComptable,
                            Articles = facture.Articles,
                            TotalTTC = facture.TotalTTC,
                            Type = DocumentComptableType.Facture,
                            IsArticlesAccounting = facture.Type != FactureType.Acompte,
                            Remise = facture.Remise,
                            RemiseType = facture.RemiseType
                        })
                        .Union(
                            _dataSource.Avoirs
                            .GetWithDataRequest(avoirRequest)
                            .Select(avoir => new VentesJournalSelectModel
                            {
                                AccountingDocumentId = avoir.Id,
                                DateCreation = avoir.DateCreation,
                                Reference = avoir.Reference,
                                ClientName = $"{avoir.Client.FirstName} {avoir.Client.LastName}",
                                ClientAccountingCode = avoir.Client.CodeComptable,
                                Articles = avoir.Articles,
                                TotalTTC = avoir.TotalTTC,
                                Type = DocumentComptableType.Avoir,
                                IsArticlesAccounting = true,
                                Remise = avoir.Remise,
                                RemiseType = avoir.RemiseType
                            })
                        )
                        .OrderBy(x => x.DateCreation);

            return result;
        }

        #endregion
    }
}
