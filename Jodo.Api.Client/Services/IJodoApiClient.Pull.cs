using Jodo.Api.Client.Models.Pull;
using Jodo.Api.Client.Models.Shared;
using System.Threading.Tasks;

namespace Jodo.Api.Client.Services
{
    public partial interface IJodoApiClient
    {
        Task<ApiResponse> InitFlow(InitFlowRequest request);
    }
}
