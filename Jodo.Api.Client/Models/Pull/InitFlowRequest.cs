using System.Text.Json.Serialization;

namespace Jodo.Api.Client.Models.Pull
{
    public class InitFlowRequest
    {
        [JsonPropertyName("student")]
        public StudentIdentifier Student { get; set; }

        [JsonPropertyName("options")]
        public Options Options { get; set; }
    }

    public class StudentIdentifier
    {
        [JsonPropertyName("identifier")]
        public string Identifier { get; set; }

        [JsonPropertyName("collector_code")]
        public int CollectorCode { get; set; }
    }

    public class Options
    {
        [JsonPropertyName("callback_url")]
        public string CallbackUrl { get; set; }
    }
}
