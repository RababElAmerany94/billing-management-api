namespace COMPANY.Presistence.DataAccess.Base
{
    using Application.Data;
    using COMPANY.Application.DataInteraction.DataAccess.Base;
    using COMPANY.Application.Exceptions;
    using COMPANY.Application.Models;
    using COMPANY.Presistence;
    using COMPANY.Presistence.Implementations;
    using Domain.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using Presistence.DataContext;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    /// <summary>
    /// an abstract implementation of the IDataSource interface
    /// </summary>
    /// <typeparam name="TEntity">the entity type</typeparam>
    public class DataAccess<TEntity> : IDataAccess<TEntity>
        where TEntity : class, IEntity
    {
        /// <summary>
        /// the context
        /// </summary>
        protected readonly IDataSource _context;

        /// <summary>
        /// the entity Db set
        /// </summary>
        protected readonly DbSet<TEntity> _entity;

        /// <summary>
        /// the logger instance
        /// </summary>
        protected readonly ILogger _logger;

        /// <summary>
        /// the name of entity type
        /// </summary>
        protected readonly string _nameEntity = nameof(TEntity);

        /// <summary>
        /// default constructor that tacks the context
        /// </summary>
        /// <param name="context">the DataSource</param>
        protected DataAccess(
            IDataSource context,
            ILoggerFactory loggerFactory)
        {
            _context = context;
            _entity = _context.Set<TEntity>();
            _logger = loggerFactory.CreateLogger($"DataAccess.{_nameEntity}");
        }

        #region Data manipulation operations

        /// <summary>
        /// add the given entity to the database
        /// </summary>
        /// <param name="entity">the entity to be added</param>
        public async Task AddAsync(TEntity entity)
            => await _entity.AddAsync(entity);

        /// <summary>
        /// add the list of entities to the underlying database
        /// </summary>
        /// <param name="entities">the Entity to be add</param>
        /// <returns>the result of the operation</returns>
        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
            => await _entity.AddRangeAsync(entities);

        /// <summary>
        /// remove the list of entities 
        /// </summary>
        /// <param name="entities">the Entity to be remove</param>
        public void DeleteRange(IEnumerable<TEntity> entities)
            => _entity.RemoveRange(entities);

        /// <summary>
        /// update the entity
        /// </summary>
        /// <param name="entity">the new entity</param>
        public void Update(TEntity entity)
            => _entity.Update(entity);

        /// <summary>
        /// update the list of entities 
        /// </summary>
        /// <param name="entities">the Entity to be update</param>
        public void UpdateRange(IEnumerable<TEntity> entities)
            => _entity.UpdateRange(entities);

        /// <summary>
        /// delete the given entities
        /// </summary>
        /// <param name="entities">entities to be deleted</param>
        public void Delete(params TEntity[] entities)
           => _entity.RemoveRange(entities);

        /// <summary>
        /// Delete the given range 
        /// </summary>
        /// <param name="index">starting index</param>
        /// <param name="length">the length</param>
        /// <param name="request">the request</param>
        public void Delete(int index, int length, IDataRequest<TEntity> request = null)
        {
            var entities = Get(request).Skip(index).Take(length);
            _entity.RemoveRange(entities);
        }

        #endregion

        #region Get Data Operations

        /// <summary>
        /// get the a single result using the given predicate
        /// </summary>
        /// <param name="predicate">the predicate to use to get the result</param>
        /// <returns>a result of a given entity</returns>
        public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                var result = await Get(predicate).SingleOrDefaultAsync();

                if (result is null)
                {
                    _logger.LogError("there is no entity {entity} that matches the given predicate", _nameEntity);
                    return null;
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Retrieving the entity {entity}, an exception has been thrown", _nameEntity);
                return null;
            }
        }

        /// <summary>
        /// get the list of all related entities
        /// </summary>
        /// <param name="request">the data request</param>
        /// <returns>list of <see cref="TEntity"/></returns>
        public async Task<IEnumerable<TEntity>> GetAsync(IDataRequest<TEntity> request = null)
        {
            try
            {
                var result = await Get(request).ToIEnumerableAsync();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Retrieving the GetAsync {entity}, an exception has been thrown", _nameEntity);
                return default;
            }
        }

        /// <summary>
        /// get the list of Entities that matches the given predicate
        /// </summary>
        /// <param name="request">the request</param>
        /// <returns>list of matched result</returns>
        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                var result = await _entity.Where(predicate).ToIEnumerableAsync();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Retrieving the GetAsync {entity}, an exception has been thrown", _nameEntity);
                return default;
            }
        }

        /// <summary>
        /// get a single result using the given data request
        /// </summary>
        /// <param name="request">Data Request instant</param>
        /// <returns>a single result</returns>
        public async Task<TEntity> GetSingleAsync(IDataRequest<TEntity> request)
        {
            try
            {
                var result = await Get(request).FirstOrDefaultAsync();

                if (result is null)
                {
                    _logger.LogError("Failed retrieving the result, there is no {entity} that match the given request", _nameEntity);
                    return null;
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Retrieving the GetSingleAsync {entity}, an exception has been thrown", _nameEntity);
                return default;
            }
        }

        /// <summary>
        /// get the count of items in dataSource
        /// </summary>
        public async Task<int> GetCountAsync(IDataRequest<TEntity> request = null)
        {
            try
            {
                return await Get(request).CountAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed retrieving the Count of {entity}, an exception has been thrown", _nameEntity);
                return default;
            }
        }

        /// <summary>
        /// get the count of items in dataSource
        /// </summary>
        public async Task<int> GetCountAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            try
            {
                return await Get(predicate).CountAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed retrieving the Count of {entity}, an exception has been thrown", _nameEntity);
                return default;
            }
        }

        /// <summary>
        /// get the sum of items in dataSource
        /// </summary>
        public async Task<decimal> GetSumAsync(Expression<Func<TEntity, decimal>> sumExpression, IDataRequest<TEntity> request = null)
        {
            try
            {
                return await Get(request).SumAsync(sumExpression);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed retrieving the Sum of {entity}, an exception has been thrown", _nameEntity);
                return default;
            }
        }

        /// <summary>
        /// get the sum of items in dataSource
        /// </summary>
        public async Task<decimal> GetSumAsync(Expression<Func<TEntity, decimal>> sumExpression, Expression<Func<TEntity, bool>> predicate = null)
        {
            try
            {
                return await Get(predicate).SumAsync(sumExpression);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed retrieving the Sum of {entity}, an exception has been thrown", _nameEntity);
                return default;
            }
        }

        /// <summary>
        /// get the entities as Paged Result
        /// </summary>
        /// <param name="request"> the data request</param>
        /// <param name="page">the page index</param>
        /// <param name="pageSize">the page size</param>
        /// <returns></returns>
        public async Task<PagedResult<TEntity>> GetPagedResultAsync(int page, int pageSize, IDataRequest<TEntity> request = null)
            => await Get(request).AsPagedResultAsync(page, pageSize);

        /// <summary>
        /// get the Paged Result using the filter options
        /// </summary>
        /// <param name="filterOption">the filter option</param>
        /// <returns>a paged result</returns>
        public async Task<PagedResult<TEntity>> GetPagedResultAsync(FilterOption filterOption, IDataRequest<TEntity> request = null)
        {
            var query = Get(request);

            if (!string.IsNullOrEmpty(filterOption.SearchQuery))
                query = query.Where(e => e.SearchTerms.ToLower().Contains(filterOption.SearchQuery.ToLower().Trim()));

            return await query.OrderByDynamic(filterOption.OrderBy, filterOption.SortDirection)
                .AsPagedResultAsync(filterOption.Page, filterOption.PageSize);
        }

        #endregion

        #region Check existence

        /// <summary>
        /// check if the entity with the given Data Request is exist
        /// </summary>
        /// <param name="request">the Data Request</param>
        /// <returns>true if exist, false if not</returns>
        public async Task<bool> IsExistAsync(IDataRequest<TEntity> request)
        {
            try
            {
                var result = await Get(request).AnyAsync();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed checking existence of {entity}, an exception has been thrown", _nameEntity);
                return default;
            }
        }

        /// <summary>
        /// check if there is any entity that matches the given predicate
        /// </summary>
        /// <param name="predicate">the predicate to be evaluated</param>
        /// <returns>true if exist, false if not</returns>
        public async Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                var result = await Get(predicate).AnyAsync();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed checking existence of {entity}, an exception has been thrown", _nameEntity);
                return default;
            }
        }

        #endregion

        #region Protected query Methods

        /// <summary>
        /// get the IQueryable of entities to query the entities from the database using the 
        /// passed in IDataRequest
        /// </summary>
        /// <param name="request">the IDataRequest object</param>
        /// <returns>IQueryable of entities</returns>
        protected IQueryable<TEntity> Get(IDataRequest<TEntity> request = null)
            => _entity.AsNoTracking().GetWithDataRequest(request);

        /// <summary>
        /// get the IQueryable of entities to query the entities from the database
        /// </summary>
        /// <param name="predicate">the predicate of the where query</param>
        /// <returns>IQueryable of entities</returns>
        protected IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
            => Get().Where(predicate);

        /// <summary>
        /// you can only execute 'INSERT', 'UPDATE' and 'DELETE' Command
        /// </summary>
        /// <param name="sql">the SQL to be executed</param>
        /// <param name="parameters">the parameters in the query</param>
        protected IQueryable<TEntity> ExecSQL(string sql, params object[] parameters)
            => _entity.FromSql(sql, parameters);

        #endregion
    }

    /// <summary>
    /// an abstract implementation of the IDataSource interface
    /// </summary>
    /// <typeparam name="TEntity">the entity type</typeparam>
    /// <typeparam name="TKey">the entity key type</typeparam>
    public class DataAccess<TEntity, TKey> : DataAccess<TEntity>, IDataAccess<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        protected DataAccess(IDataSource context, ILoggerFactory loggerFactory)
            : base(context, loggerFactory)
        { }

        /// <summary>
        /// delete the entity with the given id
        /// </summary>
        /// <param name="id">the id of the entity to be deleted</param>
        /// <returns>an operation result</returns>
        public async Task<TEntity> DeleteAsync(TKey id)
        {
            var entity = await GetAsync(id);

            if (entity is null)
                throw new NotFoundException($"there is no {_nameEntity} with the id : {id}");

            _entity.RemoveRange(entity);
            return entity;
        }

        /// <summary>
        /// check if the entity with the given id is exist
        /// </summary>
        /// <param name="entityId">the entity id</param>
        /// <returns>true if exist, false if not</returns>
        public async Task<bool> IsExistAsync(TKey entityId, IDataRequest<TEntity> request = null)
            => await Get(request).AnyAsync(e => e.Id.Equals(entityId));

        /// <summary>
        /// get the entity with the specified id
        /// </summary>
        /// <param name="entityId">the entity id</param>
        /// <param name="request">the dataRequest</param>
        /// <returns>the founded entity</returns>
        public async Task<TEntity> GetAsync(TKey entityId, IDataRequest<TEntity> request = null)
        {
            try
            {
                var result = await Get(request).SingleOrDefaultAsync(e => e.Id.Equals(entityId));

                if (result is null)
                {
                    _logger.LogError("Couldn't retrieve the result, there is no entity with the given id : {entityId}", entityId);
                    return null;
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Retrieving the GetSingleAsync {entity}, an exception has been thrown", _nameEntity);
                return default;
            }
        }

        /// <summary>
        /// Get the Keys of the entities
        /// </summary>
        /// <returns>IQueryable of entities</returns>
        public async Task<IEnumerable<TKey>> GetKeysAsync(IDataRequest<TEntity> request = null)
        {
            try
            {
                var result = await Get(request).Select(e => e.Id).ToIEnumerableAsync();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Retrieving results GetKeysAsync of {entity}, an exception has been thrown", _nameEntity);
                return default;
            }
        }
    }
}
