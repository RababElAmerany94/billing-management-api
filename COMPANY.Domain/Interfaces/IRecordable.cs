namespace COMPANY.Domain.Interfaces
{
    using COMPANY.Domain.Entities.OwnedEntities;
    using System.Collections.Generic;

    /// <summary>
    /// mark an entity as Recordable, this means that you can track the changes history of the entity
    /// </summary>
    public interface IRecordable
    {
        /// <summary>
        /// the entity modification history
        /// </summary>
        ICollection<ChangesHistory> Historique { get; set; }
    }
}
