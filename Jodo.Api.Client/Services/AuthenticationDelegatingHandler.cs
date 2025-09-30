using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Jodo.Api.Client.Internal;

namespace Jodo.Api.Client.Services
{
    public class AuthenticationDelegatingHandler : DelegatingHandler
    {
        private readonly JodoApiOptions _options;

        public AuthenticationDelegatingHandler(JodoApiOptions options)
        {
            _options = options;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var credentials = $"{_options.ApiKey}:{_options.ApiSecret}";
            var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(credentials));

            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", base64Credentials);

            // Trace request
            var reqBody = request.Content != null ? await request.Content.ReadAsStringAsync().ConfigureAwait(false) : null;
            HttpTrace.LogRequest(request.Method + " " + request.RequestUri, reqBody);

            var response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

            // Trace response
            if (response.Content != null)
            {
                var respBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                HttpTrace.LogResponse(((int)response.StatusCode) + " " + response.ReasonPhrase, respBody);
                response.Content = new StringContent(respBody, Encoding.UTF8, response.Content.Headers.ContentType?.MediaType ?? "application/json");
            }

            return response;
        }
    }
}
