namespace COMPANY.Application.Data
{
    using Domain.Interfaces;
    using Microsoft.EntityFrameworkCore.Query;
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// a Data Request builder to create an instant on the DataRequest object
    /// </summary>
    /// <typeparam name="TEntity">the type of the entity we building the data request for it</typeparam>
    public interface IDataRequestBuilder<TEntity>
        where TEntity : class, IEntity
    {
        /// <summary>
        /// add a Include expression
        /// </summary>
        /// <param name="include">the include expression</param>
        /// <returns>the Data Request builder</returns>
        IDataRequestBuilder<TEntity> AddInclude(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include);

        /// <summary>
        /// add an order by selector
        /// </summary>
        /// <param name="sortDirection">the type of the orderBy</param>
        /// <param name="orderByKeySelector">the order by selector</param>
        /// <returns>the Data Request builder</returns>
        IDataRequestBuilder<TEntity> AddOrderBy(SortDirection sortDirection, Expression<Func<TEntity, object>> orderByKeySelector);

        /// <summary>
        /// add a filter expression
        /// </summary>
        /// <param name="predicate">the predicate for the filter</param>
        /// <returns>the Data Request builder</returns>
        IDataRequestBuilder<TEntity> AddPredicate(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// add the search query
        /// </summary>
        /// <param name="query">the search query</param>
        /// <returns>the Data Request builder</returns>
        IDataRequestBuilder<TEntity> AddQuery(string query);

        /// <summary>
        /// build an instant of the <see cref="IDataRequest{TEntity}"/>
        /// </summary>
        /// <returns>an instant of the <see cref="IDataRequest{TEntity}"/> class</returns>
        IDataRequest<TEntity> Buil();

        /// <summary>
        /// build an instant of the <see cref="IDataRequest{TEntity, TOut}"/>
        /// </summary>
        /// <typeparam name="TOut">the type of the output</typeparam>
        /// <param name="selector">the selector expression</param>
        /// <returns>an instant of the <see cref="IDataRequest{TEntity, TOut}"/> class</returns>
        IDataRequest<TEntity, TOut> Buil<TOut>(Expression<Func<TEntity, TOut>> selector);
    }
}
