namespace COMPANY.Infrastructure.AntsrouteService
{
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Models.GeneralModels;
    using COMPANY.Application.Models.Generals.Antsroute;
    using COMPANY.Application.Services.Generals.AntsrouteService;
    using COMPANY.Application.Tools;
    using COMPANY.Helpers;
    using Company.AutoInjection.Attributes;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using System;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    [Inject(typeof(IAntsrouteService), ServiceLifetime.Singleton)]
    public partial class AntsrouteService : IAntsrouteService
    {
        public async Task<Result<BasketOrderResult>> CreateOrder(BasketOrderCreateModel order)
        {
            try
            {
                _logger.LogInformation(
                    LogEvent.AntsrouteCreateBasketOrder,
                    "Executing [{methodName}] to create order with content [{messageId}]",
                    nameof(CreateOrder),
                    order.ToJson());

                using (var client = new HttpClient())
                {
                    _logger.LogDebug(LogEvent.AntsrouteCreateBasketOrder, "Creating the request body...");
                    string requestBody = order.ToJson();

                    _logger.LogDebug(LogEvent.AntsrouteCreateBasketOrder, "sending request to Antsoute");

                    client.DefaultRequestHeaders.Add("cakey", _antsrouteSecrets.APIKey);
                    var response = await client.PostAsync(_antsrouteSecrets.CreateBasketOrderEndpoint, new StringContent(requestBody, Encoding.UTF8, "application/json"));

                    if (response.StatusCode != System.Net.HttpStatusCode.Created)
                    {
                        _logger.LogError("Failed to create basket order [{@order}] request response : [{@response}]", requestBody, response);
                        return Result<BasketOrderResult>.Failed(null, null, "Failed to create basket order ");
                    }

                    var result = (await response.Content.ReadAsStringAsync())
                            .FromJson<BasketOrderResult>();

                    _logger.LogInformation(LogEvent.AntsrouteCreateBasketOrder, "the order has been created successfully");
                    return Result<BasketOrderResult>.Success(result, "the order has been created successfully");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(LogEvent.AntsrouteCreateBasketOrder, ex, "Failed to create order");
                return Result<BasketOrderResult>.Failed(null, ex, "Failed to create order, exception has been thrown");
            }
        }

        public async Task<Result> DeleteOrder(string orderId)
        {
            try
            {
                _logger.LogInformation(
                    LogEvent.AntsrouteDeleteBasketOrder,
                    "Executing [{methodName}] to delete order with given order id [{id}]",
                    nameof(DeleteOrder),
                    orderId);

                using (var client = new HttpClient())
                {
                    _logger.LogDebug(LogEvent.AntsrouteDeleteBasketOrder, "sending request to Antsoute");

                    client.DefaultRequestHeaders.Add("cakey", _antsrouteSecrets.APIKey);
                    var response = await client.DeleteAsync($"{_antsrouteSecrets.GetAndDeleteBasketOrderEndpoint}/{orderId}");

                    if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        _logger.LogError("Failed to delete basket order request response : [{@response}]", response);
                        return Result.Failed(null, "Failed to delete basket order ");
                    }

                    var result = (await response.Content.ReadAsStringAsync())
                            .FromJson<BasketOrderResult>();

                    _logger.LogInformation(LogEvent.AntsrouteCreateBasketOrder, "the basket order has been deleted successfully");
                    return Result.Success("the basket order has been deleted successfully");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(LogEvent.AntsrouteDeleteBasketOrder, ex, "Failed to get basket order");
                return Result.Failed(ex, "Failed to get basket order, exception has been thrown");
            }
        }

        public async Task<Result<BasketOrderResult>> GetOrder(string orderId)
        {
            try
            {
                _logger.LogInformation(
                    LogEvent.AntsrouteGetBasketOrder,
                    "Executing [{methodName}] to get order with given order id [{id}]",
                    nameof(GetOrder),
                    orderId);

                using (var client = new HttpClient())
                {
                    _logger.LogDebug(LogEvent.AntsrouteGetBasketOrder, "sending request to Antsoute");

                    client.DefaultRequestHeaders.Add("cakey", _antsrouteSecrets.APIKey);
                    var response = await client.GetAsync($"{_antsrouteSecrets.GetAndDeleteBasketOrderEndpoint}/{orderId}");

                    if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        _logger.LogError("Failed to get basket order request response : [{@response}]", response);
                        return Result<BasketOrderResult>.Failed(null, null, "Failed to get basket order ");
                    }

                    var result = (await response.Content.ReadAsStringAsync())
                            .FromJson<BasketOrderResult>();

                    _logger.LogInformation(LogEvent.AntsrouteCreateBasketOrder, "the basket order has been got successfully");
                    return Result<BasketOrderResult>.Success(result, "the basket order has been got successfully");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(LogEvent.AntsrouteGetBasketOrder, ex, "Failed to get basket order");
                return Result<BasketOrderResult>.Failed(null, ex, "Failed to get basket order, exception has been thrown");
            }
        }
    }

    public partial class AntsrouteService
    {
        private readonly ILogger<AntsrouteService> _logger;
        private readonly AntsrouteSecrets _antsrouteSecrets;

        public AntsrouteService(
            ILogger<AntsrouteService> logger,
            IOptions<AppSettings> options)
        {
            _logger = logger;
            _antsrouteSecrets = options.Value.AntsrouteSecrets;
        }
    }
}
