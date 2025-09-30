using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace Jodo.Api.Client.Models.PayOrder
{
    public class CreateOrderRequest
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("details")]
        public List<OrderDetail> Details { get; set; }

        [JsonPropertyName("callback_url")]
        public string CallbackUrl { get; set; }
    }

    public class OrderDetail
    {
        [JsonPropertyName("component_type")]
        public string ComponentType { get; set; }

        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }
    }
}
