using Jodo.Api.Client.Models.Shared;
using Jodo.Api.Client.Models.Webhook;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Jodo.Api.Client.Tests
{
    [TestClass]
    public class WebhookApiTests
    {
        [TestMethod]
        public async Task AddWebhook_Should_Return_Success()
        {
            // Arrange
            var expectedResponse = new ApiResponse { Success = true };
            var jsonResponse = JsonConvert.SerializeObject(expectedResponse);
            var mockHandler = new MockHttpMessageHandler();
            mockHandler.SetupSendAsync(HttpStatusCode.OK, jsonResponse);
            var client = JodoApiClientTestHelper.CreateClient(mockHandler);

            var request = new AddWebhookRequest
            {
                Url = "https://example.com/webhook",
                EventCode = "test.event"
            };

            // Act
            var result = await client.AddWebhook(request);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Success);
            mockHandler.VerifySendAsync(HttpMethod.Post, "/api/v1/integrations/erp/webhooks", Times.Once());
        }
    }
}
