using Newtonsoft.Json;

namespace Jodo.Api.Client.Models.User
{
    public class GetAccessTokenResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
    }
}
