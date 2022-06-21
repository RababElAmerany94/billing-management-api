namespace COMPANY.Application.Services.DataService.DocumentParametersService
{
    using AutoMapper;
    using COMPANY.Application.Data;
    using COMPANY.Application.DataInteraction.DataAccess;
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Interfaces;
    using COMPANY.Application.Models.BusinessEntitiesModels.DocumentParametersModels;
    using COMPANY.Domain.Entities;
    using Inova.AutoInjection.Attributes;
    using Microsoft.Extensions.DependencyInjection;
    using System.Threading.Tasks;

    [Inject(typeof(IDocumentParametersService), ServiceLifetime.Scoped)]
    public class DocumentParametersService :
        BaseService<DocumentParameters, string, DocumentParametersModel, DocumentParametersCreateModel, DocumentParametersUpdateModel>, IDocumentParametersService
    {
        private readonly IDocumentParametersDataAccess _documentParametersDataAccess;

        public DocumentParametersService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IDataRequestBuilder<DocumentParameters> requestBuilder,
            ICurrentUserService currentUserService)
            : base(requestBuilder, unitOfWork, mapper, currentUserService)
        {
            _documentParametersDataAccess = unitOfWork.DocumentParametersDataAccess;
        }

        /// <summary>
        /// get the DocumentParameters with the  given id
        /// </summary>
        /// <returns>the DocumentParameters result</returns>
        public async Task<Result<DocumentParametersModel>> GetDocumentParametersByIdAsync()
        {
            var result = await _documentParametersDataAccess.GetByAgenceIdAsync(_user.AgenceId);
            var data = _mapper.Map<DocumentParametersModel>(result);
            return Result< DocumentParametersModel>.Success(data);
        }

        /// <summary>
        /// create the DocumentParameters with the given values
        /// </summary>
        /// <param name="createModel">the consultant model for creating new entity</param>
        /// <returns>the newly created DocumentParameters result</returns>
        public async Task<Result<DocumentParametersModel>> CreateDocumentParametersAsync(DocumentParametersCreateModel createModel)
            => await CreateAsync(createModel);

        /// <summary>
        /// update the DocumentParameters from the given model
        /// </summary>
        /// <param name="id">the id of the DocumentParameters to be updated</param>
        /// <param name="updateModel">the update model</param>
        /// <returns>the update version of the DocumentParameters</returns>
        public async Task<Result<DocumentParametersModel>> UpdateDocumentParametersAsync(string id, DocumentParametersUpdateModel updateModel)
            => await UpdateAsync(id, updateModel);
    }
}
