namespace COMPANY.Application.Services.DataService.Parameters.LogementTypeService
{
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Models.BusinessEntities.Parameters.LogementType;
    using COMPANY.Domain.Entities.Parameters;
    using System.Threading.Tasks;

    public interface ILogementTypeService :
        IBaseService<LogementType, string, LogementTypeModel, LogementTypeCreateModel, LogementTypeUpdateModel>
    {

        /// <summary>
        /// check if the there is any logement with the given label or Abbreviation
        /// </summary>
        /// <param name="label"></param>
        /// <returns>true if unique, else false</returns>
        Task<Result<bool>> IsUniqueAsync(string name);

    }
}
