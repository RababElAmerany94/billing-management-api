namespace COMPANY.Application.Services.DataService.Documents.FactureService
{
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Models.BusinessEntities.Documents.Facture;
    using COMPANY.Application.Models.BusinessEntitiesModels.DocumentParametersModels;
    using COMPANY.Application.Models.General.FilterOptions;
    using COMPANY.Application.Models.GeneralModels.BodiesModels.MailModels;
    using COMPANY.Domain.Entities.Documents;
    using COMPANY.Domain.Entities.OwnedEntities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// an interface that defines a set of service endpoint 
    /// for working with <see cref="Facture"/> Entity
    /// </summary>
    public interface IFactureService :
        IBaseService<Facture, string, FactureModel, FactureCreateModel, FactureUpdateModel>
    {
        /// <summary>
        /// generate PDF of facture
        /// </summary>
        /// <param name="factureId">the facture id</param>
        /// <returns>a result of byte</returns>
        Task<Result<byte[]>> GeneratePdfFactureAsync(string factureId);

        /// <summary>
        /// generate example facture
        /// </summary>
        /// <param name="documentParameters">the parameters of document</param>
        /// <returns>a pdf result</returns>
        Result<byte[]> ExampleFacturePdfAsync(DocumentParametersModel documentParameters);

        /// <summary>
        /// send facture in email
        /// </summary>
        /// <param name="factureId">the id of facture</param>
        /// <param name="mailModel">the mail model</param>
        /// <returns>a instance of result</returns>
        Task<Result<ICollection<MailHistoryModel>>> SendFactureInEmail(string factureId, MailModel mailModel);

        /// <summary>
        /// cancel facture
        /// </summary>
        /// <param name="id">the id of facture</param>
        /// <returns>a result object</returns>
        Task<Result<FactureModel>> CancelFacture(string id);

        /// <summary>
        /// save the given memos to the user memos list
        /// </summary>
        /// <param name="id">the id of the user to save the memo for him</param>
        /// <param name="memos">the memo to be saved</param>
        /// <returns>an operation result</returns>
        Task<Result> SaveMemosAsync(string id, ICollection<Memo> memos);

        /// <summary>
        /// export releve facture pdf
        /// </summary>Fa
        /// <param name="filterOption">The filter option</param>
        /// <returns>a result instant</returns>
        Task<Result<ExportReleveFacturesModel>> ExportReleveFacturesPDFAsync(ReleveFacturesFilterOption filterOption);
    }
}
