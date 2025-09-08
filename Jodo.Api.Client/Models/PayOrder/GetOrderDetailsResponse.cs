using Newtonsoft.Json;
using System.Collections.Generic;

namespace Jodo.Api.Client.Models.PayOrder
{
    public class GetOrderDetailsResponse
    {
        [JsonProperty("order_id")]
        public string OrderId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("details")]
        public List<OrderDetail> Details { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
