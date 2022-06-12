namespace COMPANY.Application.DataInteraction.Generals
{
    using COMPANY.Application.Data;
    using COMPANY.Application.DataInteraction.DataAccess;
    using COMPANY.Application.DataInteraction.DataAccess.Accounting;
    using COMPANY.Application.DataInteraction.DataAccess.Base;
    using COMPANY.Application.DataInteraction.DataAccess.General;
    using COMPANY.Domain.Interfaces;
    using System.Threading.Tasks;

    /// <summary>
    /// Contains all the UnitOfWork methods.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Returns the repository for the provided type.
        /// </summary>
        /// <typeparam name="TEntity">The database entity type.</typeparam>
        /// <returns>Returns <see cref="DataAccess{TEntity}"/>.</returns>
        IDataAccess<TEntity> DataAccess<TEntity>()
            where TEntity : class, IEntity;

        /// <summary>
        /// Returns the repository for the provided type.
        /// </summary>
        /// <typeparam name="TEntity">The database entity type.</typeparam>
        /// <typeparam name="TKey">The key entity type.</typeparam>
        /// <returns>Returns <see cref="DataAccess{TEntity}"/>.</returns>
        IDataAccess<TEntity, TKey> DataAccess<TEntity, TKey>()
            where TEntity : class, IEntity<TKey>;

        /// <summary>
        /// return account data access
        /// </summary>
        IAccountDataAccess AccountDataAccess { get; }

        /// <summary>
        /// return role data access
        /// </summary>
        IRoleDataAccess RoleDataAccess { get; }

        /// <summary>
        /// return document parameters data access
        /// </summary>
        IDocumentParametersDataAccess DocumentParametersDataAccess { get; }

        /// <summary>
        /// return configuration messagerie data access
        /// </summary>
        IConfigMessagerieDataAccess ConfigMessagerieDataAccess { get; }

        /// <summary>
        /// return produit data access
        /// </summary>
        IProduitDataAccess ProduitDataAccess { get; }

        /// <summary>
        /// return paiement data access
        /// </summary>
        IPaiementDataAccess PaiementDataAccess { get; }

        /// <summary>
        /// return period comptable data access
        /// </summary>
        IPeriodeComptableDataAccess PeriodeComptableDataAccess { get; }

        /// <summary>
        /// return comptabilite data access
        /// </summary>
        IComptabiliteDataAccess ComptabiliteDataAccess { get; }

        /// <summary>
        /// return dashboard data access
        /// </summary>
        IDashboardDataAccess DashboardDataAccess { get; }

        /// <summary>
        /// return numerotation data access
        /// </summary>
        INumerotationDataAccess NumerotationDataAccess { get; }

        /// <summary>
        /// Execute raw sql command against the configured database.
        /// </summary>
        /// <param name="sql">The sql string.</param>
        /// <param name="parameters">The paramters in the sql string.</param>
        /// <returns>Returns <see cref="int"/>.</returns>
        int ExecuteSqlCommand(string sql, params object[] parameters);

        /// <summary>
        /// Execute raw sql command against the configured database asynchronously.
        /// </summary>
        /// <param name="sql">The sql string.</param>
        /// <param name="parameters">The paramters in the sql string.</param>
        /// <returns>Returns <see cref="Task{TResult}"/>.</returns>
        Task<int> ExecuteSqlCommandAsync(string sql, params object[] parameters);

        /// <summary>
        /// Reset the DbContext state by removing all the tracked and attached entities.
        /// </summary>
        void ResetContextState();

        /// <summary>
        /// Trigger the execution of the EF core commands against the configuired database.
        /// </summary>
        /// <returns>Returns <see cref="Task"/>.</returns>
        Task SaveChangesAsync();
    }
}
