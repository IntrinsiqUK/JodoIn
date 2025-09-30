using Jodo.Api.Client.Models.PayOrder;
using Jodo.Api.Client.Models.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Jodo.Api.Client.Tests
{
    [TestClass]
    public class PayOrderApiTests
    {
        [TestMethod]
        public async Task CreateOrder_Should_Return_Success()
        {
            // Arrange
            var expectedResponse = new ApiResponse { Success = true, Message = "Order created" };
            var jsonResponse = JsonSerializer.Serialize(expectedResponse);
            var mockHandler = new MockHttpMessageHandler();
            mockHandler.SetupSendAsync(HttpStatusCode.OK, jsonResponse);
            var client = JodoApiClientTestHelper.CreateClient(mockHandler);

            var request = new CreateOrderRequest
            {
                Name = "Test Customer"
            };

            // Act
            var result = await client.CreateOrder(request);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Success);
            mockHandler.VerifySendAsync(HttpMethod.Post, "/api/v1/integrations/pay/orders", Times.Once());
        }

        [TestMethod]
        public async Task GetOrderDetails_Should_Return_OrderDetails()
        {
            // Arrange
            var expectedResponse = new GetOrderDetailsResponse { OrderId = "ord_123", Status = "created" };
            var jsonResponse = JsonSerializer.Serialize(expectedResponse);
            var mockHandler = new MockHttpMessageHandler();
            mockHandler.SetupSendAsync(HttpStatusCode.OK, jsonResponse);
            var client = JodoApiClientTestHelper.CreateClient(mockHandler);
            var orderId = "ord_123";

            // Act
            var result = await client.GetOrderDetails(orderId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedResponse.OrderId, result.OrderId);
            mockHandler.VerifySendAsync(HttpMethod.Get, $"/api/v1/integrations/pay/orders/{orderId}", Times.Once());
        }
    }
}
