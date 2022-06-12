namespace COMPANY.Domain.Entities.OwnedEntities
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// a class that defines the history of properties values changes in a given entity
    /// </summary>
    public class ChangesHistory
    {
        /// <summary>
        /// the date of the changes
        /// </summary>
        public DateTime ChangeDate { get; set; }

        /// <summary>
        /// the id of the user who made the change
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// the type of the action performed, example : Added / Modified / Deleted
        /// </summary>
        public ChangesHistoryType Action { get; set; }

        /// <summary>
        /// list of Fields that has been changed
        /// </summary>
        public ICollection<ChangedFields> Fields { get; set; }
    }

    /// <summary>
    /// a class that defines the fields that has changed
    /// </summary>
    public class ChangedFields
    {
        /// <summary>
        /// the name of the field
        /// </summary>
        public string FieldName { get; set; }

        /// <summary>
        /// the before/old value
        /// </summary>
        public string Before { get; set; }

        /// <summary>
        /// the after/new value
        /// </summary>
        public string After { get; set; }

        /// <summary>
        /// mark if this field is a complex type or not
        /// </summary>
        public bool IsComplexType { get; set; }
    }

    /// <summary>
    /// the type of changes
    /// </summary>
    public enum ChangesHistoryType
    {
        /// <summary>
        /// an add operation
        /// </summary>
        Added = 1,

        /// <summary>
        /// update operation
        /// </summary>
        Updated = 2,

        /// <summary>
        /// delete operation
        /// </summary>
        Deleted = 3
    }
}
