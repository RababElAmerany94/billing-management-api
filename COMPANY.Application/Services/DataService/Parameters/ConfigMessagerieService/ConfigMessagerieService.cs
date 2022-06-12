namespace COMPANY.Application.Services.DataService.ConfigMessagerieService
{
    using AutoMapper;
    using COMPANY.Application.Data;
    using COMPANY.Application.DataInteraction.DataAccess;
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Interfaces;
    using COMPANY.Application.Models.BusinessEntitiesModels.ConfigMessagerieModels;
    using COMPANY.Domain.Entities;
    using Company.AutoInjection.Attributes;
    using Microsoft.Extensions.DependencyInjection;
    using System.Threading.Tasks;

    [Inject(typeof(IConfigMessagerieService), ServiceLifetime.Scoped)]
    public class ConfigMessagerieService :
        BaseService<ConfigMessagerie, string, ConfigMessagerieModel, ConfigMessagerieCreateModel, ConfigMessagerieUpdateModel>, IConfigMessagerieService
    {

        private readonly IConfigMessagerieDataAccess _configMessagerieDataAccess;

        public ConfigMessagerieService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IDataRequestBuilder<ConfigMessagerie> requestBuilder,
            ICurrentUserService currentUserService)
            : base(requestBuilder, unitOfWork, mapper, currentUserService)
        {
            _configMessagerieDataAccess = unitOfWork.ConfigMessagerieDataAccess;
        }

        /// <summary>
        /// create the DocumentParameters with the given values
        /// </summary>
        /// <param name="createModel">the consultant model for creating new entity</param>
        /// <returns>the newly created DocumentParameters result</returns>
        public async Task<Result<ConfigMessagerieModel>> CreateConfigMessagerieAsync(ConfigMessagerieCreateModel createModel)
            => await CreateAsync(createModel);

        /// <summary>
        /// get the config messagerie with the  given id
        /// </summary>
        /// <returns>the ConfigMessagerie result</returns>
        public async Task<Result<ConfigMessagerieModel>> GetConfigMessagerieAsync()
        {
            var result = await _configMessagerieDataAccess.GetConfigMessagerieByAgenceIdAsync(_user.AgenceId);
            var data = _mapper.Map<ConfigMessagerieModel>(result);
            return Result<ConfigMessagerieModel>.Success(data);
        }

        /// <summary>
        /// update the config messagerie from the given model
        /// </summary>
        /// <param name="id">the id of the configMessagerie to be updated</param>
        /// <param name="updateModel">the update model</param>
        /// <returns>the update version of the config messagerie</returns>
        public async Task<Result<ConfigMessagerieModel>> UpdateConfigMessagerieAsync(string id, ConfigMessagerieUpdateModel updateModel)
            => await UpdateAsync(id, updateModel);
    }
}
