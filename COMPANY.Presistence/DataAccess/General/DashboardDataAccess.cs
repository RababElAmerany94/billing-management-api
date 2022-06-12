namespace COMPANY.Presistence.DataAccess.General
{
    using COMPANY.Application.Data;
    using COMPANY.Application.DataInteraction.DataAccess.General;
    using COMPANY.Application.Models.General.Dashboard;
    using COMPANY.Application.Models.Generals.Dashboard;
    using COMPANY.Common.Helpers;
    using COMPANY.Domain.Entities;
    using COMPANY.Domain.Entities.Documents;
    using COMPANY.Domain.Entities.OwnedEntities;
    using COMPANY.Domain.Enums;
    using COMPANY.Presistence.DataContext;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Internal;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public class DashboardDataAccess : IDashboardDataAccess
    {
        private readonly IDataSource _dataSource;

        public DashboardDataAccess(IDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        /// <summary>
        /// get classement clients
        /// </summary>
        /// <param name="factureRequest">the facture request builder</param>
        /// <param name="avoirRequest">the avoir request</param>
        /// <returns>an enumerable/returns>
        public async Task<IEnumerable<ClassementClient>> GetClassementClients(
            IDataRequest<Facture> factureRequest,
            IDataRequest<Avoir> avoirRequest
        )
        {
            var result = await _dataSource.Factures
                        .GetWithDataRequest(factureRequest)
                        .Select(e => new ClassementClient
                        {
                            Client = $"{e.Client.FirstName} {e.Client.LastName}",
                            ClientId = e.ClientId,
                            TotalHT = e.TotalHT
                        })
                        .Union(
                            _dataSource.Avoirs
                            .GetWithDataRequest(avoirRequest)
                            .Select(e => new ClassementClient
                            {
                                Client = $"{e.Client.FirstName} {e.Client.LastName}",
                                ClientId = e.ClientId,
                                TotalHT = e.TotalHT
                            })
                        )
                        .Select(e => new ClassementClient
                        {
                            Client = e.Client,
                            ClientId = e.ClientId,
                            TotalHT = e.TotalHT
                        })
                        .GroupBy(e => e.ClientId)
                        .Select(e => new ClassementClient
                        {
                            Client = e.First().Client,
                            ClientId = e.Key,
                            TotalHT = e.Sum(d => d.TotalHT)
                        })
                        .OrderByDescending(e => e.TotalHT)
                        .Take(10)
                        .ToListAsync();

            return result;
        }

        /// <summary>
        /// function SQL group articles of factures by category
        /// </summary>
        /// <param name="parameters">the parameters of function</param>
        /// <param name="categoryId">the id of category</param>
        /// <returns>an enumerable</returns>
        public async Task<IEnumerable<FacturesArticlesByCategory>> GetFacturesArticlesByCategory(GetArticlesFacturesParameters parameters, string categoryId)
        {
            var predicate = PredicateBuilder.True<Article>()
                .And(e => e.Category != null);

            if (categoryId.IsValid())
                predicate = predicate.And(e => e.CategoryId == categoryId);

            var result = (await _dataSource.GetArticlesFactures(parameters))
                .Where(predicate.Compile())
                .Select(e => new FacturesArticlesByCategory
                {
                    Name = e.Category.Name,
                    Quantity = e.Qte,
                    Total = e.TotalHT
                })
                .GroupBy(e => e.Name)
                .Select(g => new FacturesArticlesByCategory()
                {
                    Name = g.Key,
                    Quantity = g.Sum(e => e.Quantity),
                    Total = g.Sum(e => e.Total)
                });

            return result;
        }

        /// <summary>
        /// function SQL group articles of factures with quantities
        /// </summary>
        /// <param name="parameters">the parameters of function</param>
        /// <returns>an enumerable</returns>
        public async Task<IEnumerable<FacturesArticlesQuantities>> GetFacturesArticlesQuantities(GetArticlesFacturesParameters parameters)
            => (await _dataSource.GetArticlesFactures(parameters))
                .GroupBy(e => e.Designation)
                .Select(e => new FacturesArticlesQuantities
                {
                    Name = e.Key,
                    Quantity = e.Sum(a => a.Qte)
                });

        /// <summary>
        /// function SQL group articles of factures with totals
        /// </summary>
        /// <param name="parameters">the parameters of function</param>
        /// <returns>an enumerable</returns>
        public async Task<IEnumerable<FacturesArticlesTotals>> GetFacturesArticlesTotals(GetArticlesFacturesParameters parameters)
         => (await _dataSource.GetArticlesFactures(parameters))
                .GroupBy(e => e.Designation)
                .Select(e => new FacturesArticlesTotals
                {
                    Name = e.Key,
                    Total = e.Sum(a => a.TotalHT)
                });

        /// <summary>
        /// get ventilation chiffre affaires commerciaux
        /// </summary>
        /// <param name="predicate">the filter</param>
        /// <returns>a list of ventilation of commerciaux</returns>
        public async Task<IEnumerable<VentilationChiffreAffairesCommercial>> GetVentilationChiffreAffairesCommerciaux(Expression<Func<Facture, bool>> predicate)
        {
            var factureDatasource = await _dataSource
                .Factures
                .Where(predicate)
                .Join(_dataSource.FactureDevis, e => e.Id, e => e.FactureId, (facture, factureDevis) => new
                {
                    Id = facture.Id,
                    Month = facture.DateCreation.Month,
                    TotalHT = facture.TotalHT,
                    DevisId = factureDevis.DevisId
                })
                .ToListAsync();

            var devisDossiers = await _dataSource.Dossiers.Where(e => e.CommercialId.IsValid())
                .Select(e => new
                {
                    CommercialId = e.CommercialId,
                    Commercial = $"{e.Commercial.LastName} {e.Commercial.FirstName}",
                    Id = e.Id
                })
                .Join(_dataSource.Devis.Where(e => e.Status == DevisStatus.Facture), e => e.Id, e => e.DossierId, (dossier, devis) => new
                {
                    CommercialId = dossier.CommercialId,
                    Commercial = dossier.Commercial,
                    DossierId = dossier.Id,
                    DevisId = devis.Id
                })
                .ToListAsync();

            var result = devisDossiers.Join(factureDatasource, e => e.DevisId, e => e.DevisId,
                (dossierDevis, facture) => new
                {
                    CommercialId = dossierDevis.CommercialId,
                    Commercial = dossierDevis.Commercial,
                    FactureId = facture.Id,
                    TotalHT = facture.TotalHT,
                    Month = facture.Month
                })
                .GroupBy(e => new { e.CommercialId, e.Month })
                .Select(e => new
                {
                    Commercial = $"{e.First().Commercial}",
                    CommercialId = e.Key.CommercialId,
                    Month = e.Key.Month,
                    TotalHT = e.Sum(g => g.TotalHT)
                })
                .GroupBy(e => e.CommercialId)
                .Select(e => new VentilationChiffreAffairesCommercial
                {
                    CommercialId = e.Key,
                    Commercial = $"{e.First().Commercial}",
                    TotalHT = e.Sum(g => g.TotalHT),
                    DataParMois = e.Select(g => new ChiffreAffaireParMois
                    {
                        Month = g.Month,
                        TotalHT = g.TotalHT
                    })
                })
                .ToList();

            return result;
        }

        /// <summary>
        /// get repartition types travaux par technicien
        /// </summary>
        /// <param name="predicate">the predicate for filter</param>
        /// <returns>an enumerable of repartition types travaux par technicien</returns>
        public async Task<IEnumerable<RepartitionTypesTravauxParTechnicien>> GetRepartitionTypesTravauxParTechnicien(Expression<Func<DossierInstallation, bool>> predicate)
        {
            var dataSource = _dataSource
            .DossierInstallations
            .Include(e => e.Dossier)
            .Include(e => e.Technicien)
            .Where(predicate)
            .Where(e => e.Dossier.SurfaceTraiter.HasValue && e.Dossier.TypeTravaux.HasValue)
            .Select(e => new
            {
                TechnicienId = e.TechnicienId,
                Technicien = $"{e.Technicien.LastName} {e.Technicien.FirstName}",
                SurfaceTraiter = e.Dossier.SurfaceTraiter.Value,
                TypeTravaux = e.Dossier.TypeTravaux.Value
            });

            var dataSourceGroupByTechnicienAndTypeTravaux = await dataSource
                .GroupBy(e => new { e.TechnicienId, e.TypeTravaux })
                .Select(e => new
                {
                    Technicien = e.First().Technicien,
                    TechnicienId = e.Key.TechnicienId,
                    SurfaceTraiter = e.Sum(s => s.SurfaceTraiter),
                    TypeTravaux = e.Key.TypeTravaux
                })
                .ToListAsync();


            var result = dataSourceGroupByTechnicienAndTypeTravaux
                .GroupBy(e => e.TechnicienId)
                .Select(e => new RepartitionTypesTravauxParTechnicien
                {
                    TechnicienId = e.Key,
                    Technicien = $"{e.First().Technicien}",
                    SurfaceTraiter = e.Sum(g => g.SurfaceTraiter),
                    SurfaceParTypeTravaux = e.Select(g => new SurfaceParTypeTravaux
                    {
                        TypeTravaux = g.TypeTravaux,
                        SurfaceTraiter = g.SurfaceTraiter
                    })
                })
                .ToList();

            return result;
        }

        /// <summary>
        /// get repartition dossiers par technicien
        /// </summary>
        /// <param name="predicate">the predicate for filter</param>
        /// <returns>an enumerable of repartition dossiers par technicien</returns>
        public async Task<IEnumerable<RepartitionDossiersTechnicien>> GetRepartitionDossiersTechnicien(Expression<Func<DossierInstallation, bool>> predicate)
        {
            var dataSource = _dataSource
               .DossierInstallations
               .Include(e => e.Technicien)
               .Where(predicate)
               .Select(e => new
               {
                   TechnicienId = e.TechnicienId,
                   Technicien = $"{e.Technicien.LastName} {e.Technicien.FirstName}",
               });

            var result = await dataSource
                .GroupBy(e => e.TechnicienId)
                .Select(e => new RepartitionDossiersTechnicien
                {
                    Technicien = e.First().Technicien,
                    TechnicienId = e.Key,
                    NombreDossiers = e.Count()
                })
                .ToListAsync();

            return result;
        }

    }
}
