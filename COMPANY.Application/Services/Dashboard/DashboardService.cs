namespace COMPANY.Application.Services.Dashboard
{
    using COMPANY.Application.Data;
    using COMPANY.Application.DataInteraction.DataAccess;
    using COMPANY.Application.DataInteraction.DataAccess.Base;
    using COMPANY.Application.DataInteraction.DataAccess.General;
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Interfaces;
    using COMPANY.Application.Models.BusinessEntitiesModels.AccountModels;
    using COMPANY.Application.Models.General.Dashboard;
    using COMPANY.Application.Models.Generals.Dashboard;
    using COMPANY.Application.Utilities;
    using COMPANY.Common.Helpers;
    using COMPANY.Domain.Entities;
    using COMPANY.Domain.Entities.Documents;
    using COMPANY.Domain.Enums;
    using COMPANY.Domain.Enums.Authentification;
    using COMPANY.Domain.Enums.Documents;
    using Company.AutoInjection.Attributes;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    [Inject(typeof(IDashboardService), ServiceLifetime.Scoped)]
    public class DashboardService : IDashboardService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentUserService;
        private readonly IDataRequestBuilder<Facture> _factureRequestBuilder;
        private readonly IDataRequestBuilder<Avoir> _avoirRequestBuilder;
        private readonly IPeriodeComptableDataAccess _periodeComptableDataAccess;
        private readonly UserTokenInformation _user;
        private readonly IDataAccess<Devis, string> _devisDataAccess;
        private readonly IDataAccess<Facture, string> _factureDataAccess;
        private readonly IDataAccess<Avoir, string> _avoirDataAccess;
        private readonly IDataAccess<Dossier, string> _dossierDataAccess;
        private readonly IDashboardDataAccess _dashboardDataAccess;

        public DashboardService(
            IUnitOfWork unitOfWork,
            ICurrentUserService currentUserService,
            IDataRequestBuilder<Facture> factureRequestBuilder,
            IDataRequestBuilder<Avoir> avoirRequestBuilder
        )
        {
            _unitOfWork = unitOfWork;
            _currentUserService = currentUserService;
            _factureRequestBuilder = factureRequestBuilder;
            _avoirRequestBuilder = avoirRequestBuilder;
            _periodeComptableDataAccess = unitOfWork.PeriodeComptableDataAccess;
            _user = currentUserService.User;
            _devisDataAccess = _unitOfWork.DataAccess<Devis, string>();
            _factureDataAccess = _unitOfWork.DataAccess<Facture, string>();
            _dossierDataAccess = _unitOfWork.DataAccess<Dossier, string>();
            _avoirDataAccess = _unitOfWork.DataAccess<Avoir, string>();
            _dashboardDataAccess = _unitOfWork.DashboardDataAccess;
        }

        /// <summary>
        /// get statistic devis group by status
        /// </summary>
        /// <param name="filterOption">the filter option</param>
        /// <returns>a result instance</returns>
        public async Task<Result<IEnumerable<DocumentStatisticByStatus>>> GetDevisStatistic(DashboardFilterOption filterOption)
        {
            var result = new List<DocumentStatisticByStatus>();

            foreach (var status in Enum.GetValues(typeof(DevisStatus)))
            {
                var predicate = (await BuildPredicateDevis(filterOption))
                    .And(e => e.Status == (DevisStatus)status);

                result.Add(new DocumentStatisticByStatus()
                {
                    Status = (int)status,
                    Count = await _devisDataAccess.GetCountAsync(predicate),
                    Total = await _devisDataAccess.GetSumAsync(e => e.TotalHT, predicate)
                });
            }

            return Result<IEnumerable<DocumentStatisticByStatus>>.Success(result);
        }

        /// <summary>
        /// get statistic facture group by status
        /// </summary>
        /// <param name="filterOption">the filter option</param>
        /// <returns>a result instance</returns>
        public async Task<Result<IEnumerable<DocumentStatisticByStatus>>> GetFactureStatistic(DashboardFilterOption filterOption)
        {
            var result = new List<DocumentStatisticByStatus>();

            foreach (var status in Enum.GetValues(typeof(FactureStatus)))
            {
                var predicate = (await BuildPredicateDocumentComptable<Facture>(filterOption, default))
                    .And(e => e.Status == (FactureStatus)status);

                result.Add(new DocumentStatisticByStatus()
                {
                    Status = (int)status,
                    Count = await _factureDataAccess.GetCountAsync(predicate),
                    Total = await _factureDataAccess.GetSumAsync(e => e.TotalHT, predicate)
                });
            }

            return Result<IEnumerable<DocumentStatisticByStatus>>.Success(result);
        }

        /// <summary>
        /// get statistic avoir group by status
        /// </summary>
        /// <param name="filterOption">the filter option</param>
        /// <returns>a result instance</returns>
        public async Task<Result<IEnumerable<DocumentStatisticByStatus>>> GetAvoirStatistic(DashboardFilterOption filterOption)
        {
            var result = new List<DocumentStatisticByStatus>();

            foreach (var status in Enum.GetValues(typeof(AvoirStatus)))
            {
                var predicate = (await BuildPredicateDocumentComptable<Avoir>(filterOption, default))
                    .And(e => e.Status == (AvoirStatus)status);

                result.Add(new DocumentStatisticByStatus()
                {
                    Status = (int)status,
                    Count = await _avoirDataAccess.GetCountAsync(predicate),
                    Total = await _avoirDataAccess.GetSumAsync(e => e.TotalHT, predicate)
                });
            }
            return Result<IEnumerable<DocumentStatisticByStatus>>.Success(result);
        }

        /// <summary>
        /// get statistic dossier group by status
        /// </summary>
        /// <param name="filterOption">the filter option</param>
        /// <returns>a result instance</returns>
        public async Task<Result<IEnumerable<DocumentStatisticByStatus>>> GetDossierStatistic(DashboardFilterOption filterOption)
        {
            var result = new List<DocumentStatisticByStatus>();

            foreach (var status in Enum.GetValues(typeof(DossierStatus)))
            {
                var predicate = (await BuildPredicateDossier(filterOption))
                    .And(e => e.Status == (DossierStatus)status);

                result.Add(new DocumentStatisticByStatus()
                {
                    Status = (int)status,
                    Count = await _dossierDataAccess.GetCountAsync(predicate),
                    Total = await _dossierDataAccess.GetSumAsync(e => e.Devis.Sum(d => d.TotalHT), predicate)
                });
            }
            return Result<IEnumerable<DocumentStatisticByStatus>>.Success(result);
        }

        /// <summary>
        /// get chiffre d'affaire
        /// </summary>
        /// <param name="filterOption">the filter option</param>
        /// <returns>a result dashboard model</returns>
        public async Task<Result<ChartData>> GetChiffreAffaire(DashboardFilterOption filterOption)
        {
            var result = new ChartData();

            for (int month = 1; month <= 12; month++)
            {
                #region facture
                var predicateFacture = (await BuildPredicateDocumentComptable<Facture>(filterOption, month))
                    .And(e => e.Type != FactureType.Acompte)
                    .And(e => e.Status != FactureStatus.Brouillon);

                var totalFactures = await _factureDataAccess.GetSumAsync(e => e.TotalHT, predicateFacture);
                #endregion

                #region avoir
                var predicateAvoir = (await BuildPredicateDocumentComptable<Avoir>(filterOption, month))
                        .And(e => e.Status != AvoirStatus.Brouillon);
                var totalAvoirs = await _avoirDataAccess.GetSumAsync(e => e.TotalHT, predicateAvoir);
                #endregion

                result.AddItem(month.ToString(), totalFactures + totalAvoirs);
            }

            return Result<ChartData>.Success(result);
        }

        /// <summary>
        /// get classsement clietns
        /// </summary>
        /// <param name="filterOption">the filter option</param>
        /// <returns>a result instance</returns>
        public async Task<Result<IEnumerable<ClassementClient>>> GetClassementClients(DashboardFilterOption filterOption)
        {
            #region facture
            var predicateFacture = (await BuildPredicateDocumentComptable<Facture>(filterOption, default))
                                    .And(e => e.Type != FactureType.Acompte)
                                    .And(e => e.Status != FactureStatus.Brouillon);

            var factureRequest = _factureRequestBuilder
                                    .AddInclude(f => f.Include(e => e.Client))
                                    .AddPredicate(predicateFacture)
                                    .Buil();
            #endregion

            #region avoir
            var predicateAvoir = (await BuildPredicateDocumentComptable<Avoir>(filterOption, default))
                                .And(e => e.Status != AvoirStatus.Brouillon);

            var avoirRequest = _avoirRequestBuilder
                                .AddInclude(f => f.Include(e => e.Client))
                                .AddPredicate(predicateAvoir)
                                .Buil();
            #endregion

            var result = await _dashboardDataAccess.GetClassementClients(
                factureRequest,
                avoirRequest);

            return Result<IEnumerable<ClassementClient>>.Success(result);
        }

        /// <summary>
        /// get chiffre d'affaire restant à encaisser
        /// </summary>
        /// <param name="filterOption">the filter option</param>
        /// <returns>a result instance</returns>
        public async Task<Result<decimal>> GetChiffreAffaireRestantAencaisser(DashboardFilterOption filterOption)
        {
            var predicateFacture = (await BuildPredicateDocumentComptable<Facture>(filterOption, default))
                                .And(e => e.Type != FactureType.Acompte)
                                .And(e => e.Status == FactureStatus.Encours || e.Status == FactureStatus.Enretard);

            var totalFactures = await _factureDataAccess.GetSumAsync(e => e.TotalTTC, predicateFacture);
            var totalPaiementsFactures = await _factureDataAccess
                .GetSumAsync(e => e.FacturePaiements.Sum(f => f.Montant), predicateFacture);

            var result = totalFactures - totalPaiementsFactures;
            return Result<decimal>.Success(result);
        }

        /// <summary>
        /// get articles of factures by category
        /// </summary>
        /// <param name="filterOption">the filter option</param>
        /// <returns>an result instance</returns>
        public async Task<Result<IEnumerable<FacturesArticlesByCategory>>> GetFacturesArticlesByCategory(FacturesArticlesByCategoryFilterOption filterOption)
        {
            var parameters = await MapDashboardFilterToGetArticleFactureParametres(filterOption);
            var result = await _dashboardDataAccess.GetFacturesArticlesByCategory(parameters, filterOption.CategoryId);
            return Result<IEnumerable<FacturesArticlesByCategory>>.Success(result);
        }

        /// <summary>
        /// get articles of factures with totals
        /// </summary>
        /// <param name="filterOption">the filter option</param>
        /// <returns>an result instance</returns>
        public async Task<Result<IEnumerable<FacturesArticlesTotals>>> GetFacturesArticlesTotals(AdvanceDashboardFilterOption filterOption)
        {
            var parameters = await MapDashboardFilterToGetArticleFactureParametres(filterOption);
            var result = await _dashboardDataAccess.GetFacturesArticlesTotals(parameters);
            return Result<IEnumerable<FacturesArticlesTotals>>.Success(result);
        }

        /// <summary>
        /// get articles of factures with quantities
        /// </summary>
        /// <param name="filterOption">the filter option</param>
        /// <returns>an result instance</returns>
        public async Task<Result<IEnumerable<FacturesArticlesQuantities>>> GetFacturesArticlesQuantities(AdvanceDashboardFilterOption filterOption)
        {
            var parameters = await MapDashboardFilterToGetArticleFactureParametres(filterOption);
            var result = await _dashboardDataAccess.GetFacturesArticlesQuantities(parameters);
            return Result<IEnumerable<FacturesArticlesQuantities>>.Success(result);
        }

        /// <summary>
        /// get ventilation chiffre affaires commerciaux
        /// </summary>
        /// <param name="filterOption">the filter option</param>
        /// <returns>a list of ventilation of commerciaux</returns>
        public async Task<Result<IEnumerable<VentilationChiffreAffairesCommercial>>> GetVentilationChiffreAffairesCommerciaux(AdvanceDashboardFilterOption filterOption)
        {
            var predicate = (await BuildPredicateDocumentComptable<Facture>(filterOption, default))
                        .And(e => e.Type != FactureType.Acompte)
                        .And(e => e.Status != FactureStatus.Brouillon || e.Status == FactureStatus.Annulee);
            var result = await _dashboardDataAccess.GetVentilationChiffreAffairesCommerciaux(predicate);
            return Result<IEnumerable<VentilationChiffreAffairesCommercial>>.Success(result);
        }

        /// <summary>
        /// get repartition types travaux par technicien
        /// </summary>
        /// <param name="filterOption">the filter option</param>
        /// <returns>an enumerable of repartition types travaux par technicien</returns>
        public async Task<Result<IEnumerable<RepartitionTypesTravauxParTechnicien>>> GetRepartitionTypesTravauxParTechnicien(AdvanceDashboardFilterOption filterOption)
        {
            var predicate = await BuildPredicateDossierInstallation(filterOption);
            var result = await _dashboardDataAccess.GetRepartitionTypesTravauxParTechnicien(predicate);
            return Result<IEnumerable<RepartitionTypesTravauxParTechnicien>>.Success(result);
        }

        /// <summary>
        /// get repartition dossiers par technicien
        /// </summary>
        /// <param name="filterOption">the filter option</param>
        /// <returns>a result enumerable of repartition dossiers par technicien</returns>
        public async Task<Result<IEnumerable<RepartitionDossiersTechnicien>>> GetRepartitionDossiersTechnicien(AdvanceDashboardFilterOption filterOption)
        {
            var predicate = await BuildPredicateDossierInstallation(filterOption);
            var result = await _dashboardDataAccess.GetRepartitionDossiersTechnicien(predicate);
            return Result<IEnumerable<RepartitionDossiersTechnicien>>.Success(result);
        }

        /// <summary>
        /// count dossiers of a client
        /// </summary>
        /// <param name="filterOption">the filter option</param>
        /// <returns>a result count</returns>
        public async Task<Result<int>> GetCountDossiers(DashboardFilterOption filterOption)
        {
            var predicate = await BuildPredicateDossier(filterOption);
            var count = await _dossierDataAccess.GetCountAsync(predicate);
            return Result<int>.Success(count);
        }

        #region private method

        /// <summary>
        /// build data request document comptable
        /// </summary>
        /// <param name="filterOption">the filter options</param>
        /// <param name="month">the month</param>
        /// <returns>a data request</returns>
        private async Task<Expression<Func<T, bool>>> BuildPredicateDocumentComptable<T>(DashboardFilterOption filterOption, int? month) where T : DocumentComptable
        {
            var predicate = PredicateBuilder.True<T>();

            var (dateFrom, dateTo) = await _periodeComptableDataAccess.GetDateRangeFromPeriodEnum(
                   _user.AgenceId,
                   filterOption.Period,
                   filterOption.DateFrom,
                   filterOption.DateTo
               );

            if (dateFrom.HasValue)
                predicate = predicate.And(e => dateFrom.Value.Date <= e.CreatedOn.Date);

            if (dateTo.HasValue)
                predicate = predicate.And(e => e.CreatedOn.Date <= dateTo.Value.Date);

            if (month.HasValue)
                predicate = predicate.And(e => e.DateCreation.Date.Month == month);

            if (filterOption.ClientId.IsValid())
                predicate = predicate.And(e => e.ClientId == filterOption.ClientId);

            if (filterOption.AgenceId.IsValid())
                predicate = predicate.And(e => e.AgenceId == filterOption.AgenceId);

            if (_currentUserService.IsFollowAgence)
                predicate = predicate.And(e => e.AgenceId == _user.AgenceId);
            else
            {
                if (filterOption.AgenceId.IsValid())
                    predicate = predicate.And(e => e.AgenceId.IsValid());
                else
                    predicate = predicate.And(e => !e.AgenceId.IsValid());
            }

            return predicate;
        }

        /// <summary>
        /// build data request devis
        /// </summary>
        /// <param name="filterOption">the filter options</param>
        /// <returns>a data request</returns>
        private async Task<Expression<Func<Devis, bool>>> BuildPredicateDevis(DashboardFilterOption filterOption)
        {
            var predicate = PredicateBuilder.True<Devis>();

            var (dateFrom, dateTo) = await _periodeComptableDataAccess.GetDateRangeFromPeriodEnum(
                   _user.AgenceId,
                   filterOption.Period,
                   filterOption.DateFrom,
                   filterOption.DateTo
               );

            if (dateFrom.HasValue)
                predicate = predicate.And(e => dateFrom.Value.Date <= e.CreatedOn.Date);

            if (dateTo.HasValue)
                predicate = predicate.And(e => e.CreatedOn.Date <= dateTo.Value.Date);

            if (filterOption.ClientId.IsValid())
                predicate = predicate.And(e => e.ClientId == filterOption.ClientId);

            if (filterOption.AgenceId.IsValid())
                predicate = predicate.And(e => e.AgenceId == filterOption.AgenceId);

            if (_currentUserService.IsFollowAgence)
                predicate = predicate.And(e => e.AgenceId == _user.AgenceId);
            else
            {
                if (filterOption.AgenceId.IsValid())
                    predicate = predicate.And(e => e.AgenceId.IsValid());
                else
                    predicate = predicate.And(e => !e.AgenceId.IsValid());
            }

            return predicate;
        }

        /// <summary>
        /// build data request dossier
        /// </summary>
        /// <param name="filterOption">the filter options</param>
        /// <returns>a data request</returns>
        private async Task<Expression<Func<Dossier, bool>>> BuildPredicateDossier(DashboardFilterOption filterOption)
        {
            var predicate = PredicateBuilder.True<Dossier>();

            var (dateFrom, dateTo) = await _periodeComptableDataAccess.GetDateRangeFromPeriodEnum(
                 _user.AgenceId,
                 filterOption.Period,
                 filterOption.DateFrom,
                 filterOption.DateTo
             );

            if (dateFrom.HasValue)
                predicate = predicate.And(e => dateFrom.Value.Date <= e.CreatedOn.Date);

            if (dateTo.HasValue)
                predicate = predicate.And(e => e.CreatedOn.Date <= dateTo.Value.Date);

            if (filterOption.ClientId.IsValid())
                predicate = predicate.And(e => e.ClientId == filterOption.ClientId);

            if (filterOption.AgenceId.IsValid())
                predicate = predicate.And(e => e.AgenceId == filterOption.AgenceId);

            if (_currentUserService.IsFollowAgence)
                predicate = predicate.And(e => e.AgenceId == _user.AgenceId);
            else
            {
                if (filterOption.AgenceId.IsValid())
                    predicate = predicate.And(e => e.AgenceId.IsValid());
                else
                    predicate = predicate.And(e => !e.AgenceId.IsValid());
            }

            return predicate;
        }

        /// <summary>
        /// build data request dossier
        /// </summary>
        /// <param name="filterOption">the filter options</param>
        /// <returns>a data request</returns>
        private async Task<Expression<Func<DossierInstallation, bool>>> BuildPredicateDossierInstallation(AdvanceDashboardFilterOption filterOption)
        {
            var predicate = PredicateBuilder.True<DossierInstallation>();

            var (dateFrom, dateTo) = await _periodeComptableDataAccess.GetDateRangeFromPeriodEnum(
                 _user.AgenceId,
                 filterOption.Period,
                 filterOption.DateFrom,
                 filterOption.DateTo
             );

            if (dateFrom.HasValue)
                predicate = predicate.And(e => dateFrom.Value.Date <= e.Dossier.CreatedOn.Date);

            if (dateTo.HasValue)
                predicate = predicate.And(e => e.Dossier.CreatedOn.Date <= dateTo.Value.Date);

            if (filterOption.ClientId.IsValid())
                predicate = predicate.And(e => e.Dossier.ClientId == filterOption.ClientId);

            if (filterOption.AgenceId.IsValid())
                predicate = predicate.And(e => e.Dossier.AgenceId == filterOption.AgenceId);

            if (filterOption.UserId.IsValid())
                predicate = predicate.And(e => e.TechnicienId == filterOption.UserId);

            if (_currentUserService.IsFollowAgence)
                predicate = predicate.And(e => e.Dossier.AgenceId == _user.AgenceId);
            else
            {
                if (filterOption.AgenceId.IsValid())
                    predicate = predicate.And(e => e.Dossier.AgenceId.IsValid());
                else
                    predicate = predicate.And(e => !e.Dossier.AgenceId.IsValid());
            }

            switch (_user.RoleId)
            {
                default:
                case UserRole.Controleur:
                case UserRole.Directeur:
                case UserRole.AdminAgence:
                case UserRole.Admin:
                    break;
                case UserRole.Technicien:
                    predicate = predicate.And(e => e.TechnicienId == _user.Id);
                    break;
                case UserRole.Commercial:
                    predicate = predicate.And(e => e.Dossier.CommercialId.IsValid() && e.Dossier.CommercialId == _user.Id);
                    break;
            }

            return predicate;
        }


        /// <summary>
        /// map dashboard filter to get articles factures parameters
        /// </summary>
        /// <param name="filterOption"></param>
        /// <returns></returns>
        private async Task<GetArticlesFacturesParameters> MapDashboardFilterToGetArticleFactureParametres(AdvanceDashboardFilterOption filterOption)
        {
            var (dateFrom, dateTo) = await _periodeComptableDataAccess.GetDateRangeFromPeriodEnum(
                 _user.AgenceId,
                 filterOption.Period,
                 filterOption.DateFrom,
                 filterOption.DateTo
             );

            return new GetArticlesFacturesParameters()
            {
                DateFrom = dateFrom,
                DateTo = dateTo,
                ClientId = filterOption.ClientId,
                AgenceId = filterOption.AgenceId.IsValid() ? filterOption.AgenceId : _currentUserService.User.AgenceId,
                InAgencesData = false,
                UserId = filterOption.UserId,
                Status = new List<FactureStatus>() {
                    FactureStatus.Cloturee,
                    FactureStatus.Enretard,
                    FactureStatus.Encours
                }
            };
        }

        #endregion
    }
}
