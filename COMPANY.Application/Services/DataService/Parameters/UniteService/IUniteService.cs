namespace COMPANY.Application.Services.DataService.UniteService
{
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Models.BusinessEntitiesModels.UniteModels;
    using COMPANY.Domain.Entities;
    using System.Threading.Tasks;

    /// <summary>
    /// an interface defines methods should every unite service implemented
    /// </summary>
    public interface IUniteService :
        IBaseService<Unite, string, UniteModel, UniteCreateModel, UniteUpdateModel>
    {
        /// <summary>
        /// check if the there is any unite with the given label or Abbreviation
        /// </summary>
        /// <param name="label"></param>
        /// <returns>true if unique, else false</returns>
        Task<Result<bool>> IsUniqueAsync(string name);
    }
}
