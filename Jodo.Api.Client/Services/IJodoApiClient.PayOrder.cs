using Jodo.Api.Client.Models.PayOrder;
using Jodo.Api.Client.Models.Shared;
using System.Threading.Tasks;

namespace Jodo.Api.Client.Services
{
    public partial interface IJodoApiClient
    {
        Task<ApiResponse> CreateOrder(CreateOrderRequest request);
        Task<GetOrderDetailsResponse> GetOrderDetails(string orderId);
    }
}
