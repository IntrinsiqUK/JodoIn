using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace Jodo.Api.Client.Models.PayOrder
{
    public class GetOrderDetailsResponse
    {
        [JsonPropertyName("order_id")]
        public string OrderId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("details")]
        public List<OrderDetail> Details { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }
    }
}
