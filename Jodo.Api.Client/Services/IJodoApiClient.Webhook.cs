using Jodo.Api.Client.Models.Webhook;
using Jodo.Api.Client.Models.Shared;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Jodo.Api.Client.Services
{
    public partial interface IJodoApiClient
    {
        Task<WebhookItem> AddWebhook(AddWebhookRequest request);
        Task DisableWebhook(string webhookId);
        Task<List<WebhookItem>> ListWebhooks();
        Task<WebhookItem> GetWebhook(string webhookId);
    }
}
