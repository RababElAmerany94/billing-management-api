namespace COMPANY.Application.Models.BusinessEntitiesModels.AccountingPeriodModals
{
    using System;

    /// <summary>
    /// a class describe accounting period create model
    /// </summary>
    public class PeriodeComptableCreateModel
    {
        /// <summary>
        /// period of accounting period (12,16 months)
        /// </summary>
        public int Period { get; set; }

        /// <summary>
        /// start date of accounting period
        /// </summary>
        public DateTime DateDebut { get; set; }

        /// <summary>
        /// the id of the agence of this accounting period
        /// </summary>
        public string AgenceId { get; set; }
    }
}
