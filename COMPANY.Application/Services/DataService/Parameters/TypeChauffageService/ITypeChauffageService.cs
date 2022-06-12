namespace COMPANY.Application.Services.DataService.Parameters.TypeChauffageService
{
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Models.BusinessEntities.Parameters.TypeChauffage;
    using COMPANY.Domain.Entities.Parameters;
    using System.Threading.Tasks;

    public interface ITypeChauffageService :
        IBaseService<TypeChauffage, string, TypeChauffageModel, TypeChauffageCreateModel, TypeChauffageUpdateModel>
    {

        /// <summary>
        /// check if the there is any type de chauffage with the given name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>true if unique, else false</returns>
        Task<Result<bool>> IsUniqueAsync(string name);

    }
}
