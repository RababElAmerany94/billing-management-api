namespace COMPANY.Application.Services.DataService.CategoryProductService
{
    using AutoMapper;
    using COMPANY.Application.Data;
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Interfaces;
    using COMPANY.Application.Models.BusinessEntitiesModels.CategoryProductModels;
    using COMPANY.Domain.Entities;
    using Company.AutoInjection.Attributes;
    using Microsoft.Extensions.DependencyInjection;
    using System.Threading.Tasks;

    [Inject(typeof(ICategoryProductService), ServiceLifetime.Scoped)]
    public class CategoryProductService : BaseService<CategoryProduct, string, CategoryProductModel, CategoryProductCreateModel, CategoryProductUpdateModel>, ICategoryProductService
    {
        public CategoryProductService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IDataRequestBuilder<CategoryProduct> requestBuilder,
            ICurrentUserService currentUserService)
            : base(requestBuilder, unitOfWork, mapper, currentUserService)
        { }

        /// <summary>
        /// check if the there is any category product with the given label or Abbreviation
        /// </summary>
        /// <param name="label"></param>
        /// <returns>true if unique, else false</returns>
        public async Task<Result<bool>> IsUniqueAsync(string label)
        {
            var result = await _dataAccess.IsExistAsync(e => e.Name.ToLower() == label.ToLower());
            return Result<bool>.Success(!result);
        }

    }
}
