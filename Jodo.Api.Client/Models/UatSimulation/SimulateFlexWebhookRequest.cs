using Newtonsoft.Json;
using System;

namespace Jodo.Api.Client.Models.UatSimulation
{
    public class SimulateFlexWebhookRequest
    {
        [JsonProperty("due_date")]
        public DateTime DueDate { get; set; }
    }
}
