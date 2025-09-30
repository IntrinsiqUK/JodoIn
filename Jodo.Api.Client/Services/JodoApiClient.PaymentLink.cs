using System;
using Jodo.Api.Client.Models.PaymentLink;
using Jodo.Api.Client.Models.Shared;
using System.Threading.Tasks;

namespace Jodo.Api.Client.Services
{
    public partial class JodoApiClient
    {
        public Task<PaymentLinkCreateResponse> CreatePaymentLink(CreatePaymentLinkRequest request)
        {
            ValidateCreatePaymentLinkRequest(request);
            return Post<CreatePaymentLinkRequest, ApiEnvelope<PaymentLinkCreateResponse>>("api/v1/integrations/pay/payment_links", request)
                .ContinueWith(t => t.Result.Data);
        }

        private static void ValidateCreatePaymentLinkRequest(CreatePaymentLinkRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (string.IsNullOrWhiteSpace(request.Name))
            {
                throw new ArgumentException("'name' is required.", nameof(request));
            }

            if (string.IsNullOrWhiteSpace(request.Phone))
            {
                throw new ArgumentException("'phone' is required.", nameof(request));
            }

            if (string.IsNullOrWhiteSpace(request.Email))
            {
                throw new ArgumentException("'email' is required.", nameof(request));
            }

            if (request.Details == null || request.Details.Count == 0)
            {
                throw new ArgumentException("'details' is required and must contain at least one item.", nameof(request));
            }

            for (int i = 0; i < request.Details.Count; i++)
            {
                var detail = request.Details[i];
                if (detail == null)
                {
                    throw new ArgumentException($"details[{i}] must not be null.", nameof(request));
                }
                if (string.IsNullOrWhiteSpace(detail.ComponentType))
                {
                    throw new ArgumentException($"details[{i}].component_type is required.", nameof(request));
                }
                if (detail.Amount <= 0m)
                {
                    throw new ArgumentException($"details[{i}].amount must be greater than 0.", nameof(request));
                }
            }
        }

        public Task<PaymentLinkDetails> GetPaymentLinkDetails(string orderId)
        {
            return GetFromEnvelope<PaymentLinkDetails>($"api/v1/integrations/pay/payment_links/{orderId}");
        }

        public Task CancelPaymentLink(string orderId)
        {
            return Delete($"api/v1/integrations/pay/payment_links/{orderId}");
        }
    }
}
