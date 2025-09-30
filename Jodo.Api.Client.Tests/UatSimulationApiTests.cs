using Jodo.Api.Client.Models.Shared;
using Jodo.Api.Client.Models.UatSimulation;
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
    public class UatSimulationApiTests
    {
        [TestMethod]
        public async Task SimulateFlexInstalmentDebited_Should_Return_Success()
        {
            // Arrange
            var expectedResponse = new ApiResponse { Success = true };
            var jsonResponse = JsonSerializer.Serialize(expectedResponse);
            var mockHandler = new MockHttpMessageHandler();
            mockHandler.SetupSendAsync(HttpStatusCode.OK, jsonResponse);
            var client = JodoApiClientTestHelper.CreateClient(mockHandler);
            var jodoStudentId = "stud_123";
            var request = new SimulateFlexWebhookRequest();

            // Act
            await client.SimulateFlexInstalmentDebited(jodoStudentId, request);

            // Assert
            mockHandler.VerifySendAsync(HttpMethod.Post, $"/api/v1/integrations/flex/students/{jodoStudentId}/simulate/flex.instalment.debited", Times.Once());
        }
    }
}
