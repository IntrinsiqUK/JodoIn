using System.Text.Json.Serialization;

namespace Jodo.Api.Client.Models.PaymentLink
{
    public class PaymentLinkCreateResponse
    {
        [JsonPropertyName("order_id")]
        public string OrderId { get; set; }

        [JsonPropertyName("redirect_url")]
        public string RedirectUrl { get; set; }
    }
}


