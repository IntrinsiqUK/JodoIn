using Jodo.Api.Client.Models.User;
using System.Threading.Tasks;

namespace Jodo.Api.Client.Services
{
    public partial class JodoApiClient
    {
        public Task<RegisterUserResponse> RegisterUser(RegisterUserRequest request)
        {
            return Post<RegisterUserRequest, RegisterUserResponse>("api/v1/integrations/erp/users/register", request);
        }

        public Task<GetAccessTokenResponse> GetAccessToken(string registrationId)
        {
            return Get<GetAccessTokenResponse>($"api/v1/integrations/erp/users/{registrationId}/access_token");
        }
    }
}
