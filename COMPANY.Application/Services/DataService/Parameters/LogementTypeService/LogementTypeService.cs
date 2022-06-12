namespace COMPANY.Application.Services.DataService.Parameters.LogementTypeService
{
    using AutoMapper;
    using COMPANY.Application.Data;
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Interfaces;
    using COMPANY.Application.Models.BusinessEntities.Parameters.LogementType;
    using COMPANY.Domain.Entities.Parameters;
    using Company.AutoInjection.Attributes;
    using Microsoft.Extensions.DependencyInjection;
    using System.Threading.Tasks;

    [Inject(typeof(ILogementTypeService), ServiceLifetime.Scoped)]
    public class LogementTypeService :
        BaseService<LogementType, string, LogementTypeModel, LogementTypeCreateModel, LogementTypeUpdateModel>, ILogementTypeService
    {
        public LogementTypeService(
            IDataRequestBuilder<LogementType> dataRequestBuilder,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ICurrentUserService currentUser) : base(dataRequestBuilder, unitOfWork, mapper, currentUser)
        { }

        /// <summary>
        /// check if the there is any logement type with the given label or Abbreviation
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
