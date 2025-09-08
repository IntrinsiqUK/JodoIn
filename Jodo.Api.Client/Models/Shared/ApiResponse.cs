using Newtonsoft.Json;

namespace Jodo.Api.Client.Models.Shared
{
    public class ApiResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
