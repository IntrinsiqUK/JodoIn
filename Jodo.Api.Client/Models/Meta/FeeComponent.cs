using System.Text.Json.Serialization;

namespace Jodo.Api.Client.Models.Meta
{
    public class FeeComponent
    {
        [JsonPropertyName("discount_type")]
        public string DiscountType { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}


