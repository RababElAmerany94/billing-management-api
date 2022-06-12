namespace COMPANY.Presistence.DataContext
{
    using COMPANY.Application.Models.General.Dashboard;
    using COMPANY.Domain.Entities.Documents;
    using COMPANY.Domain.Entities.Generals;
    using COMPANY.Domain.Entities.OwnedEntities;
    using COMPANY.Domain.Entities.Parameters;
    using COMPANY.Domain.Entities.Relations;
    using COMPANY.Domain.Enums.Documents;
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// represent a data Source in case of entity framework this will be a DbContext
    /// </summary>
    public interface IDataSource : IDisposable
    {
        #region DbSets, here we define all the Entities DbSets
        DbSet<User> Users { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<Client> Clients { get; set; }
        DbSet<Departement> Departements { get; set; }
        DbSet<Country> Countries { get; set; }
        DbSet<Fournisseur> Fournisseurs { get; set; }
        DbSet<Numerotation> Numerotations { get; set; }
        DbSet<RegulationMode> RegulationModes { get; set; }
        DbSet<BankAccount> BankAccounts { get; set; }
        DbSet<ConfigMessagerie> ConfigMessageries { get; set; }
        DbSet<Module> Modules { get; set; }
        DbSet<Permission> Permissions { get; set; }
        DbSet<RoleModule> RolesModules { get; set; }
        DbSet<Produit> Produits { get; set; }
        DbSet<PrixProduitParAgence> PrixProduitParAgences { get; set; }
        DbSet<DocumentParameters> DocumentParameters { get; set; }
        DbSet<PeriodeComptable> PeriodeComptables { get; set; }
        DbSet<SpecialArticle> SpecialArticles { get; set; }
        DbSet<Dossier> Dossiers { get; set; }
        DbSet<DossierInstallation> DossierInstallations { get; set; }
        DbSet<Devis> Devis { get; set; }
        DbSet<Unite> Unites { get; set; }
        DbSet<CategoryProduct> CategoryProducts { get; set; }
        DbSet<AgendaEvenement> AgendaEvenements { get; set; }
        DbSet<DossierPV> DossierPVs { get; set; }
        DbSet<FicheControle> FicheControles { get; set; }
        DbSet<LogementType> LogementTypes { get; set; }
        DbSet<Facture> Factures { get; set; }
        DbSet<Avoir> Avoirs { get; set; }
        DbSet<Paiement> Paiements { get; set; }
        DbSet<FacturePaiement> FacturePaiements { get; set; }
        DbSet<FactureDevis> FactureDevis { get; set; }
        DbSet<EchangeCommercial> EchangeCommercials { get; set; }
        DbSet<Notification> Notifications { get; set; }
        DbSet<TypeChauffage> TypeChauffage { get; set; }
        DbSet<Sms> Sms { get; set; }
        DbSet<BonCommande> BonsCommandes { get; set; }
        DbSet<ClientCommercial> ClientCommercials { get; set; }

        #endregion

        /// <summary>
        /// cloture comptable
        /// </summary>
        /// <param name="dateStart">the date of start</param>
        /// <param name="dateEnd">the date of end</param>
        /// <param name="agenceId">the agence id</param>
        /// <returns>a result number</returns>
        Task<int> ClotureComptable(DateTime dateStart, DateTime dateEnd, string agenceId);

        /// <summary>
        /// function sql group articles of factures by category
        /// </summary>
        /// <param name="parameters">the parameters of function</param>
        /// <returns>list articles</returns>
        Task<List<Article>> GetArticlesFactures(GetArticlesFacturesParameters parameters);

        /// <summary>
        /// get the DbSet of the given entity
        /// </summary>
        /// <typeparam name="TEntity">the entity type</typeparam>
        /// <returns>a DbSet</returns>
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        /// <summary>
        /// save the changes to data source
        /// </summary>
        /// <returns>affected lines</returns>
        int SaveChanges();

        /// <summary>
        /// save the changes to data source
        /// </summary>
        /// <param name="cancellationToken">cancellation Token</param>
        /// <returns>affected lines</returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}