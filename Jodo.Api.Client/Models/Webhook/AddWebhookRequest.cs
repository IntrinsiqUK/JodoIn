using Newtonsoft.Json;

namespace Jodo.Api.Client.Models.Webhook
{
    public class AddWebhookRequest
    {
        [JsonProperty("event_code")]
        public string EventCode { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("failure_notification_email")]
        public string FailureNotificationEmail { get; set; }
    }
}
