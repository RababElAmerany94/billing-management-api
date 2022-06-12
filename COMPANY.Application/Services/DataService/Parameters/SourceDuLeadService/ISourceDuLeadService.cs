namespace COMPANY.Application.Services.DataService.Parameters.SourceDuLeadService
{
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Models.BusinessEntities.Parameters.SourceDuLead;
    using COMPANY.Domain.Entities;
    using System.Threading.Tasks;

    public interface ISourceDuLeadService : IBaseService<SourceDuLead, string, SourceDuLeadModel, SourceDuLeadCreateModel, SourceDuLeadUpdateModel>
    {
        /// <summary>
        /// check if the there is any category product with the given label or Abbreviation
        /// </summary>
        /// <param name="name"></param>
        /// <returns>true if unique, else false</returns>
        Task<Result<bool>> IsUniqueAsync(string name);
    }
}
