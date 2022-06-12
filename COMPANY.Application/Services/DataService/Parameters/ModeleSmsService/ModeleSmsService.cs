namespace COMPANY.Application.Services.DataService.Parameters.ModeleSmsService
{
    using AutoMapper;
    using COMPANY.Application.Data;
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Interfaces;
    using COMPANY.Application.Models.BusinessEntities.Parameters.ModeleSms;
    using COMPANY.Domain.Entities.Parameters;
    using Company.AutoInjection.Attributes;
    using Microsoft.Extensions.DependencyInjection;
    using System.Threading.Tasks;

    [Inject(typeof(IModeleSmsService), ServiceLifetime.Scoped)]
    public class ModeleSmsService :
        BaseService<ModeleSms, string, ModeleSmsModel, ModeleSmsCreateModel, ModeleSmsUpdateModel>,
        IModeleSmsService
    {
        public ModeleSmsService(
            IDataRequestBuilder<ModeleSms> dataRequestBuilder,
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
