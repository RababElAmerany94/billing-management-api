namespace COMPANY.Application.Services.DataService
{
    using AutoMapper;
    using COMPANY.Application.Data;
    using COMPANY.Application.DataInteraction.DataAccess.Base;
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Exceptions;
    using COMPANY.Application.Interfaces;
    using COMPANY.Application.Models;
    using COMPANY.Application.Models.BusinessEntities.General.Base;
    using COMPANY.Application.Models.BusinessEntitiesModels.AccountModels;
    using COMPANY.Domain.Interfaces;
    using COMPANY.Presistence.Implementations;
    using Microsoft.EntityFrameworkCore.Query;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    /// <summary>
    /// the base interface for all DataServices
    /// </summary>
    public class BaseService<TEntity, TKey, TModel, TCreateModel, TUpdateModel> : IBaseService<TEntity, TKey, TModel, TCreateModel, TUpdateModel>
        where TEntity : class, IEntity<TKey>
        where TUpdateModel : IEntityUpdateModel<TEntity>
    {

        protected readonly IDataAccess<TEntity, TKey> _dataAccess;
        protected readonly IDataRequestBuilder<TEntity> _dataRequestBuilder;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        protected readonly UserTokenInformation _user;
        protected readonly string _entityName = typeof(TEntity).Name;

        public BaseService(
           IDataRequestBuilder<TEntity> dataRequestBuilder,
           IUnitOfWork unitOfWork,
           IMapper mapper,
           ICurrentUserService currentUser)
        {
            _dataAccess = unitOfWork.DataAccess<TEntity, TKey>();
            _dataRequestBuilder = dataRequestBuilder;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _user = currentUser.User;
        }

        public async Task<Result<TModel>> CreateAsync(TCreateModel createModel)
        {
            var entity = _mapper.Map<TEntity>(createModel);

            if (entity is IRecordable recordable)
                recordable.Historique = Extentions.RecoredAddNewItemHistory(_user.Id);

            await BeforeAddEntity(entity, createModel);

            await _dataAccess.AddAsync(entity);

            await AfterAddEntity(entity, createModel);

            await _unitOfWork.SaveChangesAsync();

            await AfterSaveChangesAddEntity(entity, createModel);

            var data = _mapper.Map<TModel>(entity);

            return Result<TModel>.Success(data, $"{_entityName} added successfully");
        }

        public virtual async Task<Result> DeleteAsync(TKey id)
        {
            await BeforeDeleteEntity(id);
            var entity = await _dataAccess.DeleteAsync(id);
            await AfterDeleteEntity(entity);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success($"{_entityName} removed successfully");
        }

        public async Task<PagedResult<TModel>> GeAsPagedResultAsync<TFilter>(TFilter filterOption)
            where TFilter : FilterOption
        {
            var request = BuildAsPagedDataRequest(filterOption);
            var result = await _dataAccess.GetPagedResultAsync(filterOption, request);

            if (!result.HasValue)
                return PagedResult<TModel>.Failed(result.Error, $"Failed to retrieve list of {_entityName}");

            var data = _mapper.Map<IEnumerable<TModel>>(result.Value);
            return PagedResult<TModel>.Success(
                data, result.CurrentPage, result.PageCount, result.PageSize, result.RowCount,
                $"list of {_entityName} retrieved successfully");
        }

        public async Task<Result<IEnumerable<TModel>>> GetAllAsync()
        {
            var request = BuildListDataRequest();
            var result = await _dataAccess.GetAsync(request);

            if (result is null)
                return PagedResult<TModel>.Failed(null, $"Failed to retrieve list of {_entityName}");

            var data = _mapper.Map<IEnumerable<TModel>>(result);
            return Result<IEnumerable<TModel>>.Success(data);
        }

        public async Task<Result<TModel>> UpdateAsync(TKey id, TUpdateModel updateModel)
        {
            var entity = await GetEntityByIdAsync(id);

            if (entity is IRecordable)
                RecoredChanges(updateModel, entity);

            await BeforeUpdateEntity(entity, updateModel);

            updateModel.Update(entity);

            _dataAccess.Update(entity);

            await AfterUpdateEntity(entity, updateModel);

            await _unitOfWork.SaveChangesAsync();

            await AfterSaveChangesUpdateEntity(entity, updateModel);

            var data = _mapper.Map<TModel>(entity);
            return Result<TModel>.Success(data, $"{_entityName} updated successfully");
        }

        public async Task<Result<TModel>> GetByIdAsync(TKey id)
        {
            TEntity entity = await GetEntityByIdAsyncWithRelatedEntity(id);
            var data = _mapper.Map<TModel>(entity);
            await AfterGetByIdEntity(entity, data);
            return Result<TModel>.Success(data, $"the {_entityName} retrieved successfully");
        }

        #region virtual methods

        protected virtual Task BeforeAddEntity(TEntity entity, TCreateModel model)
            => Task.CompletedTask;

        protected virtual Task AfterAddEntity(TEntity entity, TCreateModel model)
            => Task.CompletedTask;

        protected virtual Task AfterSaveChangesAddEntity(TEntity entity, TCreateModel model)
            => Task.CompletedTask;

        protected virtual Task BeforeUpdateEntity(TEntity entity, TUpdateModel model)
            => Task.CompletedTask;

        protected virtual Task AfterUpdateEntity(TEntity entity, TUpdateModel model)
            => Task.CompletedTask;

        protected virtual Task AfterSaveChangesUpdateEntity(TEntity entity, TUpdateModel model)
            => Task.CompletedTask;

        protected virtual Task AfterGetByIdEntity(TEntity entity, TModel model)
            => Task.CompletedTask;

        protected virtual Task BeforeDeleteEntity(TKey id)
            => Task.CompletedTask;

        protected virtual Task AfterDeleteEntity(TEntity entity)
            => Task.CompletedTask;

        protected virtual Expression<Func<TEntity, bool>> BuildGetAsPagedPredicate<TFilter>(TFilter filterOption)
            where TFilter : FilterOption
            => PredicateBuilder.True<TEntity>();

        protected virtual Expression<Func<TEntity, bool>> BuildGetListPredicate()
           => PredicateBuilder.True<TEntity>();

        protected virtual Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> BuildIncludesList()
           => null;

        protected virtual Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> BuildIncludesGetById()
           => null;

        #endregion

        #region privates 

        /// <summary>
        /// build get as paged data request form the given filter option
        /// </summary>
        /// <param name="filterOption">the filter options</param>
        /// <returns>the data request</returns>
        protected IDataRequest<TEntity> BuildAsPagedDataRequest<TFilter>(TFilter filterOption)
            where TFilter : FilterOption
            => _dataRequestBuilder.AddInclude(BuildIncludesList())
                .AddPredicate(BuildGetAsPagedPredicate(filterOption))
                .Buil();

        /// <summary>
        /// build get list data request
        /// </summary>
        /// <returns>the data request</returns>
        private IDataRequest<TEntity> BuildListDataRequest()
            => _dataRequestBuilder
                .AddPredicate(BuildGetListPredicate())
                .AddInclude(BuildIncludesList())
                .Buil();

        /// <summary>
        /// detect the changes and add them to the history of the <see cref="TEntity"/> how is updated
        /// </summary>
        /// <param name="updateModel">the update model, with all new values</param>
        /// <param name="entity">the client in database</param>
        private void RecoredChanges<T>(TUpdateModel updateModel, T entity)
        {
            /// convert the <see cref="TEntity"/> to the <see cref="TUpdateModel"/>
            var entityInDb = _mapper.Map<TUpdateModel>(entity);

            // get the changes between the new and old values
            var changesResult = Extentions.GetChangedFields(entityInDb, updateModel);

            if (changesResult.Count > 0 && entity is IRecordable recordable)
                recordable.Historique = Extentions.RecoredUpdateOperation(recordable.Historique, _user.Id, changesResult);
        }

        private IDataRequest<TEntity> BuildIncludeGetById()
        {
            return _dataRequestBuilder.AddInclude(BuildIncludesGetById()).Buil();
        }

        #endregion

        #region protected

        protected async Task<TEntity> GetEntityByIdAsyncWithRelatedEntity(TKey id)
        {
            var request = BuildIncludeGetById();
            var entity = await _dataAccess.GetAsync(id, request);

            if (entity is null)
                throw new NotFoundException($"there is not {_entityName} with given {id}");

            return entity;
        }

        protected async Task<TEntity> GetEntityByIdAsync(TKey id)
        {
            var entity = await _dataAccess.GetAsync(id);

            if (entity is null)
                throw new NotFoundException($"there is not {_entityName} with given {id}");

            return entity;
        }

        #endregion

    }
}
