namespace COMPANY.Application.Services.DataService.Parameters.AgendaEvenementService
{
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Models.BusinessEntities.Parameters.AgendaEvenementType;
    using COMPANY.Domain.Entities.Parameters;
    using System.Threading.Tasks;

    public interface IAgendaEvenementService :
        IBaseService<AgendaEvenement, string, AgendaEvenementModel, AgendaEvenementCreateModel, AgendaEvenementUpdateModel>
    {
        /// <summary>
        /// check if the there is any agenda evenement type with the given name
        /// </summary>
        /// <param name="name">the name we want to check</param>
        Task<Result<bool>> IsUniqueAsync(string name);
    }
}
