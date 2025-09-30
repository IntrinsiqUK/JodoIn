using Moq;
using Moq.Protected;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Jodo.Api.Client.Tests
{
    public class MockHttpMessageHandler
    {
        private readonly Mock<HttpMessageHandler> _mock;
        public HttpRequestMessage? CapturedRequest { get; private set; }

        public MockHttpMessageHandler()
        {
            _mock = new Mock<HttpMessageHandler>();
        }

        public HttpMessageHandler Object => _mock.Object;

        public void SetupSendAsync(HttpStatusCode statusCode, string jsonResponse)
        {
            _mock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .Callback<HttpRequestMessage, CancellationToken>((req, ct) =>
                {
                    CapturedRequest = req;
                })
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = statusCode,
                    Content = new StringContent(jsonResponse)
                })
                .Verifiable();
        }

        public void VerifySendAsync(HttpMethod method, string expectedUri, Times times)
        {
            _mock.Protected().Verify(
                "SendAsync",
                times,
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == method &&
                    req.RequestUri != null && req.RequestUri.ToString().EndsWith(expectedUri)
                ),
                ItExpr.IsAny<CancellationToken>()
            );
        }
    }
}
