namespace COMPANY.Application.Services.DataService.Parameters.ChampSiteInstallationService
{
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Models.BusinessEntities.Parameters.ChampsSiteInstallation;
    using COMPANY.Domain.Entities.Parameters;
    using System.Threading.Tasks;

    public interface IChampSiteInstallationService :
        IBaseService<ChampSiteInstallation, string, ChampSiteInstallationModel, ChampSiteInstallationCreateModel, ChampSiteInstallationUpdateModel>
    {
        /// <summary>
        /// check if the there is any with the given name
        /// </summary>
        /// <param name="name">the name of field</param>
        /// <returns>true if unique, else false</returns>
        Task<Result<bool>> IsUniqueAsync(string name);
    }
}
