namespace COMPANY.Application.Services.DataService.Documents
{
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Models.BusinessEntities.Documents.Avoir;
    using COMPANY.Application.Models.BusinessEntitiesModels.DocumentParametersModels;
    using COMPANY.Application.Models.GeneralModels.BodiesModels.MailModels;
    using COMPANY.Domain.Entities.Documents;
    using COMPANY.Domain.Entities.OwnedEntities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// an interface that defines a set of service endpoint 
    /// for working with <see cref="Avoir"/> Entity
    /// </summary>
    public interface IAvoirService :
        IBaseService<Avoir, string, AvoirModel, AvoirCreateModel, AvoirUpdateModel>
    {
        /// <summary>
        /// generate PDF of avoir
        /// </summary>
        /// <param name="avoirId">the avoir id</param>
        /// <returns>a result of byte</returns>
        Task<Result<byte[]>> GeneratePdfAvoirAsync(string avoirId);

        /// <summary>
        /// generate example avoir
        /// </summary>
        /// <param name="documentParameters">the parameters of document</param>
        /// <returns>a pdf result</returns>
        Result<byte[]> ExampleAvoirPdfAsync(DocumentParametersModel documentParameters);

        /// <summary>
        /// send avoir in email
        /// </summary>
        /// <param name="avoirId">the id of avoir</param>
        /// <param name="mailModel">the mail model</param>
        /// <returns>a instance of result</returns>
        Task<Result<ICollection<MailHistoryModel>>> SendAvoirInEmail(string avoirId, MailModel mailModel);

        /// <summary>
        /// save the given memos to the user memos list
        /// </summary>
        /// <param name="id">the id of the user to save the memo for him</param>
        /// <param name="memos">the memo to be saved</param>
        /// <returns>an operation result</returns>
        Task<Result> SaveMemosAsync(string id, ICollection<Memo> memos);
    }
}
