using System.Text.Json.Serialization;

namespace Jodo.Api.Client.Models.User
{
    public class RegisterUserRequest
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }
    }
}
