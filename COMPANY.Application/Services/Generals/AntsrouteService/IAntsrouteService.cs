namespace COMPANY.Application.Services.Generals.AntsrouteService
{
    using COMPANY.Application.DataInteraction.Generals;
    using COMPANY.Application.Models.Generals.Antsroute;
    using System.Threading.Tasks;

    public interface IAntsrouteService
    {
        Task<Result<BasketOrderResult>> CreateOrder(BasketOrderCreateModel order);
        Task<Result<BasketOrderResult>> GetOrder(string orderId);
        Task<Result> DeleteOrder(string orderId);
    }
}