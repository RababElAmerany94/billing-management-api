namespace COMPANY.Application.Services.DataService.MarqueService
{
    using AutoMapper;
    using COMPANY.Application.Data;
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Interfaces;
    using COMPANY.Application.Models.BusinessEntitiesModels.SpecialArticleModels;
    using COMPANY.Domain.Entities;
    using Company.AutoInjection.Attributes;
    using Microsoft.Extensions.DependencyInjection;
    using System.Threading.Tasks;

    /// <summary>
    /// a class implemented <see cref="ISpecialArticleService"/>
    /// </summary>
    [Inject(typeof(ISpecialArticleService), ServiceLifetime.Scoped)]
    public class SpecialArticleService :
        BaseService<SpecialArticle, string, SpecialArticleModel, SpecialArticleCreateModel, SpecialArticleUpdateModel>, ISpecialArticleService
    {
        public SpecialArticleService(
             IUnitOfWork unitOfWork,
             IMapper mapper,
             IDataRequestBuilder<SpecialArticle> requestBuilder,
             ICurrentUserService currentUserService
        ) : base(requestBuilder, unitOfWork, mapper, currentUserService)
        { }

        /// <summary>
        /// check if the there is any special article with the given designation
        /// </summary>
        /// <param name="label"></param>
        /// <returns>true if unique, else false</returns>
        public async Task<Result<bool>> IsUniqueAsync(string label)
        {
            var result = await _dataAccess.IsExistAsync(e => e.Designation.ToLower() == label.ToLower() && e.AgenceId == _user.AgenceId);
            return Result<bool>.Success(!result);
        }
    }
}
