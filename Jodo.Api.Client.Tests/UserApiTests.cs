using Jodo.Api.Client.Models.User;
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
    public class UserApiTests
    {
        [TestMethod]
        public async Task RegisterUser_Should_Return_RegistrationId_And_Send_Correct_Body()
        {
            // Arrange
            var expectedResponse = new RegisterUserResponse { RegistrationId = "12345" };
            var jsonResponse = JsonSerializer.Serialize(expectedResponse);
            var mockHandler = new MockHttpMessageHandler();
            mockHandler.SetupSendAsync(HttpStatusCode.OK, jsonResponse);
            var client = JodoApiClientTestHelper.CreateClient(mockHandler);

            var request = new RegisterUserRequest
            {
                Name = "Test User",
                Email = "test@example.com",
                Phone = "1234567890"
            };

            // Act
            var result = await client.RegisterUser(request);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedResponse.RegistrationId, result.RegistrationId);

            mockHandler.VerifySendAsync(HttpMethod.Post, "/api/v1/integrations/erp/users/register", Times.Once());

            Assert.IsNotNull(mockHandler.CapturedRequest?.Content);
            var capturedBody = await mockHandler.CapturedRequest.Content.ReadAsStringAsync();
            var sentRequest = JsonSerializer.Deserialize<RegisterUserRequest>(capturedBody);
            Assert.IsNotNull(sentRequest);
            Assert.AreEqual(request.Name, sentRequest!.Name);
            Assert.AreEqual(request.Email, sentRequest!.Email);
        }

        [TestMethod]
        public async Task GetAccessToken_Should_Return_AccessToken()
        {
            // Arrange
            var expectedResponse = new GetAccessTokenResponse { AccessToken = "test_token" };
            var jsonResponse = JsonSerializer.Serialize(expectedResponse);
            var mockHandler = new MockHttpMessageHandler();
            mockHandler.SetupSendAsync(HttpStatusCode.OK, jsonResponse);
            var client = JodoApiClientTestHelper.CreateClient(mockHandler);
            var registrationId = "12345";

            // Act
            var result = await client.GetAccessToken(registrationId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedResponse.AccessToken, result.AccessToken);

            mockHandler.VerifySendAsync(HttpMethod.Get, $"/api/v1/integrations/erp/users/{registrationId}/access_token", Times.Once());
        }

        [TestMethod]
        public async Task RegisterUser_WhenApiReturnsError_Should_ThrowJodoApiException()
        {
            // Arrange
            var mockHandler = new MockHttpMessageHandler();
            mockHandler.SetupSendAsync(HttpStatusCode.BadRequest, "{\"error\":\"Invalid request\"}");
            var client = JodoApiClientTestHelper.CreateClient(mockHandler);
            var request = new RegisterUserRequest();

            // Act & Assert
            await Assert.ThrowsExceptionAsync<Jodo.Api.Client.Exceptions.JodoApiException>(() => client.RegisterUser(request));
        }
    }
}
