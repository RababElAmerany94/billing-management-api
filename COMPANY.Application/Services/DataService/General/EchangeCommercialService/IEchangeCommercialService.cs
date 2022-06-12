namespace COMPANY.Application.Services.DataService.TacheService
{
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Models.BusinessEntities.General.EchangeCommercial;
    using COMPANY.Domain.Entities;
    using COMPANY.Domain.Entities.OwnedEntities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// an interface that defines a set of service endpoint 
    /// for working with <see cref="EchangeCommercial"/> Entity
    /// </summary>
    public interface IEchangeCommercialService
        : IBaseService<EchangeCommercial, string, EchangeCommercialModel, EchangeCommercialCreateModel, EchangeCommercialUpdateModel>
    {

        /// <summary>
        /// save the given memos to the commercial exchange memos list
        /// </summary>
        /// <param name="id">the id of the commercial exchange to save the memo for him</param>
        /// <param name="memos">the memo to be saved</param>
        /// <returns>an operation result</returns>
        Task<Result> SaveMemosAsync(string id, ICollection<Memo> memos);

        /// <summary>
        /// synchronization commercial exchanges with Google Calendar
        /// </summary>
        /// <returns></returns>
        Task<Result> SynchronizationWithGoogleCalendar();

        /// <summary>
        /// update date event
        /// </summary>
        /// <param name="changeDateEventModel"></param>
        /// <returns></returns>
        Task<Result> UpdateDateEvent(ChangeDateEventModel changeDateEventModel);

        /// <summary>
        /// check RDV is exist
        /// </summary>
        /// <param name="model">the model represent criteria</param>
        /// <returns>a bool result</returns>
        Task<Result<bool>> CheckRdvIsExist(CheckRdvIsExistModel model);
    }
}
