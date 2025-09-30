using System.Text.Json.Serialization;

namespace Jodo.Api.Client.Models.Webhook
{
    /// <summary>
    /// Request payload to register a webhook endpoint.
    /// </summary>
    /// <remarks>
    /// Required: event_code, url, failure_notification_email.
    /// collector_code is required if the institute has more than one branch.
    /// Optional: secret_key, header_key, header_value.
    /// </remarks>
    public class AddWebhookRequest
    {
        /// <summary>Branch code. Required if the institute has more than one branch.</summary>
        [JsonPropertyName("collector_code")]
        public string CollectorCode { get; set; }

        /// <summary>Webhook event code. Required.</summary>
        [JsonPropertyName("event_code")]
        public WebhookEventCode EventCode { get; set; }

        /// <summary>URL to send POST request when the event is triggered. Required.</summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }

        /// <summary>Comma separated email list to receive notification in case of failure. Required.</summary>
        [JsonPropertyName("failure_notification_email")]
        public string FailureNotificationEmail { get; set; }

        /// <summary>Secret key to be used for generating signature. Optional.</summary>
        [JsonPropertyName("secret_key")]
        public string SecretKey { get; set; }

        /// <summary>Custom header key. Optional.</summary>
        [JsonPropertyName("header_key")]
        public string HeaderKey { get; set; }

        /// <summary>Custom header value. Optional.</summary>
        [JsonPropertyName("header_value")]
        public string HeaderValue { get; set; }
    }
}
