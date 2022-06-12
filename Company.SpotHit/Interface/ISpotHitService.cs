namespace Company.SpotHit.Interface
{
    using Company.SpotHit.Models;
    using System.Threading.Tasks;

    public interface ISpotHitService
    {
        Task<ResponseModel> SendSms(SendSMS sendSMS);
    }
}
