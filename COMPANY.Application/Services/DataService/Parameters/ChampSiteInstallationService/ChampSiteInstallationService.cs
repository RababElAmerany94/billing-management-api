namespace COMPANY.Application.Services.DataService.Parameters.ChampSiteInstallationService
{
    using AutoMapper;
    using COMPANY.Application.Data;
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Interfaces;
    using COMPANY.Application.Models.BusinessEntities.Parameters.ChampsSiteInstallation;
    using COMPANY.Domain.Entities.Parameters;
    using Company.AutoInjection.Attributes;
    using Microsoft.Extensions.DependencyInjection;
    using System.Threading.Tasks;

    [Inject(typeof(IChampSiteInstallationService), ServiceLifetime.Scoped)]
    public class ChampSiteInstallationService :
        BaseService<ChampSiteInstallation, string, ChampSiteInstallationModel, ChampSiteInstallationCreateModel, ChampSiteInstallationUpdateModel>,
        IChampSiteInstallationService
    {
        public ChampSiteInstallationService(
            IDataRequestBuilder<ChampSiteInstallation> dataRequestBuilder,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ICurrentUserService currentUser) : base(dataRequestBuilder, unitOfWork, mapper, currentUser)
        { }

        /// <summary>
        /// check if the there is any with the given name
        /// </summary>
        /// <param name="name">the name of field</param>
        /// <returns>true if unique, else false</returns>
        public async Task<Result<bool>> IsUniqueAsync(string name)
        {
            var result = await _dataAccess.IsExistAsync(e => e.Name.ToLower() == name.ToLower());
            return Result<bool>.Success(!result);
        }
    }
}
