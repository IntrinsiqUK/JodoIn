using System.Text.Json.Serialization;

namespace Jodo.Api.Client.Models.Webhook
{
    /// <summary>
    /// Represents a configured webhook returned by the API.
    /// </summary>
    public class WebhookItem
    {
        /// <summary>Webhook ID.</summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>Configured webhook URL.</summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }

        /// <summary>Webhook event code.</summary>
        [JsonPropertyName("event_code")]
        public WebhookEventCode EventCode { get; set; }

        /// <summary>Comma separated notification emails.</summary>
        [JsonPropertyName("failure_notification_email")]
        public string FailureNotificationEmail { get; set; }
    }
}


