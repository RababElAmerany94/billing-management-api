namespace COMPANY.Presistence.DataContext
{
    using COMPANY.Application.Models.BusinessEntities.Parameters.AccountingPeriod;
    using COMPANY.Application.Models.General.Dashboard;
    using COMPANY.Domain.Entities;
    using COMPANY.Domain.Entities.Documents;
    using COMPANY.Domain.Entities.Generals;
    using COMPANY.Domain.Entities.OwnedEntities;
    using COMPANY.Domain.Entities.Parameters;
    using COMPANY.Domain.Entities.Relations;
    using COMPANY.Domain.Enums.Documents;
    using COMPANY.Helpers;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// the Application DbContext, should implement <see cref="IDataSource"/>
    /// </summary>
    public class CompanyDbContext : DbContext, IDataSource
    {
        #region DbSets
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Departement> Departements { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Fournisseur> Fournisseurs { get; set; }
        public DbSet<Numerotation> Numerotations { get; set; }
        public DbSet<RegulationMode> RegulationModes { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<ConfigMessagerie> ConfigMessageries { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionModule> PermissionModules { get; set; }
        public DbSet<RoleModule> RolesModules { get; set; }
        public DbSet<Produit> Produits { get; set; }
        public DbSet<PrixProduitParAgence> PrixProduitParAgences { get; set; }
        public DbSet<DocumentParameters> DocumentParameters { get; set; }
        public DbSet<PeriodeComptable> PeriodeComptables { get; set; }
        public DbSet<SpecialArticle> SpecialArticles { get; set; }
        public DbSet<Dossier> Dossiers { get; set; }
        public DbSet<DossierInstallation> DossierInstallations { get; set; }
        public DbSet<Devis> Devis { get; set; }
        public DbSet<Unite> Unites { get; set; }
        public DbSet<CategoryProduct> CategoryProducts { get; set; }
        public DbSet<DossierPV> DossierPVs { get; set; }
        public DbSet<FicheControle> FicheControles { get; set; }
        public DbSet<LogementType> LogementTypes { get; set; }
        public DbSet<Facture> Factures { get; set; }
        public DbSet<Avoir> Avoirs { get; set; }
        public DbSet<Paiement> Paiements { get; set; }
        public DbSet<FacturePaiement> FacturePaiements { get; set; }
        public DbSet<FactureDevis> FactureDevis { get; set; }
        public DbSet<AgendaEvenement> AgendaEvenements { get; set; }
        public DbSet<EchangeCommercial> EchangeCommercials { get; set; }
        public DbSet<GoogleCalendarEchangeCommercial> GoogleCalendarEchangeCommercials { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<TypeChauffage> TypeChauffage { get; set; }
        public DbSet<Sms> Sms { get; set; }
        public DbSet<ClientRelation> ClientRelations { get; set; }
        public DbSet<ChampSiteInstallation> ChampsSiteInstallation { get; set; }
        public DbSet<BonCommande> BonsCommandes { get; set; }
        public DbSet<ClientCommercial> ClientCommercials { get; set; }

        #endregion

        /// <summary>
        /// default constructor with option builder
        /// </summary>
        /// <param name="options">the options builder</param>
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        /// <summary>
        /// used for configuring entities
        /// </summary>
        /// <param name="modelBuilder">the model builder</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyStringDefaultSize()
                .ApplyBaseEntityConfiguration()
                .ApplyAllConfigurations();

            // Register store procedure custom object.  
            modelBuilder.Query<ClotureComptableResultModel>();
            modelBuilder.Query<FacturesArticles>();
        }

        /// <summary>
        /// save changes override
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<Entity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedOn = DateTime.Now;
                        entry.Entity.BuildSearchTerms();
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedOn = DateTime.Now;
                        entry.Entity.BuildSearchTerms();
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// cloture comptable
        /// </summary>
        /// <param name="dateStart">the date of start</param>
        /// <param name="dateEnd">the date of end</param>
        /// <param name="agenceId">the agence id</param>
        /// <returns>a result number</returns>
        public async Task<int> ClotureComptable(DateTime dateStart, DateTime dateEnd, string agenceId)
        {
            var parameters = new object[] {
                dateStart.ToString("yyyy-MM-dd"),
                dateEnd.ToString("yyyy-MM-dd"),
                agenceId ?? string.Empty
            };

            var result = await Query<ClotureComptableResultModel>()
                .FromSql("CALL ClotureComptable(@p0,@p1,@p2)", parameters)
                .ToListAsync();

            return result.Count;
        }

        /// <summary>
        /// function sql group articles of factures
        /// </summary>
        /// <param name="parameters">the parameters of function</param>
        /// <returns>list articles</returns>
        public async Task<List<Article>> GetArticlesFactures(GetArticlesFacturesParameters parameters)
        {
            var funcParamters = new object[] {
                parameters.DateFrom.HasValue ? parameters.DateFrom.Value.ToString("yyyy-MM-dd") : null,
                parameters.DateTo.HasValue ? parameters.DateTo.Value.ToString("yyyy-MM-dd") : null,
                parameters.InAgencesData,
                parameters.ClientId ?? string.Empty,
                parameters.UserId ?? string.Empty,
                parameters.AgenceId ?? string.Empty,
                string.Join(",",parameters.Status.Select(e=> (int)e))
            };

            var call = "CALL GetArticlesFactures(@p0,@p1,@p2,@p3,@p4,@p5,@p6)";

            var result = await Query<FacturesArticles>()
                .FromSql(call, funcParamters)
                .ToListAsync();

            var articles = result.First().Articles;

            if (articles is null)
                return new List<Article>();

            var articlesFormatString = Encoding.ASCII.GetString(articles);

            return articlesFormatString
                 .FromJson<List<Article>>();
        }

    }
}
