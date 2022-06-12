namespace COMPANY.Application.Services.DataService.NumerotationService
{
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Enums;
    using COMPANY.Application.Models.BusinessEntities.Documents.DocumentComptable;
    using COMPANY.Application.Models.BusinessEntitiesModels.NumerotationModels;
    using COMPANY.Domain.Enums;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// an interface that defines the service for the numerotation entity
    /// </summary>
    public interface INumerotationService
    {
        /// <summary>
        /// get the list of all numerotations
        /// </summary>
        /// <returns>numerotation List</returns>
        Task<Result<IEnumerable<NumerotationModel>>> GetAllNumerotationAsync();

        /// <summary>
        /// get the numerotation with the  given id
        /// </summary>
        /// <param name="id">the id of the numerotation to retrieve</param>
        /// <returns>the numerotation result</returns>
        Task<Result<NumerotationModel>> GetNumerotationByIdAsync(string id);

        /// <summary>
        /// create the numerotation with the given values
        /// </summary>
        /// <param name="numerotationCreateModel">the create model for the numerotation entity</param>
        /// <returns>the newly created numerotation result</returns>
        Task<Result<NumerotationModel>> CreateNumerotationAsync(NumerotationCreateModel numerotationCreateModel);

        /// <summary>
        /// update the Numerotation from the given model
        /// </summary>
        /// <param name="numerotationId">the id of the Numerotation to be updated</param>
        /// <param name="numerotationModel">the update model</param>
        /// <returns>the update version of the Numerotation</returns>
        Task<Result<NumerotationModel>> UpdateNumerotationAsync(string numerotationId, NumerotationUpdateModel numerotationModel);

        /// <summary>
        /// generate numerotation
        /// </summary>
        /// <param name="type">the type of numerotation</param>
        /// <returns>the numerotation generated</returns>
        Task<Result<string>> GenerateNumerotationAsync(NumerotationType type);

        /// <summary>
        /// increment numerotation
        /// </summary>
        /// <param name="type">the type of numerotation</param>
        /// <returns>the result</returns>
        Task<Result> IncrementNumerotationAsync(NumerotationType type);

        /// <summary>
        /// create the numerotation with the given values
        /// </summary>
        /// <param name="numerotationCreateModel">the create model for the numerotation entity</param>
        /// <returns>the newly created numerotation result</returns>
        Task<Result> CreateListNumerotationAsync(List<NumerotationCreateModel> numerotationCreateModel);

        /// <summary>
        /// increment numerotation without save changes
        /// </summary>
        /// <param name="type">the type of numerotation</param>
        /// <returns>the result</returns>
        Task IncrementNumerotationWithoutSaveChangesAsync(NumerotationType type);

        /// <summary>
        /// generate reference for accounting document 
        /// </summary>
        /// <param name="creationDate">the creation date</param>
        /// <param name="type">the type of document comptable</param>
        /// <returns>a <see cref="ReferenceDocumentComptable"/> instance</returns>
        Task<Result<ReferenceDocumentComptable>> GenerateReferenceDocumentComptable(DateTime creationDate, DocumentComptableType type);
    }
}
