using System.Text.Json.Serialization;

namespace Jodo.Api.Client.Models.Shared
{
    public class ApiResponse
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}
