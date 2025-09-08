using Jodo.Api.Client.Models.PaymentLink;
using Jodo.Api.Client.Models.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Jodo.Api.Client.Tests
{
    [TestClass]
    public class PaymentLinkApiTests
    {
        [TestMethod]
        public async Task CreatePaymentLink_Should_Return_Success()
        {
            // Arrange
            var expectedResponse = new ApiResponse { Success = true, Message = "Payment link created" };
            var jsonResponse = JsonConvert.SerializeObject(expectedResponse);
            var mockHandler = MockHttpMessageHandler.Create(HttpStatusCode.OK, jsonResponse);
            var client = JodoApiClientTestHelper.CreateClient(mockHandler);

            var request = new CreatePaymentLinkRequest
            {
                Name = "Test Customer"
            };

            // Act
            var result = await client.CreatePaymentLink(request);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Success);

            mockHandler.Protected().Verify(
                "SendAsync",
                Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Post &&
                    req.RequestUri.ToString().EndsWith("/api/v1/integrations/pay/payment_links")
                ),
                ItExpr.IsAny<CancellationToken>()
            );
        }

        [TestMethod]
        public async Task GetPaymentLinkDetails_Should_Return_Details()
        {
            // Arrange
            var mockHandler = new MockHttpMessageHandler();
            mockHandler.SetupSendAsync(HttpStatusCode.OK, "{\"order_id\":\"pl_123\"}");
            var client = JodoApiClientTestHelper.CreateClient(mockHandler);
            var orderId = "pl_123";

            // Act
            var result = await client.GetPaymentLinkDetails(orderId);

            // Assert
            Assert.IsNotNull(result);
            mockHandler.VerifySendAsync(HttpMethod.Get, $"/api/v1/integrations/pay/payment_links/{orderId}", Times.Once());
        }

        [TestMethod]
        public async Task CancelPaymentLink_Should_Send_DeleteRequest()
        {
            // Arrange
            var mockHandler = new MockHttpMessageHandler();
            mockHandler.SetupSendAsync(HttpStatusCode.OK, "");
            var client = JodoApiClientTestHelper.CreateClient(mockHandler);
            var orderId = "pl_123";

            // Act
            await client.CancelPaymentLink(orderId);

            // Assert
            mockHandler.VerifySendAsync(HttpMethod.Delete, $"/api/v1/integrations/pay/payment_links/{orderId}", Times.Once());
        }
    }
}
