namespace COMPANY.Application.DataInteraction.DataAccess.Base
{
    using Application.Models;
    using COMPANY.Application.Data;
    using COMPANY.Presistence.Implementations;
    using Domain.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    /// <summary>
    /// represent the DataAcsess implementation
    /// </summary>
    /// <typeparam name="TEntity">the type of the entity</typeparam>
    public interface IDataAccess<TEntity>
        where TEntity : class, IEntity
    {
        /// <summary>
        /// add the Entity to the underlying database
        /// </summary>
        /// <param name="entity">the Entity to be add</param>
        Task AddAsync(TEntity entity);

        /// <summary>
        /// add the list of entities to the underlying database
        /// </summary>
        /// <param name="entities">the Entity to be add</param>
        /// <returns>the result of the operation</returns>
        Task AddRangeAsync(IEnumerable<TEntity> entities);

        /// <summary>
        /// remove the list of entities 
        /// </summary>
        /// <param name="entities">the Entity to be remove</param>
        /// <returns>the result of the operation</returns>
        void DeleteRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// update the given model
        /// </summary>
        /// <param name="model">model to be updated</param>
        /// <returns>the updated model</returns>
        void Update(TEntity model);

        /// <summary>
        /// update the list of entities 
        /// </summary>
        /// <param name="entities">the Entity to be update</param>
        /// <returns>the result of the operation</returns>
        void UpdateRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// delete the given Entities
        /// </summary>
        /// <param name="Entities">the Entities to be deleted</param>
        /// <returns>a boolean true if deleted</returns>
        void Delete(params TEntity[] Entities);

        /// <summary>
        /// delete the Entities for the given range
        /// </summary>
        /// <param name="index">the starting index</param>
        /// <param name="length">the length</param>
        /// <param name="request">the request</param>
        /// <returns>a boolean true if deleted</returns>
        void Delete(int index, int length, IDataRequest<TEntity> request = null);

        /// <summary>
        /// check if there is a matching result for the request
        /// </summary>
        /// <param name="request">the request</param>
        /// <returns>true if exist</returns>
        Task<bool> IsExistAsync(IDataRequest<TEntity> request);

        /// <summary>
        /// check if there is any entity that matches the given predicate
        /// </summary>
        /// <param name="predicate">the predicate to be evaluated</param>
        /// <returns>true if exist, false if not</returns>
        Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// get the count of Entities that match the request
        /// </summary>
        /// <param name="request">the data request</param>
        /// <returns>return the count of Entities</returns>
        Task<int> GetCountAsync(IDataRequest<TEntity> request = null);

        /// <summary>
        /// get the count of Entities that match the predicate
        /// </summary>
        /// <param name="predicate">the predicate</param>
        /// <returns>return the count of entities</returns>
        Task<int> GetCountAsync(Expression<Func<TEntity, bool>> predicate = null);

        /// <summary>
        /// get the sum of items in dataSource
        /// </summary>
        Task<decimal> GetSumAsync(Expression<Func<TEntity, decimal>> sumExpression, IDataRequest<TEntity> request = null);

        /// <summary>
        /// get the sum of items in dataSource
        /// </summary>
        Task<decimal> GetSumAsync(Expression<Func<TEntity, decimal>> sumExpression, Expression<Func<TEntity, bool>> predicate = null);

        /// <summary>
        /// get the entities as Paged Result
        /// </summary>
        /// <param name="request">the request</param>
        /// <returns>list of matched result</returns>
        Task<PagedResult<TEntity>> GetPagedResultAsync(int page, int pageSize, IDataRequest<TEntity> request = null);

        /// <summary>
        /// get the Paged Result using the filter options
        /// </summary>
        /// <param name="filterOption">the filter option</param>
        /// <returns>a paged result</returns>
        Task<PagedResult<TEntity>> GetPagedResultAsync(FilterOption filterOption, IDataRequest<TEntity> request = null);

        /// <summary>
        /// get a single result using the given data request
        /// </summary>
        /// <param name="request">Data Request instant</param>
        /// <returns>a single result</returns>
        Task<TEntity> GetSingleAsync(IDataRequest<TEntity> request);

        /// <summary>
        /// get the list of Entities that matches the given request
        /// </summary>
        /// <param name="request">the request</param>
        /// <returns>list of matched result</returns>
        Task<IEnumerable<TEntity>> GetAsync(IDataRequest<TEntity> request = null);

        /// <summary>
        /// get the list of Entities that matches the given predicate
        /// </summary>
        /// <param name="predicate">the predicate</param>
        /// <returns>list of matched result</returns>
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// get the a single result using the given predicate
        /// </summary>
        /// <param name="predicate">the predicate to use to get the result</param>
        /// <returns>a result of a given entity</returns>
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> predicate);
    }

    /// <summary>
    /// represent the DataAcsess implementation
    /// </summary>
    /// <typeparam name="TEntity">the type of the entity</typeparam>
    /// <typeparam name="TKey">the type of the entity Id</typeparam>
    public interface IDataAccess<TEntity, TKey> : IDataAccess<TEntity>
        where TEntity : class, IEntity<TKey>
    {
        /// <summary>
        /// delete the entity with the given id
        /// </summary>
        /// <param name="id">the id of the entity to be deleted</param>
        /// <returns>an operation result</returns>
        Task<TEntity> DeleteAsync(TKey id);

        /// <summary>
        /// check if the entity with the given id is exist
        /// </summary>
        /// <param name="id">the id of the entity</param>
        /// <returns>true if exist</returns>
        Task<bool> IsExistAsync(TKey id, IDataRequest<TEntity> request = null);

        /// <summary>
        /// get the model with the given id
        /// </summary>
        /// <param name="modelId">the id of the model to get</param>
        /// <returns>the model</returns>
        Task<TEntity> GetAsync(TKey modelId, IDataRequest<TEntity> request = null);

        /// <summary>
        /// get the keys of Entities that matches the request
        /// </summary>
        /// <returns>list of keys</returns>
        Task<IEnumerable<TKey>> GetKeysAsync(IDataRequest<TEntity> request = null);
    }
}
