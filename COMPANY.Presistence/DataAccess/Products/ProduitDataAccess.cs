namespace COMPANY.Presistence.DataAccess
{
    using COMPANY.Application.Data;
    using COMPANY.Application.DataInteraction.DataAccess;
    using COMPANY.Application.Models;
    using COMPANY.Domain.Entities;
    using COMPANY.Presistence.DataAccess.Base;
    using COMPANY.Presistence.DataContext;
    using COMPANY.Presistence.Implementations;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class ProduitDataAccess : DataAccess<Produit, string>, IProduitDataAccess
    {
        public ProduitDataAccess(IDataSource context, ILoggerFactory loggerFactory)
            : base(context, loggerFactory)
        { }

        /// <summary>
        /// Get list produits as paged result
        /// </summary>
        /// <param name="filterOption">the filter option model</param>
        /// <param name="request">the request filter</param>
        /// <param name="agenceId">the agence id</param>
        /// <returns>a paged result</returns>
        public async Task<PagedResult<Produit>> GetProduitsAsPagedResultAsync(FilterOption filterOption, IDataRequest<Produit> request, string agenceId)
        {
            try
            {
                request.Query = filterOption.SearchQuery;
                var result = await Get(request)
                        .Include(e => e.PrixProduitParAgences)
                        .Select(e => new Produit
                        {
                            Id = e.Id,
                            Reference = e.Reference,
                            PrixAchat = e.PrixAchat,
                            PrixHT = e.PrixHT,
                            TVA = e.TVA,
                            Description = e.Description,
                            Designation = e.Designation,
                            PrixParTranche = e.PrixParTranche,
                            Unite = e.Unite,
                            IsPublic = e.IsPublic,
                            Labels = e.Labels,
                            Memos = e.Memos,
                            Historique = e.Historique,
                            CategoryId = e.CategoryId,
                            Category = e.Category,
                            AgenceId = e.AgenceId,
                            Agence = e.Agence,
                            CreatedOn = e.CreatedOn,
                            LastModifiedOn = e.LastModifiedOn,
                            PrixProduitParAgences = e.PrixProduitParAgences.Where(p => agenceId != null ? p.AgenceId == agenceId : false).Select(p => new PrixProduitParAgence()
                            {
                                AgenceId = p.AgenceId,
                                Id = p.Id,
                                ProduitId = p.ProduitId,
                                TVA = p.TVA,
                                PrixHT = p.PrixHT,
                                CreatedOn = p.CreatedOn,
                                Produit = null,
                                LastModifiedOn = p.LastModifiedOn,
                                Agence = p.Agence
                            }).ToList()
                        })
                        .OrderByDynamic(filterOption.OrderBy, filterOption.SortDirection)
                        .AsPagedResultAsync(filterOption.Page, filterOption.PageSize);

                return result;
            }
            catch (Exception ex)
            {
                return PagedResult<Produit>.Failed(ex, "failed retrieving the result");
            }
        }

    }
}
