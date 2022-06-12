namespace COMPANY.Domain.Interfaces
{
    /// <summary>
    /// a class that defines an entity
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// the creation time of the model
        /// </summary>
        System.DateTimeOffset CreatedOn { get; set; }

        /// <summary>
        /// the last time the model has been modified
        /// </summary>
        System.DateTimeOffset? LastModifiedOn { get; set; }

        /// <summary>
        /// represent a set of search terms
        /// </summary>
        string SearchTerms { get; }

        /// <summary>
        /// build the set of search terms for the object
        /// </summary>
        void BuildSearchTerms();
    }

    /// <summary>
    /// a class that defines an entity with a an id
    /// </summary>
    /// <typeparam name="Tkey">the type of the id</typeparam>
    public interface IEntity<Tkey> : IEntity
    {
        /// <summary>
        /// the id of the entity
        /// </summary>
        Tkey Id { get; set; }
    }
}
