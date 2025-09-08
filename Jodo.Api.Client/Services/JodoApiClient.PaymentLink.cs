using Jodo.Api.Client.Models.PaymentLink;
using System.Threading.Tasks;

namespace Jodo.Api.Client.Services
{
    public partial class JodoApiClient
    {
        public Task<object> CreatePaymentLink(CreatePaymentLinkRequest request)
        {
            return Post<CreatePaymentLinkRequest, object>("api/v1/integrations/pay/payment_links", request);
        }

        public Task<object> GetPaymentLinkDetails(string orderId)
        {
            return Get<object>($"api/v1/integrations/pay/payment_links/{orderId}");
        }

        public Task CancelPaymentLink(string orderId)
        {
            return Delete($"api/v1/integrations/pay/payment_links/{orderId}");
        }
    }
}
