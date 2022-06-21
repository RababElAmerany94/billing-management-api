namespace Inova.SpotHit.Services
{
    using COMPANY.Helpers;
    using Inova.SpotHit.Interface;
    using Inova.SpotHit.Models;
    using Newtonsoft.Json;
    using System;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Reflection;
    using System.Threading.Tasks;
    using System.Web;

    public partial class SpotHitService : ISpotHitService
    {
        public async Task<ResponseModel> SendSms(SendSMS sendSMS)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders
                      .Accept
                      .Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    sendSMS.SetApiKet(_secrets.APIKey);

                    var properties =
                        from p in sendSMS.GetType().GetProperties()
                        where p.GetValue(sendSMS, null) != null
                        select $"{p.GetCustomAttribute<JsonPropertyAttribute>().PropertyName}={HttpUtility.UrlEncode(p.GetValue(sendSMS, null).ToString())}";

                    string queryString = string.Join("&", properties.ToArray());

                    var response = await client.GetAsync($"{_secrets.SendSmsEndpoint}?{queryString}");
                    var result = (await response.Content.ReadAsStringAsync());
                    return result.FromJson<ResponseModel>();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }


    public partial class SpotHitService
    {
        private readonly SpotHitSecrets _secrets;

        public SpotHitService(SpotHitSecrets secrets)
        {
            _secrets = secrets;
        }
    }
}
