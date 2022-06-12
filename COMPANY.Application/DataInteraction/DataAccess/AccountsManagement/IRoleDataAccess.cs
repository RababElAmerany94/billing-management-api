namespace COMPANY.Application.Data
{
    using COMPANY.Application.DataInteraction.DataAccess.Base;
    using Domain.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// an interface that defines the data access layer for the <see cref="Role"/> entity
    /// </summary>
    public interface IRoleDataAccess : IDataAccess<Role, int>
    {
        /// <summary>
        /// retrieve the roles they have the an id in the given list
        /// </summary>
        /// <param name="keys">list of keys to compare to it</param>
        /// <returns>list of result</returns>
        Task<IEnumerable<Role>> GetRolesInAsync(int[] keys);
    }
}
