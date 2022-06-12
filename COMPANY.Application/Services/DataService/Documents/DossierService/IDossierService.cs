namespace COMPANY.Application.Services.DataService.DossierService
{
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Models;
    using COMPANY.Application.Models.General.FilterOptions;
    using COMPANY.Domain.Entities;
    using COMPANY.Domain.Entities.OwnedEntities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// an interface that defines a set of service endpoint 
    /// for working with <see cref="Dossier"/> Entity
    /// </summary>
    public interface IDossierService
        : IBaseService<Dossier, string, DossierModel, DossierCreateModel, DossierUpdateModel>
    {
        /// <summary>
        /// check if the given reference is unique
        /// </summary>
        /// <param name="reference">the reference to be checked</param>
        /// <returns>true if unique, false if not</returns>
        Task<Result<bool>> CheckUniqueReferenceAsync(string reference);

        /// <summary>
        /// save the given memo to the dossier with the given id
        /// </summary>
        /// <param name="id">the id of the dossier to save the memo for it</param>
        /// <param name="memos">the memo to be saved</param>
        /// <returns>a result object</returns>
        Task<Result> SaveMemosDossierAsync(string id, ICollection<MemoDossier> memos);

        /// <summary>
        /// get articles of dossier
        /// </summary>
        /// <param name="dossierId">the id of dossier</param>
        /// <returns>a list of articles</returns>
        Task<Result<List<Article>>> GetDossierArticles(string dossierId);

        /// <summary>
        /// check user already assigned to another dossier in the same date and hour
        /// </summary>
        /// <returns>a boolean</returns>
        Task<Result<bool>> CheckUserAssignedSameDateAndHour(CheckUserAssignedSameDateAndHourFilterOption filterOption);

        /// <summary>
        /// mark dossier à planifier
        /// </summary>
        /// <param name="dossierId">the id of dossier</param>
        /// <returns>a result instance</returns>
        Task<Result> MarkDossierAplanifier(string dossierId);

        /// <summary>
        /// synchronize order of antsroute with our dossier
        /// </summary>
        /// <returns>a result instance contains dossier updated</returns>
        Task<Result<DossierModel>> SynchronizeWithAntsroute(string dossierId);

        /// <summary>
        /// synchronize orders of antsroute with our dossiers
        /// </summary>
        /// <returns>a result instance</returns>
        Task<Result> SynchronizeWithAntsroute();

        /// <summary>
        /// save the given viste technique to the dossier
        /// </summary>
        /// <param name="id">the id of the dossier to save the viste technique for him</param>
        /// <param name="visteTechnique">the viste technique to be saved</param>
        /// <returns>an operation result</returns>
        Task<Result> SaveVisteTechnique(string id, VisteTechnique visteTechnique);
    }
}
