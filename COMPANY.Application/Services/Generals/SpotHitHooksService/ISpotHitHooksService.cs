namespace COMPANY.Application.Services.Generals.SpotHitHooksService
{
    using Company.SpotHit.Models;
    using System.Threading.Tasks;

    public interface ISpotHitHooksService
    {
        /// <summary>
        /// reveived response of sms in spothit
        /// </summary>
        /// <param name="response">the response detail</param>
        Task ReceptionResponse(PushResponse response);

        /// <summary>
        /// reveived stop of sms in spothit
        /// </summary>
        /// <param name="stop">the stop detail</param>
        Task ReceptionStop(PushStop stop);
    }
}
