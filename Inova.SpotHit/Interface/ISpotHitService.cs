namespace Inova.SpotHit.Interface
{
    using Inova.SpotHit.Models;
    using System.Threading.Tasks;

    public interface ISpotHitService
    {
        Task<ResponseModel> SendSms(SendSMS sendSMS);
    }
}
