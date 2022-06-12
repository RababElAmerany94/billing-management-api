namespace COMPANY.Presistence.DataAccess
{
    using Application.Data;
    using COMPANY.Presistence.DataAccess.Base;
    using Domain.Entities;
    using Microsoft.Extensions.Logging;
    using Presistence.DataContext;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// a class that implement <see cref="IRoleDataAccess"/>
    /// to describe the data access layer for the <see cref="Role"/> entity
    /// </summary>
    public class RoleDataAccess : DataAccess<Role, int>, IRoleDataAccess
    {
        public RoleDataAccess(IDataSource context, ILoggerFactory loggerFactory)
            : base(context, loggerFactory)
        { }

        /// <summary>
        /// retrieve the roles they have the an id in the given list
        /// </summary>
        /// <param name="keys">list of keys to compare to it</param>
        /// <returns>list of result</returns>
        public async Task<IEnumerable<Role>> GetRolesInAsync(int[] keys)
            => await Get().Where(r => keys.Contains(r.Id)).ToIEnumerableAsync();
    }
}
