using Jodo.Api.Client.Models.Webhook;
using System.Threading.Tasks;

namespace Jodo.Api.Client.Services
{
    public partial interface IJodoApiClient
    {
        Task<object> AddWebhook(AddWebhookRequest request);
        Task DisableWebhook(string webhookId);
        Task<object> ListWebhooks();
        Task<object> GetWebhook(string webhookId);
    }
}
