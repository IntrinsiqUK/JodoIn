using Newtonsoft.Json;
using System.Collections.Generic;

namespace Jodo.Api.Client.Models.PayOrder
{
    public class CreateOrderRequest
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("details")]
        public List<OrderDetail> Details { get; set; }

        [JsonProperty("callback_url")]
        public string CallbackUrl { get; set; }
    }

    public class OrderDetail
    {
        [JsonProperty("component_type")]
        public string ComponentType { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }
    }
}
