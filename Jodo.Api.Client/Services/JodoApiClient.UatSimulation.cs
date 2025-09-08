using Jodo.Api.Client.Models.UatSimulation;
using System.Threading.Tasks;

namespace Jodo.Api.Client.Services
{
    public partial class JodoApiClient
    {
        public Task SimulateFlexInstalmentDebited(string jodoStudentId, SimulateFlexWebhookRequest request)
        {
            return Post<SimulateFlexWebhookRequest, object>($"api/v1/integrations/flex/students/{jodoStudentId}/simulate/flex.instalment.debited", request);
        }

        public Task SimulateFlexInstalmentSettled(string jodoStudentId, SimulateFlexWebhookRequest request)
        {
            return Post<SimulateFlexWebhookRequest, object>($"api/v1/integrations/flex/students/{jodoStudentId}/simulate/flex.instalment.settled", request);
        }

        public Task SimulateFlexInstalmentBounced(string jodoStudentId, SimulateFlexWebhookRequest request)
        {
            return Post<SimulateFlexWebhookRequest, object>($"api/v1/integrations/flex/students/{jodoStudentId}/simulate/flex.instalment.bounced", request);
        }
    }
}
