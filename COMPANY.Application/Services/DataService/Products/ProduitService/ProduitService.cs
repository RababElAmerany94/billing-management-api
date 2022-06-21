namespace COMPANY.Application.Services.DataService.ProduitService
{
    using AutoMapper;
    using COMPANY.Application.Data;
    using COMPANY.Application.DataInteraction.DataAccess;
    using COMPANY.Application.DataInteraction.DataAccess.Base;
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Exceptions;
    using COMPANY.Application.Interfaces;
    using COMPANY.Application.Models;
    using COMPANY.Application.Models.BusinessEntitiesModels.PrixProduitParAgenceModels;
    using COMPANY.Application.Models.BusinessEntitiesModels.ProduitModels;
    using COMPANY.Common.Constants;
    using COMPANY.Common.Helpers;
    using COMPANY.Domain.Entities;
    using COMPANY.Domain.Entities.OwnedEntities;
    using COMPANY.Presistence.Implementations;
    using Inova.AutoInjection.Attributes;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    [Inject(typeof(IProduitService), ServiceLifetime.Scoped)]
    public class ProduitService :
        BaseService<Produit, string, ProduitModel, ProduitCreateModel, ProduitUpdateModel>, IProduitService
    {
        private readonly IProduitDataAccess _produitDataAccess;
        private readonly IDataRequestBuilder<PrixProduitParAgence> _prixProduitParAgenceRequestBuilder;
        private readonly IDataAccess<PrixProduitParAgence, string> _produitParAgenceDataAccess;

        public ProduitService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IDataRequestBuilder<Produit> requestBuilder,
            ICurrentUserService currentUserService,
            IDataRequestBuilder<PrixProduitParAgence> prixProduitParAgenceRequestBuilder)
            : base(requestBuilder, unitOfWork, mapper, currentUserService)
        {
            _produitDataAccess = unitOfWork.ProduitDataAccess;
            _prixProduitParAgenceRequestBuilder = prixProduitParAgenceRequestBuilder;
            _produitParAgenceDataAccess = unitOfWork.DataAccess<PrixProduitParAgence, string>();
        }

        #region produit 

        /// <summary>
        /// check if the given reference is unique
        /// </summary>
        /// <param name="reference">the reference to be checked</param>
        /// <returns>true if unique, false if not</returns>
        public async Task<Result<bool>> CheckUniqueReferenceAsync(string reference)
        {
            var result = await _dataAccess.IsExistAsync(c => c.Reference == reference && c.AgenceId == _user.AgenceId);
            return Result<bool>.Success(!result);
        }

        /// <summary>
        /// save the given memos to the produit memos list
        /// </summary>
        /// <param name="id">the id of the produit to save the memo for him</param>
        /// <param name="memos">the memo to be saved</param>
        /// <returns>an operation result</returns>
        public async Task<Result> SaveMemosAsync(string id, ICollection<Memo> memos)
        {
            var result = await GetEntityByIdAsync(id);
            result.Memos = memos;
            _dataAccess.Update(result);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success("updated successfully");
        }

        /// <summary>
        /// change visibility produit
        /// </summary>
        /// <param name="changeVisibilityProduitModel">the change visibility model</param>
        /// <returns>a visibility of produit</returns>
        public async Task<Result<bool>> ChangeVisibilityProduit(ChangeVisibilityProduitModel changeVisibilityProduitModel)
        {
            var result = await GetEntityByIdAsync(changeVisibilityProduitModel.Id);
            result.IsPublic = changeVisibilityProduitModel.IsPublic;
            _dataAccess.Update(result);
            await _unitOfWork.SaveChangesAsync();
            return Result<bool>.Success(result.IsPublic);
        }

        /// <summary>
        /// get produits as pagination
        /// </summary>
        /// <param name="filterOption">the filter option</param>
        /// <returns>a result paged</returns>
        public async Task<PagedResult<ProduitModel>> GeProduitsAsPagedResultAsync(FilterOption filterOption)
        {
            var request = BuildAsPagedDataRequest(filterOption);
            var result = await _produitDataAccess.GetProduitsAsPagedResultAsync(filterOption, request, _user.AgenceId);

            if (!result.HasValue)
                return PagedResult<ProduitModel>.Failed(result.Error, $"Failed to retrieve list of {_entityName}");

            var data = _mapper.Map<IEnumerable<ProduitModel>>(result.Value);
            return PagedResult<ProduitModel>.Success(
                data, result.CurrentPage, result.PageCount, result.PageSize, result.RowCount,
                $"list of {_entityName} retrieved successfully");
        }

        #endregion

        #region prix produit par agence

        /// <summary>
        /// get the prix produit par agence with the  given id
        /// </summary>
        /// <param name="produitId">the id of the prix produit par agence to retrieve</param>
        /// <returns>the prix produit par agence result</returns>
        public async Task<Result<PrixProduitParAgenceModel>> GetPrixProduitParAgenceByIdAsync(string produitId, string agenceId)
        {
            var result = await GetPrixProduitParAgenceByProduitIdAndAgenceId(produitId, agenceId);

            if (result is null)
                throw new NotFoundException($"the produit with the given id {produitId} with agence {agenceId} doesn't have a specific price");

            var data = _mapper.Map<PrixProduitParAgenceModel>(result);
            return Result<PrixProduitParAgenceModel>.Success(data);
        }

        /// <summary>
        /// create the prix produit par agence with the given values
        /// </summary>
        /// <param name="prixProduitParAgenceCreateModel">the create model for the prix produit par agence entity</param>
        /// <param name="agenceId">the id of the agence who made the add operation</param>
        /// <returns>the newly created prix produit par agence result</returns>
        public async Task<Result<PrixProduitParAgenceModel>> CreatePrixProduitParAgenceAsync(PrixProduitParAgenceCreateModel prixProduitParAgenceCreateModel, string agenceId)
        {
            // check already exists
            var result = await GetPrixProduitParAgenceByProduitIdAndAgenceId(
                prixProduitParAgenceCreateModel.ProduitId,
                agenceId
            );

            if (result != null)
                return Result<PrixProduitParAgenceModel>.Failed(null, null, "you already prix", MsgCode.PrixProduitParAgenceExist.ToString());

            var prixProduitParAgenceModel = _mapper.Map<PrixProduitParAgence>(prixProduitParAgenceCreateModel);
            prixProduitParAgenceModel.AgenceId = agenceId;

            await _produitParAgenceDataAccess.AddAsync(prixProduitParAgenceModel);
            await _unitOfWork.SaveChangesAsync();

            var data = _mapper.Map<PrixProduitParAgenceModel>(prixProduitParAgenceModel);
            return Result<PrixProduitParAgenceModel>.Success(data);
        }

        /// <summary>
        /// update the prix produit par agence from the given model
        /// </summary>
        /// <param name="userId">the id of the user who is authenticated, to associate the change with him</param>
        /// <param name="id">the id of the prix produit par agence to be updated</param>
        /// <param name="updateModel">the update model</param>
        /// <returns>the update version of the prix produit par agence</returns>
        public async Task<Result<PrixProduitParAgenceModel>> UpdatePrixProduitParAgenceAsync(string id, PrixProduitParAgenceUpdateModel updateModel)
        {
            var result = await _produitParAgenceDataAccess.GetAsync(id);

            if (result is null)
                throw new NotFoundException($"the given id {id} prix produit par agence does not exists");

            updateModel.UpdatePrixProduitParAgence(result);

            _produitParAgenceDataAccess.Update(result);
            await _unitOfWork.SaveChangesAsync();

            var updatedUser = _mapper.Map<PrixProduitParAgenceModel>(result);
            return Result<PrixProduitParAgenceModel>.Success(updatedUser);
        }

        /// <summary>
        /// delete the prix produit par agence with the given id
        /// </summary>
        /// <param name="id">the id of the prix produit par agence to be deleted</param>
        /// <returns>a result instant</returns>
        public async Task<Result> DeletePrixProduitParAgenceAsync(string id)
        {
            await _produitParAgenceDataAccess.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success($"the {nameof(PrixProduitParAgenceModel)} removed successfully");
        }

        #endregion

        #region private methods

        /// <summary>
        /// get get prix produit par agence by produit id and agence id
        /// </summary>
        /// <param name="produitId"></param>
        /// <param name="agenceId"></param>
        /// <returns></returns>
        private async Task<PrixProduitParAgence> GetPrixProduitParAgenceByProduitIdAndAgenceId(string produitId, string agenceId)
        {
            var request = _prixProduitParAgenceRequestBuilder
                .AddPredicate(e => e.ProduitId == produitId && e.AgenceId == agenceId)
                .Buil();
            return await _produitParAgenceDataAccess.GetSingleAsync(request);
        }

        /// <summary>
        /// filter paged list
        /// </summary>
        /// <typeparam name="TFilter"></typeparam>
        /// <param name="filterOption"></param>
        /// <returns></returns>
        protected override Expression<Func<Produit, bool>> BuildGetAsPagedPredicate<TFilter>(TFilter filterOption)
        {
            var predicate = PredicateBuilder.True<Produit>();

            if (_user.AgenceId.IsValid())
                predicate = predicate.And(c => c.AgenceId == _user.AgenceId || c.IsPublic);
            else
                predicate = predicate.And(c => !c.AgenceId.IsValid());

            return predicate;
        }

        #endregion

    }
}
