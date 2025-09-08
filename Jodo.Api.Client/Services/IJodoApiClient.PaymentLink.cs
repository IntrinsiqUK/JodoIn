using Jodo.Api.Client.Models.PaymentLink;
using System.Threading.Tasks;

namespace Jodo.Api.Client.Services
{
    public partial interface IJodoApiClient
    {
        Task<object> CreatePaymentLink(CreatePaymentLinkRequest request);
        Task<object> GetPaymentLinkDetails(string orderId);
        Task CancelPaymentLink(string orderId);
    }
}
