namespace COMPANY.Application.DataInteraction.DataAccess
{
    using COMPANY.Application.Data;
    using COMPANY.Application.DataInteraction.DataAccess.Base;
    using COMPANY.Application.Models;
    using COMPANY.Domain.Entities;
    using COMPANY.Presistence.Implementations;
    using System.Threading.Tasks;

    public interface IProduitDataAccess : IDataAccess<Produit, string>
    {

        /// <summary>
        /// Get list produits as paged result
        /// </summary>
        /// <param name="filterOption">the filter option model</param>
        /// <param name="request">the request filter</param>
        /// <param name="agenceId">the agence id</param>
        /// <returns>a paged result</returns>
        Task<PagedResult<Produit>> GetProduitsAsPagedResultAsync(FilterOption filterOption, IDataRequest<Produit> request, string agenceId);
    }
}
