namespace COMPANY.Application.Models.BusinessEntitiesModels.AccountingPeriodModals
{
    using COMPANY.Application.Models.BusinessEntities.General.Base;
    using System;

    /// <summary>
    /// a class describe accounting period model
    /// </summary>
    public class PeriodeComptableModel :EntityModel<string>
    {
        /// <summary>
        /// start date of accounting period
        /// </summary>
        public DateTime DateDebut { get; set; }

        /// <summary>
        /// period of accounting period (12,16 months)
        /// </summary>
        public int Period { get; set; }

        /// <summary>
        /// the id of the agence of this accounting period
        /// </summary>
        public string AgenceId { get; set; }
    }
}
