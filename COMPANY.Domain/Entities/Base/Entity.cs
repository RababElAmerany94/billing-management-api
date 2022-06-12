namespace COMPANY.Domain.Entities
{
    using Interfaces;
    using System;

    /// <summary>
    /// Entity class that implement <see cref="IEntity"/>, which is the base entity class
    /// </summary>
    public abstract class Entity : IEntity
    {
        /// <summary>
        /// the creation time of the model
        /// </summary>
        public DateTimeOffset CreatedOn { get; set; }

        /// <summary>
        /// the last time the model has been modified
        /// </summary>
        public DateTimeOffset? LastModifiedOn { get; set; }

        /// <summary>
        /// represent a set of search terms
        /// </summary>
        public string SearchTerms { get; protected set; }

        /// <summary>
        /// build the set of search terms for the object
        /// </summary>
        public abstract void BuildSearchTerms();
    }

    /// <summary>
    /// Entity class that implement <see cref="IEntity"/> and inherit from the <see cref="Entity"/> base class
    /// </summary>
    /// <typeparam name="Tkey">type of key</typeparam>
    public abstract class Entity<Tkey> : Entity, IEntity<Tkey>
    {
        /// <summary>
        /// the id of the entity
        /// </summary>
        public Tkey Id { get; set; }
    }
}
