namespace COMPANY.Application.DataInteraction.DataAccess
{
    using COMPANY.Application.Data;
    using COMPANY.Application.DataInteraction.DataAccess.Base;
    using COMPANY.Domain.Enums.Documents;
    using System.Threading.Tasks;

    /// <summary>
    /// an interface that defines the dataAccess Layer for the folder
    /// </summary>
    public interface IPaiementDataAccess : IDataAccess<Paiement, string>
    {
        /// <summary>
        /// Get total paiements with the given data request 
        /// </summary>
        /// <param name="request">the data request</param>
        /// <returns>a result object</returns>
        Task<decimal> GetTotalPaiementsAsync(IDataRequest<Paiement> request = null);
    }
}
