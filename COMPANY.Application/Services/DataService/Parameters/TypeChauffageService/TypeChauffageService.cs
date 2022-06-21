namespace COMPANY.Application.Services.DataService.Parameters.TypeChauffageService
{
    using AutoMapper;
    using COMPANY.Application.Data;
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Interfaces;
    using COMPANY.Application.Models.BusinessEntities.Parameters.TypeChauffage;
    using COMPANY.Domain.Entities.Parameters;
    using Inova.AutoInjection.Attributes;
    using Microsoft.Extensions.DependencyInjection;
    using System.Threading.Tasks;

    [Inject(typeof(ITypeChauffageService), ServiceLifetime.Scoped)]
    public class TypeChauffageService :
        BaseService<TypeChauffage, string, TypeChauffageModel, TypeChauffageCreateModel, TypeChauffageUpdateModel>, ITypeChauffageService
    {
        public TypeChauffageService(
            IDataRequestBuilder<TypeChauffage> dataRequestBuilder,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ICurrentUserService currentUser) : base(dataRequestBuilder, unitOfWork, mapper, currentUser)
        { }

        /// <summary>
        /// check if the there is any TypeChauffage type with the given name
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
