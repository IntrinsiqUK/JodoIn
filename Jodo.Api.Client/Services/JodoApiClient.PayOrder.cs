using Jodo.Api.Client.Models.PayOrder;
using Jodo.Api.Client.Models.Shared;
using System.Threading.Tasks;

namespace Jodo.Api.Client.Services
{
    public partial class JodoApiClient
    {
        public Task<ApiResponse> CreateOrder(CreateOrderRequest request)
        {
            return Post<CreateOrderRequest, ApiResponse>("api/v1/integrations/pay/orders", request);
        }

        public Task<GetOrderDetailsResponse> GetOrderDetails(string orderId)
        {
            return Get<GetOrderDetailsResponse>($"api/v1/integrations/pay/orders/{orderId}");
        }
    }
}
