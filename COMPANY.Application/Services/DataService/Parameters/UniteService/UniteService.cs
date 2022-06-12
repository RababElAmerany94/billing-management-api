namespace COMPANY.Application.Services.DataService.UniteService
{
    using AutoMapper;
    using COMPANY.Application.Data;
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Interfaces;
    using COMPANY.Application.Models.BusinessEntitiesModels.UniteModels;
    using COMPANY.Domain.Entities;
    using Company.AutoInjection.Attributes;
    using Microsoft.Extensions.DependencyInjection;
    using System.Threading.Tasks;

    /// <summary>
    /// a class describe unite service
    /// </summary>
    [Inject(typeof(IUniteService), ServiceLifetime.Scoped)]
    public class UniteService : BaseService<Unite, string, UniteModel, UniteCreateModel, UniteUpdateModel>, IUniteService
    {
        public UniteService(IDataRequestBuilder<Unite> dataRequestBuilder,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ICurrentUserService currentUser) : base(dataRequestBuilder, unitOfWork, mapper, currentUser)
        { }

        /// <summary>
        /// check if the there is any unite with the given label or Abbreviation
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
