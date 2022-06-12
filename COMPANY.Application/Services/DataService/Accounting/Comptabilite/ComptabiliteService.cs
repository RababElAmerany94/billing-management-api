namespace COMPANY.Application.Services.DataService.Accounting.Comptabilite
{
    using COMPANY.Application.Data;
    using COMPANY.Application.DataInteraction.DataAccess;
    using COMPANY.Application.DataInteraction.DataAccess.Accounting;
    using COMPANY.Application.DataInteraction.DataAccess.Base;
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Interfaces;
    using COMPANY.Application.Models.BusinessEntities.Accounting.Comptabilite;
    using COMPANY.Application.Models.General.FilterOptions;
    using COMPANY.Application.Services.DataService.CalculationService;
    using COMPANY.Application.Services.FileService;
    using COMPANY.Application.Utilities;
    using COMPANY.Common.Helpers;
    using COMPANY.Domain.Entities;
    using COMPANY.Domain.Entities.Documents;
    using COMPANY.Domain.Entities.OwnedEntities;
    using COMPANY.Domain.Enums;
    using COMPANY.Domain.Enums.Documents;
    using COMPANY.Domain.Enums.General;
    using COMPANY.Presistence.Implementations;
    using Company.AutoInjection.Attributes;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Inject(typeof(IComptabiliteService), ServiceLifetime.Scoped)]
    public class ComptabiliteService : IComptabiliteService
    {
        private readonly IPaiementDataAccess _paiementDataAccess;
        private readonly IPeriodeComptableDataAccess _periodeComptableDataAccess;
        private readonly ICurrentUserService _currentUser;
        private readonly IDataRequestBuilder<Paiement> _paiementRequestBuilder;
        private readonly IDataRequestBuilder<Facture> _factureRequestBuilder;
        private readonly IDataRequestBuilder<Avoir> _avoirRequestBuilder;
        private readonly IFileService _fileService;
        private readonly ICalculationService _calculationService;
        private readonly IComptabiliteDataAccess _comptabiliteDataAccess;
        private readonly IDataAccess<CategoryProduct, string> _categoryDataAccess;
        private readonly IDocumentParametersDataAccess _documentParametersDataAccess;

        public ComptabiliteService(
            IUnitOfWork unitOfWork,
            ICurrentUserService currentUserService,
            IDataRequestBuilder<Paiement> paiementRequestBuilder,
            IDataRequestBuilder<Facture> factureRequestBuilder,
            IDataRequestBuilder<Avoir> avoirRequestBuilder,
            IFileService fileService,
            ICalculationService calculationService
        )
        {
            _paiementDataAccess = unitOfWork.PaiementDataAccess;
            _periodeComptableDataAccess = unitOfWork.PeriodeComptableDataAccess;
            _comptabiliteDataAccess = unitOfWork.ComptabiliteDataAccess;
            _documentParametersDataAccess = unitOfWork.DocumentParametersDataAccess;
            _categoryDataAccess = unitOfWork.DataAccess<CategoryProduct, string>();
            _currentUser = currentUserService;
            _paiementRequestBuilder = paiementRequestBuilder;
            _factureRequestBuilder = factureRequestBuilder;
            _avoirRequestBuilder = avoirRequestBuilder;
            _fileService = fileService;
            _calculationService = calculationService;
        }

        public async Task<Result<byte[]>> ExportComptesJournalListAsExcelAsync(ComptesJournalFilterOption filterOption)
        {
            var request = await CreatePaiementDataRequestBaseFilterOption(filterOption);
            var result = await _paiementDataAccess.GetAsync(request);
            var journal = FormatComptesJournal(filterOption, result.ToList());
            var file = _fileService.GenerateComptesJournalExcelFile(journal);
            return Result<byte[]>.Success(file, "the file created successful");
        }

        public async Task<Result<byte[]>> ExportVentesJournalListAsExcelAsync(VentesJournalFilterOption filterOption)
        {
            var factureRequest = await CreateFactureDataRequestBaseFilterOption(filterOption);
            var avoirRequest = await CreateAvoirDataRequestBaseFilterOption(filterOption);
            var result = await _comptabiliteDataAccess.GetVentesJournalAsIEnumerableAsync(factureRequest, avoirRequest);
            var journal = await FormatVentesJournal(result.ToList());
            byte[] file = _fileService.GenerateVentesJournalExcelFile(journal);
            return Result<byte[]>.Success(file, "the file created successful");
        }

        public async Task<PagedResult<ComptesJournalModel>> GetComptesJournalAsPagedResultAsync(ComptesJournalFilterOption filterOption)
        {
            var request = await CreatePaiementDataRequestBaseFilterOption(filterOption);
            var paiements = await _paiementDataAccess.GetPagedResultAsync(filterOption, request);
            var journal = FormatComptesJournal(filterOption, paiements.Value.ToList());
            return PagedResult<ComptesJournalModel>.Success(
                journal,
                paiements.CurrentPage,
                paiements.PageCount,
                paiements.PageSize,
                paiements.RowCount);
        }

        public async Task<PagedResult<VentesJournalModel>> GetVentesJournalAsPagedResultAsync(VentesJournalFilterOption filterOption)
        {
            var factureRequest = await CreateFactureDataRequestBaseFilterOption(filterOption);
            var avoirRequest = await CreateAvoirDataRequestBaseFilterOption(filterOption);
            var result = await _comptabiliteDataAccess.GetVentesJournalAsPagedResultAsync(factureRequest, avoirRequest, filterOption);
            var journal = await FormatVentesJournal(result.Value.ToList());
            return PagedResult<VentesJournalModel>.Success(
                journal,
                result.CurrentPage,
                result.PageCount,
                result.PageSize,
                result.RowCount);
        }

        #region private methods

        /// <summary>
        /// build the data request for the payment from the given filter option
        /// </summary>
        /// <param name="filterOption">the filter option</param>
        /// <returns>data request</returns>
        private async Task<IDataRequest<Paiement>> CreatePaiementDataRequestBaseFilterOption(ComptesJournalFilterOption filterOption)
        {
            var predicate = PredicateBuilder.True<Paiement>();

            // searching by reference
            predicate = predicate
                .And(c => c.FacturePaiements.Any(f => (f.Facture.Reference ?? "").Contains(filterOption.SearchQuery)));

            if (_currentUser.IsFollowAgence)
                predicate = predicate.And(c => c.AgenceId == _currentUser.User.AgenceId);
            else
                predicate = predicate.And(c => !c.AgenceId.IsValid());

            if (filterOption.IsForCaisse)
                predicate = predicate.And(c => c.BankAccount.Type == BankAccountType.Caisse);
            else
                predicate = predicate.And(c => c.BankAccount.Type == BankAccountType.CompteBancaire);

            // the date of the first day of the month
            var firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            // filter by period
            var (dateFrom, dateTo) = await _periodeComptableDataAccess.GetDateRangeFromPeriodEnum(
                    _currentUser.User.AgenceId,
                    filterOption.Period,
                    filterOption.DateFrom,
                    filterOption.DateTo
                );

            if (dateFrom.HasValue)
                predicate = predicate.And(c => dateFrom.Value.Date <= c.DatePaiement.Date);

            if (dateTo.HasValue)
                predicate = predicate.And(c => dateTo.Value.Date >= c.DatePaiement.Date);

            return _paiementRequestBuilder
                    .AddPredicate(predicate)
                    .AddInclude(e => e
                        .Include(f => f.FacturePaiements).ThenInclude(f => f.Facture).ThenInclude(c => c.Client)
                        .Include(x => x.RegulationMode)
                        .Include(x => x.BankAccount))
                    .Buil();
        }

        /// <summary>
        /// Format dataset of comptes journal
        /// </summary>
        /// <param name="filterOption"></param>
        /// <param name="paiements"></param>
        /// <returns></returns>
        private List<ComptesJournalModel> FormatComptesJournal(ComptesJournalFilterOption filterOption, List<Paiement> paiements)
        {
            var items = new List<ComptesJournalModel>();

            foreach (var paiement in paiements)
            {
                foreach (var facturePaiement in paiement.FacturePaiements)
                {
                    items.Add(
                        new ComptesJournalModel()
                        {
                            CodeJournal = (filterOption.IsForCaisse ? "CAISSE" : "BANQUE"),
                            DatePaiment = paiement.DatePaiement,
                            NumeroCompte = paiement.BankAccount.CodeComptable,
                            NumeroPiece = facturePaiement.Facture.Reference,
                            Tiers = paiement.BankAccount.Name,
                            Debit = facturePaiement.Montant,
                            Credit = 0,
                            PaimentMethod = paiement.RegulationMode.Name
                        }
                    );
                    items.Add(
                        new ComptesJournalModel()
                        {
                            CodeJournal = (filterOption.IsForCaisse ? "CAISSE" : "BANQUE"),
                            DatePaiment = paiement.DatePaiement,
                            NumeroCompte = facturePaiement.Facture.Client.CodeComptable,
                            NumeroPiece = facturePaiement.Facture.Reference,
                            Tiers = $"{facturePaiement.Facture.Client.FirstName} {facturePaiement.Facture.Client.LastName}",
                            Debit = 0,
                            Credit = facturePaiement.Montant,
                            PaimentMethod = paiement.RegulationMode.Name
                        }
                    );
                }
            }

            return items;
        }

        /// <summary>
        /// build the data request for the facture from the given filter option
        /// </summary>
        /// <param name="filterOption">the filter option</param>
        /// <returns>data request</returns>
        private async Task<IDataRequest<Facture>> CreateFactureDataRequestBaseFilterOption(VentesJournalFilterOption filterOption)
        {
            var predicate = PredicateBuilder.True<Facture>();

            // searching by reference
            predicate = predicate.And(c => c.Reference.Contains(filterOption.SearchQuery));

            // the status must different to brouillon
            predicate = predicate.And(c => c.Status != FactureStatus.Brouillon);

            if (_currentUser.IsFollowAgence)
                predicate = predicate.And(c => c.AgenceId == _currentUser.User.AgenceId);
            else
                predicate = predicate.And(c => !c.AgenceId.IsValid());

            // period
            var (dateFrom, dateTo) = await _periodeComptableDataAccess.GetDateRangeFromPeriodEnum(
                _currentUser.User.Id,
                filterOption.Period,
                filterOption.DateFrom,
                filterOption.DateTo);

            if (dateFrom.HasValue)
                predicate = predicate.And(c => dateFrom.Value.Date <= c.DateCreation.Date);

            if (dateTo.HasValue)
                predicate = predicate.And(c => dateTo.Value.Date >= c.DateCreation.Date);

            return _factureRequestBuilder
                        .AddPredicate(predicate)
                        .AddInclude(e => e.Include(f => f.Client))
                        .Buil();
        }

        /// <summary>
        /// build the data request for the avoir from the given filter option
        /// </summary>
        /// <param name="filterOption">the filter option</param>
        /// <returns>data request</returns>
        private async Task<IDataRequest<Avoir>> CreateAvoirDataRequestBaseFilterOption(VentesJournalFilterOption filterOption)
        {
            var predicate = PredicateBuilder.True<Avoir>();

            // searching by reference
            predicate = predicate.And(c => c.Reference.Contains(filterOption.SearchQuery));

            // the status must different to Brouillon
            predicate = predicate.And(c => c.Status != AvoirStatus.Brouillon);

            if (_currentUser.IsFollowAgence)
                predicate = predicate.And(c => c.AgenceId == _currentUser.User.AgenceId);
            else
                predicate = predicate.And(c => !c.AgenceId.IsValid());

            // period
            var (dateFrom, dateTo) = await _periodeComptableDataAccess.GetDateRangeFromPeriodEnum(
                _currentUser.User.AgenceId,
                filterOption.Period,
                filterOption.DateFrom,
                filterOption.DateTo);

            if (dateFrom.HasValue)
                predicate = predicate.And(c => dateFrom.Value.Date <= c.DateCreation.Date);

            if (dateTo.HasValue)
                predicate = predicate.And(c => dateTo.Value.Date >= c.DateCreation.Date);

            return _avoirRequestBuilder
                        .AddPredicate(predicate)
                        .AddInclude(e => e.Include(f => f.Client))
                        .Buil();
        }

        /// <summary>
        /// format dataset of ventes journal
        /// </summary>
        /// <param name="items">the dataset list of sales journal </param>
        /// <returns>a list formated of ventes journal</returns>
        private async Task<List<VentesJournalModel>> FormatVentesJournal(List<VentesJournalSelectModel> items)
        {
            var categories = (await _categoryDataAccess.GetAsync()).ToList();

            // select TVA accounting code
            var parametrageDocument = await _documentParametersDataAccess.GetByAgenceIdAsync(_currentUser.User.AgenceId);
            var tvaParameters = parametrageDocument.TVA;

            var ventesJournalItems = new List<VentesJournalModel>();

            foreach (var item in items)
            {
                // debit from client
                ventesJournalItems.Add(new VentesJournalModel()
                {
                    CodeJournal = "VEN",
                    DateCreation = item.DateCreation,
                    NumeroCompte = item.ClientAccountingCode,
                    NumeroPiece = item.Reference,
                    ClientName = item.ClientName,
                    Debit = item.TotalTTC,
                    Credit = 0,
                });

                if (item.IsArticlesAccounting)
                {

                    var articles = item.Articles
                                    .Where(e => e.Type == ArticleType.Produit)
                                    .ToList();

                    var calculation = _calculationService.CalculationGeneral(articles, item.Remise, item.RemiseType);
                    var groupArticles = GroupArticlesByCategory(articles, categories, item.Remise, item.RemiseType, calculation.TotalHT);

                    // group TVA
                    foreach (var tva in calculation.CalculationTvas)
                    {
                        if (tva.TotalTVA > 0)
                        {
                            ventesJournalItems.Add(new VentesJournalModel()
                            {
                                CodeJournal = "VEN",
                                DateCreation = item.DateCreation,
                                NumeroCompte = BuildCodeComptableTVA(tva.TVA, tvaParameters),
                                NumeroPiece = item.Reference,
                                ClientName = item.ClientName,
                                Debit = 0,
                                Credit = tva.TotalTVA,
                            });
                        }
                    }

                    // group prestation by category
                    foreach (var groupArticle in groupArticles)
                    {
                        ventesJournalItems.Add(new VentesJournalModel()
                        {
                            CodeJournal = "VEN",
                            DateCreation = item.DateCreation,
                            NumeroCompte = groupArticle.CodeComptable,
                            NumeroPiece = item.Reference,
                            ClientName = item.ClientName,
                            Debit = 0,
                            Credit = groupArticle.TotalHT
                        });
                    }
                }

            }

            return ventesJournalItems;
        }

        /// <summary>
        /// build accounting number of tva
        /// </summary>
        /// <param name="tva"></param>
        /// <param name="tvaParameters"></param>
        /// <returns></returns>
        private string BuildCodeComptableTVA(decimal tva, TvaParameters tvaParameters)
            => $"{tvaParameters.RootAccountingCode}{tvaParameters.List.Where(t => t.Value == tva).FirstOrDefault()?.AccountingCode ?? ""}";

        /// <summary>
        /// group prestations by category
        /// </summary>
        /// <param name="articles">the list of articles</param>
        /// <param name="categories">the list of categories</param>
        /// <param name="remise">the global discount of accounting document</param>
        /// <param name="remiseType">the global discount type of accounting document</param>
        /// <param name="totalWithoutRemise">the total HT without discount</param>
        /// <returns></returns>
        private List<GroupArticles> GroupArticlesByCategory(
            List<Article> articles,
            List<CategoryProduct> categories,
            decimal remise,
            RemiseType remiseType,
            decimal totalWithoutRemise)
        {
            var groupeArticles = articles
                    .GroupBy(e => e.CategoryId)
                    .Select(x => new GroupArticles
                    {
                        TotalHT = _calculationService
                                    .TotalHTArticlesComptabilite(x.Sum(article => article.TotalHT), totalWithoutRemise, remise, remiseType),
                        CodeComptable = x.FirstOrDefault().CategoryId.IsValid()
                                    ? (categories.Where(e => e.Id == x.FirstOrDefault().CategoryId)?.FirstOrDefault()?.Name ?? "")
                                    : string.Empty
                    }).ToList();

            return groupeArticles;
        }

        #endregion
    }
}
