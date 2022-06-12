namespace COMPANY.Application.Services.DataService.General.SmsService
{
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Models.BusinessEntities.General.Sms;
    using COMPANY.Application.Models.Generals.FilterOptions;
    using COMPANY.Presistence.Implementations;
    using System.Threading.Tasks;

    public interface ISmsService
    {
        /// <summary>
        /// send sms
        /// </summary>
        /// <param name="model">the model</param>
        /// <returns>a result of send sms</returns>
        Task<Result<SmsModel>> EnvoyerSms(EnvoyerSmsModel model);

        /// <summary>
        /// get list sms as paged
        /// </summary>
        /// <param name="filterOption">the filter option</param>
        /// <returns>a paged result</returns>
        Task<PagedResult<SmsModel>> GeAsPagedResultAsync(SmsFilterOption filterOption);
    }
}
