using Newtonsoft.Json;

namespace Jodo.Api.Client.Models.User
{
    public class RegisterUserRequest
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
