namespace COMPANY.Presistence.Implementations
{
    using COMPANY.Application.Data;
    using Domain.Interfaces;
    using Microsoft.EntityFrameworkCore.Query;
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// the data request class for querying data, to create an instant of this class 
    /// use the <see cref="IDataRequestBuilder{TEntity}"/> builder to build an instant
    /// </summary>
    /// <typeparam name="TEntity">the entity type</typeparam>
    public class DataRequest<TEntity> : IDataRequest<TEntity>
        where TEntity : class, IEntity
    {
        /// <summary>
        /// the query for the search term
        /// </summary>
        public string Query { get; set; }

        /// <summary>
        /// Gets or sets the navigation entities to be eager loadded with EF Core query.
        /// </summary>
        public Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> Includes { get; set; }

        /// <summary>
        /// the predicate of the where query
        /// </summary>
        public Expression<Func<TEntity, bool>> Predicate { get; set; }

        /// <summary>
        /// the order by Key Selector
        /// </summary>
        public Expression<Func<TEntity, object>> OrderByKeySelector { get; set; }

        /// <summary>
        /// the OrderByDesc KeySelector
        /// </summary>
        public Expression<Func<TEntity, object>> OrderByDescKeySelector { get; set; }
    }

    /// <summary>
    /// the data request class for querying data, to create an instant of this class 
    /// use the <see cref="IDataRequestBuilder{TEntity}"/> builder to build an instant
    /// </summary>
    /// <typeparam name="TEntity">the entity type</typeparam>
    /// <typeparam name="TOut">the type of the out entity</typeparam>
    public class DataRequest<TEntity, TOut> : DataRequest<TEntity>,
        IDataRequest<TEntity, TOut>
        where TEntity : class, IEntity
    {
        private DataRequest() { }

        /// <summary>
        /// selector for the select method
        /// </summary>
        public Expression<Func<TEntity, TOut>> Selector { get; set; }
    }
}
