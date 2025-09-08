using Jodo.Api.Client.Services;
using System.Net.Http;

namespace Jodo.Api.Client.Tests
{
    public static class JodoApiClientTestHelper
    {
        public static JodoApiClient CreateClient(MockHttpMessageHandler mockHandler)
        {
            var httpClient = new HttpClient(mockHandler.Object)
            {
                BaseAddress = new System.Uri("http://localhost") // Base address is required but won't be used
            };
            return new JodoApiClient(httpClient);
        }
    }
}
