namespace COMPANY.Application.Services.DataService.Parameters.SourceDuLeadService
{
    using AutoMapper;
    using COMPANY.Application.Data;
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Interfaces;
    using COMPANY.Application.Models.BusinessEntities.Parameters.SourceDuLead;
    using COMPANY.Domain.Entities;
    using Inova.AutoInjection.Attributes;
    using Microsoft.Extensions.DependencyInjection;
    using System.Threading.Tasks;

    [Inject(typeof(ISourceDuLeadService), ServiceLifetime.Scoped)]
    public class SourceDuLeadService : BaseService<SourceDuLead, string, SourceDuLeadModel, SourceDuLeadCreateModel, SourceDuLeadUpdateModel>, ISourceDuLeadService
    {
        public SourceDuLeadService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IDataRequestBuilder<SourceDuLead> requestBuilder,
            ICurrentUserService currentUserService)
            : base(requestBuilder, unitOfWork, mapper, currentUserService)
        { }

        /// <summary>
        /// check if the there is any Source Du Lead with the given label or Abbreviation
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
