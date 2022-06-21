namespace COMPANY.Application.Services.DataService.RegulationModeService
{
    using AutoMapper;
    using COMPANY.Application.Data;
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Exceptions;
    using COMPANY.Application.Interfaces;
    using COMPANY.Application.Models.BusinessEntitiesModels.RegulationModeModels;
    using COMPANY.Domain.Entities;
    using Inova.AutoInjection.Attributes;
    using Microsoft.Extensions.DependencyInjection;
    using System.Threading.Tasks;

    /// <summary>
    /// the implementation of the <see cref="IRegulationModeService"/>
    /// </summary>
    [Inject(typeof(IRegulationModeService), ServiceLifetime.Scoped)]
    public class RegulationModeService :
        BaseService<RegulationMode, string, RegulationModeModel, RegulationModeCreateModel, RegulationModeUpdateModel>,
        IRegulationModeService
    {
        public RegulationModeService(IDataRequestBuilder<RegulationMode> dataRequestBuilder,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ICurrentUserService currentUser) : base(dataRequestBuilder, unitOfWork, mapper, currentUser)
        { }

        /// <summary>
        /// check if the there is any regulation mode with the given label or Abbreviation
        /// </summary>
        /// <param name="label">the label we want to check</param>
        public async Task<Result<bool>> IsUniqueAsync(string label)
        {
            var result = await _dataAccess.IsExistAsync(e => e.Name.ToLower() == label.ToLower());
            return Result<bool>.Success(!result);
        }

        #region overrides

        protected override async Task BeforeDeleteEntity(string id)
        {
            var entity = await GetEntityByIdAsync(id);

            if (!entity.IsModify)
                throw new UnAuthorizedException($"this {nameof(RegulationMode)} is not modifiable");
        }

        protected override Task BeforeUpdateEntity(RegulationMode entity, RegulationModeUpdateModel model)
        {
            if (!entity.IsModify)
                model.Name = entity.Name;

            return base.BeforeUpdateEntity(entity, model);
        }

        #endregion
    }
}
