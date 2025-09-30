using System.Text.Json.Serialization;

namespace Jodo.Api.Client.Models.Shared
{
    public class ApiEnvelope<T>
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("data")]
        public T Data { get; set; }

        [JsonPropertyName("request_id")]
        public string RequestId { get; set; }
    }
}


