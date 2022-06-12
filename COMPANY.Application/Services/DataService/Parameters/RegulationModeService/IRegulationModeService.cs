namespace COMPANY.Application.Services.DataService.RegulationModeService
{
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Models.BusinessEntitiesModels.RegulationModeModels;
    using COMPANY.Domain.Entities;
    using System.Threading.Tasks;

    /// <summary>
    /// an interface that defines a set of service endpoint 
    /// for working with <see cref="RegulationMode"/> Entity
    /// </summary>
    public interface IRegulationModeService :
        IBaseService<RegulationMode, string, RegulationModeModel, RegulationModeCreateModel, RegulationModeUpdateModel>
    {
        /// <summary>
        /// check if the there is any regulation mode with the given label or Abbreviation
        /// </summary>
        /// <param name="label">the label we want to check</param>
        Task<Result<bool>> IsUniqueAsync(string label);
    }
}
