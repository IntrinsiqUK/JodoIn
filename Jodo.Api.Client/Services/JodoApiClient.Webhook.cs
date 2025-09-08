using Jodo.Api.Client.Models.Webhook;
using System.Threading.Tasks;

namespace Jodo.Api.Client.Services
{
    public partial class JodoApiClient
    {
        public Task<object> AddWebhook(AddWebhookRequest request)
        {
            return Post<AddWebhookRequest, object>("api/v1/integrations/erp/webhooks", request);
        }

        public Task DisableWebhook(string webhookId)
        {
            return Delete($"api/v1/integrations/erp/webhooks/{webhookId}");
        }

        public Task<object> ListWebhooks()
        {
            return Get<object>("api/v1/integrations/erp/webhooks");
        }

        public Task<object> GetWebhook(string webhookId)
        {
            return Get<object>($"api/v1/integrations/erp/webhooks/{webhookId}");
        }
    }
}
