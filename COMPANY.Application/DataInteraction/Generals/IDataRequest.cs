namespace COMPANY.Application.Data
{
    using COMPANY.Domain.Interfaces;
    using Microsoft.EntityFrameworkCore.Query;
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// an interface that describe a DataRequest object
    /// </summary>
    /// <typeparam name="TEntity">the type of the entity</typeparam>
    public interface IDataRequest<TEntity>
       where TEntity : class, IEntity
    {
        /// <summary>
        /// Gets or sets the navigation entities to be eager loadded with EF Core query.
        /// </summary>
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> Includes { get; set; }

        /// <summary>
        /// the order Descendant by Selector
        /// </summary>
        Expression<Func<TEntity, object>> OrderByDescKeySelector { get; set; }

        /// <summary>
        /// the order by Selector 
        /// </summary>
        Expression<Func<TEntity, object>> OrderByKeySelector { get; set; }

        /// <summary>
        /// the predicate
        /// </summary>
        Expression<Func<TEntity, bool>> Predicate { get; set; }

        /// <summary>
        /// the search query to perform a search
        /// </summary>
        string Query { get; set; }
    }

    /// <summary>
    /// an interface that describe a DataRequest object
    /// </summary>
    /// <typeparam name="TEntity">the type of the entity</typeparam>
    /// <typeparam name="TOut">the type of the out result</typeparam>
    public interface IDataRequest<TEntity, TOut> : IDataRequest<TEntity>
       where TEntity : class, IEntity
    {
        /// <summary>
        /// the selector for the select statement
        /// </summary>
        Expression<Func<TEntity, TOut>> Selector { get; set; }
    }
}
