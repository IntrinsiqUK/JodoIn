using Jodo.Api.Client.Models.Pull;
using Jodo.Api.Client.Models.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Jodo.Api.Client.Tests
{
    [TestClass]
    public class PullApiTests
    {
        [TestMethod]
        public async Task InitFlow_Should_Return_Success()
        {
            // Arrange
            var expectedResponse = new ApiResponse { Success = true };
            var jsonResponse = JsonConvert.SerializeObject(expectedResponse);
            var mockHandler = new MockHttpMessageHandler();
            mockHandler.SetupSendAsync(HttpStatusCode.OK, jsonResponse);
            var client = JodoApiClientTestHelper.CreateClient(mockHandler);

            var request = new InitFlowRequest();

            // Act
            var result = await client.InitFlow(request);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Success);
            mockHandler.VerifySendAsync(HttpMethod.Post, "/api/v1/integrations/erp/init", Times.Once());
        }
    }
}
