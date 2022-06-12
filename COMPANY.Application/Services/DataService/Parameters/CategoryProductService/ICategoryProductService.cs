namespace COMPANY.Application.Services.DataService.CategoryProductService
{
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Models.BusinessEntitiesModels.CategoryProductModels;
    using COMPANY.Domain.Entities;
    using System.Threading.Tasks;

    public interface ICategoryProductService : IBaseService<CategoryProduct, string, CategoryProductModel, CategoryProductCreateModel, CategoryProductUpdateModel>
    {
        /// <summary>
        /// check if the there is any category product with the given label or Abbreviation
        /// </summary>
        /// <param name="name"></param>
        /// <returns>true if unique, else false</returns>
        Task<Result<bool>> IsUniqueAsync(string name);
    }
}
