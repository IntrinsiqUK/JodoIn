using System.Text.Json.Serialization;

namespace Jodo.Api.Client.Models.Meta
{
    public class Grade
    {
        [JsonPropertyName("component_type")]
        public string ComponentType { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}


