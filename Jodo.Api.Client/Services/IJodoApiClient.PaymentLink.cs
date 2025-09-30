using Jodo.Api.Client.Models.PaymentLink;
using Jodo.Api.Client.Models.Shared;
using System.Threading.Tasks;

namespace Jodo.Api.Client.Services
{
    public partial interface IJodoApiClient
    {
        Task<PaymentLinkCreateResponse> CreatePaymentLink(CreatePaymentLinkRequest request);
        Task<PaymentLinkDetails> GetPaymentLinkDetails(string orderId);
        Task CancelPaymentLink(string orderId);
    }
}
