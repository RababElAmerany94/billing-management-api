namespace COMPANY.Application.Services.DataService.Parameters.ModeleSmsService
{
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Models.BusinessEntities.Parameters.ModeleSms;
    using COMPANY.Domain.Entities.Parameters;
    using System.Threading.Tasks;

    public interface IModeleSmsService : IBaseService<ModeleSms, string, ModeleSmsModel, ModeleSmsCreateModel, ModeleSmsUpdateModel>
    {
        /// <summary>
        /// check if the there is any logement with the given label or Abbreviation
        /// </summary>
        /// <param name="label"></param>
        /// <returns>true if unique, else false</returns>
        Task<Result<bool>> IsUniqueAsync(string name);
    }
}
