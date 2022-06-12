namespace COMPANY.Application.Services.DataService.Documents.PaiementService
{
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Models.BusinessEntities.Documents.Paiement;
    using COMPANY.Domain.Enums.Documents;
    using System.Threading.Tasks;
    using Xterme.Application.Models.GeneralModels.PagingModels;

    /// <summary>
    /// an interface that defines a set of service endpoint 
    /// for working with <see cref="Paiement"/> Entity
    /// </summary>
    public interface IPaiementService :
        IBaseService<Paiement, string, PaiementModel, PaiementCreateModel, PaiementUpdateModel>
    {
        /// <summary>
        /// movement amount from account to another account
        /// </summary>
        /// <param name="paimentMovementModel">the model describe movement</param>
        /// <returns>a result instant</returns>
       Task<Result> MovementCompteToCompte(PaiementMovementCompteToCompteModel paimentMovementModel);

        /// <summary>
        /// return total of paiments
        /// </summary>
        /// <param name="filterOption">the filter option</param>
        /// <returns>return the result instance</returns>
        Task<Result<decimal>> GetTotalPaiementsAsync(PaiementFilterOption filterOption);

        /// <summary>
        /// paiement groupe of obligé
        /// </summary>
        /// <param name="model">the model paiement</param>
        /// <returns>a result status</returns>
        Task<Result> PaiementGroupeOblige(PaiementGroupeObligeModel model);
    }
}
