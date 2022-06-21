namespace COMPANY.Presistence.DataInteraction.Generals
{
    using COMPANY.Application.Data;
    using COMPANY.Application.DataInteraction.DataAccess;
    using COMPANY.Application.DataInteraction.DataAccess.Accounting;
    using COMPANY.Application.DataInteraction.DataAccess.Base;
    using COMPANY.Application.DataInteraction.DataAccess.General;
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Domain.Interfaces;
    using COMPANY.Presistence.DataAccess;
    using COMPANY.Presistence.DataAccess.Accounting;
    using COMPANY.Presistence.DataAccess.Base;
    using COMPANY.Presistence.DataAccess.Documents;
    using COMPANY.Presistence.DataAccess.General;
    using COMPANY.Presistence.DataContext;
    using Inova.AutoInjection.Attributes;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections;
    using System.Linq;
    using System.Threading.Tasks;

    [Inject(typeof(IUnitOfWork), ServiceLifetime.Scoped)]
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly CompanyDbContext _dbContext;

        private Hashtable _repositories;
        private Hashtable _repositoriesWithKey;
        private IAccountDataAccess _accountDataAccess;
        private IDocumentParametersDataAccess _documentParametersDataAccess;
        private IConfigMessagerieDataAccess _configMessagerieDataAccess;
        private IProduitDataAccess _produitDataAccess;
        private IPaiementDataAccess _paiementDataAccess;
        private IPeriodeComptableDataAccess _periodeComptableDataAccess;
        private IComptabiliteDataAccess _comptabiliteDataAccess;
        private IDashboardDataAccess _dashboardDataAccess;
        private IRoleDataAccess _roleDataAccess;
        private INumerotationDataAccess _numerotationDataAccess;

        private readonly ILoggerFactory _loggerFactory;

        public UnitOfWork(CompanyDbContext dbContext, ILoggerFactory loggerFactory)
        {
            _dbContext = dbContext;
            _loggerFactory = loggerFactory;
        }

        public IDataAccess<TEntity> DataAccess<TEntity>()
            where TEntity : class, IEntity
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }

            string type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                object repositoryInstance = Tools.CreateInstantOf<DataAccess<TEntity>>(
                    new Type[] { typeof(CompanyDbContext), typeof(ILoggerFactory) }, new object[] { _dbContext, _loggerFactory });

                _repositories.Add(type, repositoryInstance);
            }

            return (IDataAccess<TEntity>)_repositories[type];
        }

        public IDataAccess<TEntity, TKey> DataAccess<TEntity, TKey>()
            where TEntity : class, IEntity<TKey>
        {
            if (_repositoriesWithKey == null)
            {
                _repositoriesWithKey = new Hashtable();
            }

            string type = typeof(TEntity).Name;

            if (!_repositoriesWithKey.ContainsKey(type))
            {

                object repositoryInstance = Tools.CreateInstantOf<DataAccess<TEntity, TKey>>(
                    new Type[] { typeof(CompanyDbContext), typeof(ILoggerFactory) }, new object[] { _dbContext, _loggerFactory });

                _repositoriesWithKey.Add(type, repositoryInstance);
            }

            return (IDataAccess<TEntity, TKey>)_repositoriesWithKey[type];
        }
        public IAccountDataAccess AccountDataAccess
        {
            get
            {
                if (_accountDataAccess is null)
                    _accountDataAccess = new AccountDataAccess(_dbContext, _loggerFactory);

                return _accountDataAccess;
            }
        }

        public IDocumentParametersDataAccess DocumentParametersDataAccess
        {
            get
            {
                if (_documentParametersDataAccess is null)
                    _documentParametersDataAccess = new DocumentParametersDataAccess(_dbContext, _loggerFactory);

                return _documentParametersDataAccess;
            }
        }

        public IConfigMessagerieDataAccess ConfigMessagerieDataAccess
        {
            get
            {
                if (_configMessagerieDataAccess is null)
                    _configMessagerieDataAccess = new ConfigMessagerieDataAccess(_dbContext, _loggerFactory);

                return _configMessagerieDataAccess;
            }
        }

        public IProduitDataAccess ProduitDataAccess
        {
            get
            {
                if (_produitDataAccess is null)
                    _produitDataAccess = new ProduitDataAccess(_dbContext, _loggerFactory);

                return _produitDataAccess;
            }
        }

        public IPaiementDataAccess PaiementDataAccess
        {
            get
            {
                if (_paiementDataAccess is null)
                    _paiementDataAccess = new PaiementDataAccess(_dbContext, _loggerFactory);

                return _paiementDataAccess;
            }
        }

        public IPeriodeComptableDataAccess PeriodeComptableDataAccess
        {
            get
            {
                if (_periodeComptableDataAccess is null)
                    _periodeComptableDataAccess = new PeriodeComptableDataAccess(_dbContext, _loggerFactory);

                return _periodeComptableDataAccess;
            }
        }

        /// <summary>
        /// return comptabilite data access
        /// </summary>
        public IComptabiliteDataAccess ComptabiliteDataAccess
        {
            get
            {
                if (_comptabiliteDataAccess is null)
                    _comptabiliteDataAccess = new ComptabiliteDataAccess(_dbContext);

                return _comptabiliteDataAccess;
            }
        }


        /// <summary>
        /// return dashboard data access
        /// </summary>
        public IDashboardDataAccess DashboardDataAccess
        {
            get
            {
                if (_dashboardDataAccess is null)
                    _dashboardDataAccess = new DashboardDataAccess(_dbContext);

                return _dashboardDataAccess;
            }
        }

        /// <summary>
        /// return role data access
        /// </summary>
        public IRoleDataAccess RoleDataAccess
        {
            get
            {
                if (_roleDataAccess is null)
                    _roleDataAccess = new RoleDataAccess(_dbContext, _loggerFactory);

                return _roleDataAccess;
            }
        }

        /// <summary>
        /// return numerotation data access
        /// </summary>
        public INumerotationDataAccess NumerotationDataAccess
        {
            get
            {
                if (_numerotationDataAccess is null)
                    _numerotationDataAccess = new NumerotationDataAccess(_dbContext, _loggerFactory);

                return _numerotationDataAccess;
            }
        }

        public int ExecuteSqlCommand(string sql, params object[] parameters)
        {
            return _dbContext.Database.ExecuteSqlCommand(sql, parameters);
        }

        public async Task<int> ExecuteSqlCommandAsync(string sql, params object[] parameters)
        {
            return await _dbContext.Database.ExecuteSqlCommandAsync(sql, parameters);
        }

        public void ResetContextState()
        {
            _dbContext.ChangeTracker.Entries().Where(e => e.Entity != null).ToList()
                .ForEach(e => e.State = EntityState.Detached);
        }

        public async Task SaveChangesAsync()
            => await _dbContext.SaveChangesAsync();
    }
}
