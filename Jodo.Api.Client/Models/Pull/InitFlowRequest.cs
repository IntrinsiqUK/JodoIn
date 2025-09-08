using Newtonsoft.Json;

namespace Jodo.Api.Client.Models.Pull
{
    public class InitFlowRequest
    {
        [JsonProperty("student")]
        public StudentIdentifier Student { get; set; }

        [JsonProperty("options")]
        public Options Options { get; set; }
    }

    public class StudentIdentifier
    {
        [JsonProperty("identifier")]
        public string Identifier { get; set; }

        [JsonProperty("collector_code")]
        public int CollectorCode { get; set; }
    }

    public class Options
    {
        [JsonProperty("callback_url")]
        public string CallbackUrl { get; set; }
    }
}
