namespace COMPANY.Application.DataInteraction.DataAccess
{
    using COMPANY.Application.DataInteraction.DataAccess.Base;
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Domain.Entities;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// an interface that defines the dataAccess Layer for the periode comptable
    /// </summary>
    public interface IPeriodeComptableDataAccess : IDataAccess<PeriodeComptable, string>
    {
        /// <summary>
        /// get the periode comptable with the given id
        /// </summary>
        /// <param name="agenceId">the id of agence</param>
        /// <returns>the periode comptable</returns>
        Task<PeriodeComptable> GetCurrentPeriodeComptableAsync(string agenceId);


        /// <summary>
        /// cloture comptable
        /// </summary>
        /// <param name="dateStart">the date start of accounting period</param>
        /// <param name="dateEnd">the date end of accounting period</param>
        /// <param name="agenceId">the agence id who has this period</param>
        /// <returns>a boolean result</returns>
        Task<Result<bool>> ClotureComptable(DateTime dateStart, DateTime dateEnd, string agenceId);

    }
}
