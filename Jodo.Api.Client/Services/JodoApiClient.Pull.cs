using Jodo.Api.Client.Models.Pull;
using System.Threading.Tasks;

namespace Jodo.Api.Client.Services
{
    public partial class JodoApiClient
    {
        public Task<object> InitFlow(InitFlowRequest request)
        {
            return Post<InitFlowRequest, object>("api/v1/integrations/erp/init", request);
        }
    }
}
