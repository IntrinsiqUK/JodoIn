using Jodo.Api.Client.Models.UatSimulation;
using System.Threading.Tasks;

namespace Jodo.Api.Client.Services
{
    public partial interface IJodoApiClient
    {
        Task SimulateFlexInstalmentDebited(string jodoStudentId, SimulateFlexWebhookRequest request);
        Task SimulateFlexInstalmentSettled(string jodoStudentId, SimulateFlexWebhookRequest request);
        Task SimulateFlexInstalmentBounced(string jodoStudentId, SimulateFlexWebhookRequest request);
    }
}
