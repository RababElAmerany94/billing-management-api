namespace COMPANY.Application.Models.BusinessEntitiesModels.AccountingPeriodModals
{
    using COMPANY.Application.Models.BusinessEntities.General.Base;
    using COMPANY.Domain.Entities;

    /// <summary>
    /// class describe accounting period update model
    /// </summary>
    public class PeriodeComptableUpdateModel : PeriodeComptableCreateModel, IEntityUpdateModel<PeriodeComptable>
    {
        /// <summary>
        /// update accounting period 
        /// </summary>
        /// <param name="accountingPeriod">the accounting period entity</param>
        public void Update(PeriodeComptable periodeComptable)
        {
            periodeComptable.DateDebut = DateDebut;
            periodeComptable.Period = Period;
        }
    }
}
