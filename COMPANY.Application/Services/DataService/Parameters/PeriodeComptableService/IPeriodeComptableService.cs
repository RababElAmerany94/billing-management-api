namespace COMPANY.Application.Services.DataService.PeriodeComptableService
{
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Models.BusinessEntitiesModels.AccountingPeriodModals;
    using COMPANY.Domain.Entities;
    using System.Threading.Tasks;

    // <summary>
    /// an interface that defines a set of service endpoint 
    /// for working with <see cref="PeriodeComptable"/> Entity 
    /// </summary>
    public interface IPeriodeComptableService : IBaseService<PeriodeComptable, string, PeriodeComptableModel, PeriodeComptableCreateModel, PeriodeComptableUpdateModel>
    {
        /// <summary>
        /// closing accounting period
        /// </summary>
        /// <param name="PeriodComptableId">the id of accounting period</param>
        /// <returns>return result</returns>
        Task<Result> ClosingPeriodComptable(string PeriodComptableId);
    }
}
