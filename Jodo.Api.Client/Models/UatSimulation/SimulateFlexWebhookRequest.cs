using System.Text.Json.Serialization;
using System;

namespace Jodo.Api.Client.Models.UatSimulation
{
    public class SimulateFlexWebhookRequest
    {
        [JsonPropertyName("due_date")]
        public DateTime DueDate { get; set; }
    }
}
