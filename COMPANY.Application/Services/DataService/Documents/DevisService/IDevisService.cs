namespace COMPANY.Application.Services.DataService.DevisService
{
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Models.BusinessEntities.Documents.Devis;
    using COMPANY.Application.Models.BusinessEntitiesModels.DocumentParametersModels;
    using COMPANY.Application.Models.BusinessEntitiesModels.Documents.Devis;
    using COMPANY.Application.Models.GeneralModels.BodiesModels.MailModels;
    using COMPANY.Domain.Entities;
    using COMPANY.Domain.Entities.OwnedEntities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// a class describe devis service
    /// </summary>
    public interface IDevisService : IBaseService<Devis, string, DevisModel, DevisCreateModel, DevisUpdateModel>
    {
        /// <summary>
        /// check if the given reference is unique
        /// </summary>
        /// <param name="reference">the reference to be checked</param>
        /// <returns>true if unique, false if not</returns>
        Task<Result<bool>> CheckUniqueReferenceAsync(string reference);

        /// <summary>
        /// generate PDF of devis
        /// </summary>
        /// <param name="devisId">the devis id</param>
        /// <returns>a result of byte</returns>
        Task<Result<byte[]>> GeneratePDFDevis(string devisId);

        /// <summary>
        /// generate example devis
        /// </summary>
        /// <param name="documentParameters">the parameters of document</param>
        /// <returns>a pdf result</returns>
        Result<byte[]> ExampleDevisParametersModel(DocumentParametersModel documentParameters);

        /// <summary>
        /// send devis in email
        /// </summary>
        /// <param name="devisId">the id of devis</param>
        /// <param name="mailModel">the mail model</param>
        /// <returns>a instance of result</returns>
        Task<Result<ICollection<MailHistoryModel>>> SendDevisInEmail(string devisId, MailModel mailModel);

        /// <summary>
        /// sign a devis
        /// </summary>
        /// <param name="devisSignature">the devis signature model</param>
        /// <returns>a devis result</returns>
        Task<Result<DevisModel>> SignDevis(DevisSignatureModel devisSignature);
    }
}
