namespace COMPANY.Presistence.DataAccess
{
    using Application.Data;
    using COMPANY.Application.Exceptions;
    using COMPANY.Application.Models.BusinessEntitiesModels.AccountModels;
    using COMPANY.Application.Models.General.FilterOptions;
    using COMPANY.Presistence.DataAccess.Base;
    using COMPANY.Presistence.Implementations;
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using Presistence.DataContext;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// a class that implement <see cref="IAccountDataAccess"/>
    /// to describe the data access layer for the <see cref="User"/> entity
    /// </summary>
    public class AccountDataAccess : DataAccess<User, string>, IAccountDataAccess
    {
        public AccountDataAccess(IDataSource context, ILoggerFactory loggerFactory) : base(context, loggerFactory) { }

        /// <summary>
        /// get a single user that match the given request
        /// </summary>
        /// <remarks>the Role are already included, so you don't have to add includes for it in your data request</remarks>
        /// <param name="dataRequest"></param>
        /// <returns>the user</returns>
        public async Task<User> GetUserAsync(IDataRequest<User> dataRequest)
        {
            var result = await Get(dataRequest)
                    .Include(u => u.Role)
                    .SingleOrDefaultAsync();

            if (result is null)
                throw new NotFoundException("Failed retrieving the user, there is no user that match the given request");

            return result;
        }

        /// <summary>
        /// get the user with the given id
        /// </summary>
        /// <param name="id">the id of the user to be retrieved</param>
        /// <returns>the user</returns>
        public async Task<User> GetUserByIdAsync(string id)
        {
            var result = await Get(u => u.Id == id)
                    .Include(u => u.Role)
                    .SingleOrDefaultAsync();

            if (result is null)
                throw new NotFoundException($"Failed retrieving the user, there is no user with the given id : {id}");

            return result;
        }

        /// <summary>
        /// check if the given userName exist
        /// </summary>
        /// <param name="userName">the userName to check</param>
        /// <returns>true if exist, false if not</returns>
        public async Task<bool> IsUserNameExistAsnc(string userName)
        {
            var result = await Get(u => u.UserName.ToLower().Equals(userName.ToLower())).AnyAsync();
            return result;
        }

        /// <summary>
        /// get the user with the given userName
        /// </summary>
        /// <param name="userName">the userName that the user should own</param>
        /// <returns>the user</returns>
        public async Task<User> GetUserByUserNameAsync(string userName)
        {
            var result = await Get(u => u.UserName.Equals(userName))
                        .Include(u => u.Role).ThenInclude(e => e.Permissions).ThenInclude(e => e.Modules)
                        .Include(u => u.Role).ThenInclude(e => e.Modules)
                        .Include(u => u.Agence)
                        .SingleOrDefaultAsync();

            if (result is null)
                throw new NotFoundException($"Failed retrieving the user, there is no user with the given userName : {userName}");

            return result;
        }

        /// <summary>
        /// Get list commercials planning as paged result
        /// </summary>
        /// <param name="filterOption">the filter option model</param>
        /// <param name="request">the request filter</param>
        /// <returns></returns>
        public async Task<PagedResult<CommercialPlanningModel>> GetTechniciensPlanningAsPagedResultAsync(CommercialsPlanningFilterOption filterOption, IDataRequest<User> request)
        {
            try
            {
                var usersDataSet = Get(request);
                var dossierDataSet = _context.Dossiers
                    .Where(e => e.DateRDV.HasValue && e.DateRDV.Value.Date == filterOption.DateRDV.Date)
                    .Include(e => e.Client);

                var result = await usersDataSet.GroupJoin(dossierDataSet, user => user.Id, dossier => dossier.CommercialId,
                    (user, demandes) => new CommercialPlanningModel
                    {
                        Id = user.Id,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Dossiers = demandes.Select(e => new DossierCommercialPlanningModel()
                        {
                            Id = e.Id,
                            ClientFirstName = e.Client.FirstName,
                            ClientLastName = e.Client.LastName,
                            ClientId = e.Client.Id,
                            SiteIntervention = e.SiteIntervention,
                            Contact = e.Contact,
                            DateRDV = e.DateRDV.Value
                        })
                    })
                    .OrderByDynamic(filterOption.OrderBy, filterOption.SortDirection)
                    .AsPagedResultAsync(filterOption.Page, filterOption.PageSize);

                return result;
            }
            catch (Exception ex)
            {
                return PagedResult<CommercialPlanningModel>.Failed(ex, "failed retrieving the result");
            }
        }
    }
}
