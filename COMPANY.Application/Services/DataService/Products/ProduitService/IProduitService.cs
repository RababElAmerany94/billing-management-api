namespace COMPANY.Application.Services.DataService.ProduitService
{
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Models;
    using COMPANY.Application.Models.BusinessEntitiesModels.PrixProduitParAgenceModels;
    using COMPANY.Application.Models.BusinessEntitiesModels.ProduitModels;
    using COMPANY.Domain.Entities;
    using COMPANY.Domain.Entities.OwnedEntities;
    using COMPANY.Presistence.Implementations;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IProduitService
        : IBaseService<Produit, string, ProduitModel, ProduitCreateModel, ProduitUpdateModel>
    {
        #region produit 

        /// <summary>
        /// check if the given reference is unique
        /// </summary>
        /// <param name="reference">the reference to be checked</param>
        /// <returns>true if unique, false if not</returns>
        Task<Result<bool>> CheckUniqueReferenceAsync(string reference);

        /// <summary>
        /// save the given memo to the produit with the given id
        /// </summary>
        /// <param name="id">the id of the produit to save the memo for it</param>
        /// <param name="memos">the memo to be saved</param>
        /// <returns>a result object</returns>
        Task<Result> SaveMemosAsync(string id, ICollection<Memo> memos);

        /// <summary>
        /// change visibility produit
        /// </summary>
        /// <param name="changeVisibilityProduitModel">the change visibility model</param>
        /// <returns>a visibility of produit</returns>
        Task<Result<bool>> ChangeVisibilityProduit(ChangeVisibilityProduitModel changeVisibilityProduitModel);

        /// <summary>
        /// get produits as pagination
        /// </summary>
        /// <param name="filterOption">the filter option</param>
        /// <returns>a result paged</returns>
        Task<PagedResult<ProduitModel>> GeProduitsAsPagedResultAsync(FilterOption filterOption);

        #endregion

        #region prix produit par agence

        /// <summary>
        /// get the prix produit par agence with the  given id
        /// </summary>
        /// <param name="produitId">the id of produits </param>
        /// <param name="agenceId">the id of agence</param>
        /// <returns>the prix produit par agence result</returns>
        Task<Result<PrixProduitParAgenceModel>> GetPrixProduitParAgenceByIdAsync(string produitId, string agenceId);

        /// <summary>
        /// create the prix produit par agence with the given values
        /// </summary>
        /// <param name="prixProduitParAgenceCreateModel">the create model for the prix produit par agence entity</param>
        /// <param name="agenceId">the id of the agence who made the add operation</param>
        /// <returns>the newly created prix produit par agence result</returns>
        Task<Result<PrixProduitParAgenceModel>> CreatePrixProduitParAgenceAsync(PrixProduitParAgenceCreateModel prixProduitParAgenceCreateModel, string agenceId);

        /// <summary>
        /// update the prix produit par agence from the given model
        /// </summary>
        /// <param name="id">the id of the prix produit par agence to be updated</param>
        /// <param name="prixProduitParAgenceUpdateModel">the update model</param>
        /// <returns>the update version of the prix produit par agence</returns>
        Task<Result<PrixProduitParAgenceModel>> UpdatePrixProduitParAgenceAsync(string id, PrixProduitParAgenceUpdateModel prixProduitParAgenceUpdateModel);

        /// <summary>
        /// delete the prix produit par agence with the given id
        /// </summary>
        /// <param name="id">the id of the prix produit par agence to be deleted</param>
        /// <returns>a result instant</returns>
        Task<Result> DeletePrixProduitParAgenceAsync(string id);

        #endregion
    }
}
