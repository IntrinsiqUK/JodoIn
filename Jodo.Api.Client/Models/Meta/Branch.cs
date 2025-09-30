using System.Text.Json.Serialization;

namespace Jodo.Api.Client.Models.Meta
{
    public class Branch
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("stream")]
        public BranchStream Stream { get; set; }
    }

    public class BranchStream
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}


