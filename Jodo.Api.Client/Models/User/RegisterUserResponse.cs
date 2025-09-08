using Newtonsoft.Json;

namespace Jodo.Api.Client.Models.User
{
    public class RegisterUserResponse
    {
        [JsonProperty("registration_id")]
        public string RegistrationId { get; set; }
    }
}
