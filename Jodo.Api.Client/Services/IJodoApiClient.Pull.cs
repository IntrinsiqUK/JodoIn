using Jodo.Api.Client.Models.Pull;
using System.Threading.Tasks;

namespace Jodo.Api.Client.Services
{
    public partial interface IJodoApiClient
    {
        Task<object> InitFlow(InitFlowRequest request);
    }
}
