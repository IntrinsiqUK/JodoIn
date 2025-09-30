using Jodo.Api.Client.Models.Pull;
using Jodo.Api.Client.Models.Shared;
using System.Threading.Tasks;

namespace Jodo.Api.Client.Services
{
    public partial class JodoApiClient
    {
        public Task<ApiResponse> InitFlow(InitFlowRequest request)
        {
            return Post<InitFlowRequest, ApiResponse>("api/v1/integrations/erp/init", request);
        }
    }
}
