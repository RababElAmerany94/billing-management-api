namespace COMPANY.Application.Services.DataService.MarqueService
{
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Models.BusinessEntitiesModels.SpecialArticleModels;
    using COMPANY.Domain.Entities;
    using System.Threading.Tasks;

    /// <summary>
    /// an interface describe special article service
    /// </summary>
    public interface ISpecialArticleService :
        IBaseService<SpecialArticle, string, SpecialArticleModel, SpecialArticleCreateModel, SpecialArticleUpdateModel>
    {
        /// <summary>
        /// check if the there is any special article with the given label or Abbreviation
        /// </summary>
        /// <param name="name"></param>
        /// <returns>true if unique, else false</returns>
        Task<Result<bool>> IsUniqueAsync(string name);
    }
}
