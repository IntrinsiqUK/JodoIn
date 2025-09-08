using Jodo.Api.Client.Exceptions;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Jodo.Api.Client.Services
{
    public partial class JodoApiClient : IJodoApiClient
    {
        private readonly HttpClient _httpClient;

        public JodoApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        private async Task<T> Get<T>(string uri)
        {
            var response = await _httpClient.GetAsync(uri).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                return JsonConvert.DeserializeObject<T>(content);
            }

            var errorContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            throw new JodoApiException(response.StatusCode, errorContent);
        }

        private async Task<TResponse> Post<TRequest, TResponse>(string uri, TRequest requestData)
        {
            var json = JsonConvert.SerializeObject(requestData);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(uri, data).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                return JsonConvert.DeserializeObject<TResponse>(content);
            }

            var errorContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            throw new JodoApiException(response.StatusCode, errorContent);
        }

        private async Task<TResponse> Patch<TRequest, TResponse>(string uri, TRequest requestData)
        {
            var method = new HttpMethod("PATCH");
            var json = JsonConvert.SerializeObject(requestData);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(method, uri) { Content = data };

            var response = await _httpClient.SendAsync(request).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                return JsonConvert.DeserializeObject<TResponse>(content);
            }

            var errorContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            throw new JodoApiException(response.StatusCode, errorContent);
        }

        private async Task Delete(string uri)
        {
            var response = await _httpClient.DeleteAsync(uri).ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                throw new JodoApiException(response.StatusCode, errorContent);
            }
        }
    }
}
