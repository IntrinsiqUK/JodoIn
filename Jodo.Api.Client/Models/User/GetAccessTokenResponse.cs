using System.Text.Json.Serialization;

namespace Jodo.Api.Client.Models.User
{
    public class GetAccessTokenResponse
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }
    }
}
