namespace COMPANY.Application.Services.DataService.CategoryDocumentsService
{
    using AutoMapper;
    using COMPANY.Application.Data;
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Interfaces;
    using COMPANY.Application.Models.BusinessEntitiesModels.CategoryDocumentsModels;
    using COMPANY.Domain.Entities.Parameters;
    using Company.AutoInjection.Attributes;
    using Microsoft.Extensions.DependencyInjection;
    using System.Threading.Tasks;

    /// <summary>
    /// the implementation of the <see cref="ICategoryDocumentsService"/>
    /// </summary>
    [Inject(typeof(ICategoryDocumentsService), ServiceLifetime.Scoped)]
    public class CategoryDocumentsService :
        BaseService<CategoryDocuments, string, CategoryDocumentModel, CategoryDocumentCreateModel, CategoryDocumentUpdateModel>, ICategoryDocumentsService
    {

        public CategoryDocumentsService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IDataRequestBuilder<CategoryDocuments> requestBuilder,
            ICurrentUserService currentUserService)
            : base(requestBuilder, unitOfWork, mapper, currentUserService)
        { }

        /// <summary>
        /// check if the there is any category Documents with the given name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>true if unique, else false</returns>
        public async Task<Result<bool>> IsUniqueAsync(string name)
        {
            var result = await _dataAccess.IsExistAsync(e => e.Name.ToLower() == name.ToLower());
            return Result<bool>.Success(!result);
        }
    }
}
