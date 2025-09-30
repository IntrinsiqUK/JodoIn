using System.Text.Json.Serialization;

namespace Jodo.Api.Client.Models.User
{
    public class RegisterUserResponse
    {
        [JsonPropertyName("registration_id")]
        public string RegistrationId { get; set; }
    }
}
