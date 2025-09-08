using Jodo.Api.Client.Models.User;
using System.Threading.Tasks;

namespace Jodo.Api.Client.Services
{
    public partial interface IJodoApiClient
    {
        Task<RegisterUserResponse> RegisterUser(RegisterUserRequest request);
        Task<GetAccessTokenResponse> GetAccessToken(string registrationId);
    }
}
