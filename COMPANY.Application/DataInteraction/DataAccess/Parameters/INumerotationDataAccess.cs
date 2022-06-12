namespace COMPANY.Application.DataInteraction.DataAccess
{
    using COMPANY.Application.DataInteraction.DataAccess.Base;
    using COMPANY.Domain.Entities;
    using COMPANY.Domain.Enums;
    using System.Threading.Tasks;

    /// <summary>
    /// an interface that defines the dataAccess Layer for the numerotation
    /// </summary>
    public interface INumerotationDataAccess : IDataAccess<Numerotation, string>
    {
        /// <summary>
        /// Get numerotation by type and agence
        /// </summary>
        /// <param name="type">the type of numerotation</param>
        /// <param name="agenceId">the id of agence</param>
        /// <returns></returns>
        Task<Numerotation> GetNumerotationByTypeAndAgence(NumerotationType type, string agenceId);

    }
}
