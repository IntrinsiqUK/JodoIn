using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace Jodo.Api.Client.Services
{
    public class AuthenticationDelegatingHandler : DelegatingHandler
    {
        private readonly JodoApiOptions _options;

        public AuthenticationDelegatingHandler(IOptions<JodoApiOptions> options)
        {
            _options = options.Value;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var credentials = $"{_options.ApiKey}:{_options.ApiSecret}";
            var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(credentials));

            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", base64Credentials);

            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}
