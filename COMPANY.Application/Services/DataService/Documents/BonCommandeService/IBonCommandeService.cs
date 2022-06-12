namespace COMPANY.Application.Services.DataService.Documents.BonCommandeService
{
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Models.BusinessEntities.Documents.BonCommande;
    using COMPANY.Application.Models.BusinessEntitiesModels.DocumentParametersModels;
    using COMPANY.Application.Models.GeneralModels.BodiesModels.MailModels;
    using COMPANY.Domain.Entities.Documents;
    using COMPANY.Domain.Entities.OwnedEntities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBonCommandeService
        : IBaseService<BonCommande, string, BonCommandeModel, BonCommandeCreateModel, BonCommandeUpdateModel>
    {
        /// <summary>
        /// check if the given reference is unique
        /// </summary>
        /// <param name="reference">the reference to be checked</param>
        /// <returns>true if unique, false if not</returns>
        Task<Result<bool>> CheckUniqueReferenceAsync(string reference);

        /// <summary>
        /// generate PDF of bon commande
        /// </summary>
        /// <param name="bonCommandeId">the bon commande id</param>
        /// <returns>a result of byte</returns>
        Task<Result<byte[]>> GeneratePdf(string bonCommandeId);

        /// <summary>
        /// generate example bon commande
        /// </summary>
        /// <param name="documentParameters">the parameters of document</param>
        /// <returns>a pdf result</returns>
        Result<byte[]> ExampleParametersModel(DocumentParametersModel documentParameters);

        /// <summary>
        /// send bon commande in email
        /// </summary>
        /// <param name="bonCommandeId">the id of bon commande</param>
        /// <param name="mailModel">the mail model</param>
        /// <returns>a instance of result</returns>
        Task<Result<ICollection<MailHistoryModel>>> SendInEmail(string bonCommandeId, MailModel mailModel);
    }
}
