using System;
using System.Collections.Generic;
using Jodo.Api.Client.Models.Webhook;
using Jodo.Api.Client.Models.Shared;
using System.Threading.Tasks;

namespace Jodo.Api.Client.Services
{
    public partial class JodoApiClient
    {
        public Task<WebhookItem> AddWebhook(AddWebhookRequest request)
        {
            ValidateAddWebhookRequest(request);
            return Post<AddWebhookRequest, ApiEnvelope<WebhookItem>>("api/v1/integrations/erp/webhooks", request)
                .ContinueWith(t => t.Result.Data);
        }

        private static void ValidateAddWebhookRequest(AddWebhookRequest request)
        {
            if (request == null)
            {
                throw new System.ArgumentNullException(nameof(request));
            }
            // event_code must be a defined enum value
            if (!Enum.IsDefined(typeof(WebhookEventCode), request.EventCode))
            {
                throw new System.ArgumentException("'event_code' is invalid.", nameof(request));
            }
            if (string.IsNullOrWhiteSpace(request.Url))
            {
                throw new System.ArgumentException("'url' is required.", nameof(request));
            }
            if (string.IsNullOrWhiteSpace(request.FailureNotificationEmail))
            {
                throw new System.ArgumentException("'failure_notification_email' is required.", nameof(request));
            }
            // collector_code conditionally required cannot be validated here without context of branches
        }

        public Task DisableWebhook(string webhookId)
        {
            return Delete($"api/v1/integrations/erp/webhooks/{webhookId}");
        }

        public Task<List<WebhookItem>> ListWebhooks()
        {
            return GetFromEnvelope<List<WebhookItem>>("api/v1/integrations/erp/webhooks");
        }

        public Task<WebhookItem> GetWebhook(string webhookId)
        {
            return GetFromEnvelope<WebhookItem>($"api/v1/integrations/erp/webhooks/{webhookId}");
        }
    }
}
