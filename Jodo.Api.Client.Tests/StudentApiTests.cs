using Jodo.Api.Client.Models.Student;
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
    public class StudentApiTests
    {
        [TestMethod]
        public async Task RegisterStudent_Should_Return_JodoStudentId()
        {
            // Arrange
            var expectedResponse = new RegisterStudentResponse { JodoStudentId = "stud_123" };
            var jsonResponse = JsonSerializer.Serialize(expectedResponse);
            var mockHandler = new MockHttpMessageHandler();
            mockHandler.SetupSendAsync(HttpStatusCode.OK, jsonResponse);
            var client = JodoApiClientTestHelper.CreateClient(mockHandler);
            var registrationId = "reg_123";
            var request = new RegisterStudentRequest();

            // Act
            var result = await client.RegisterStudent(registrationId, request);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedResponse.JodoStudentId, result.JodoStudentId);
            mockHandler.VerifySendAsync(HttpMethod.Post, $"/api/v1/integrations/erp/users/{registrationId}/students", Times.Once());
        }

        [TestMethod]
        public async Task UpdateStudent_Should_Send_PatchRequest()
        {
            // Arrange
            var expectedResponse = new ApiResponse { Success = true };
            var jsonResponse = JsonSerializer.Serialize(expectedResponse);
            var mockHandler = new MockHttpMessageHandler();
            mockHandler.SetupSendAsync(HttpStatusCode.OK, jsonResponse);
            var client = JodoApiClientTestHelper.CreateClient(mockHandler);
            var jodoStudentId = "stud_123";
            var request = new UpdateStudentRequest { Fullname = "Updated Name" };

            // Act
            var result = await client.UpdateStudent(jodoStudentId, request);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Success);
            mockHandler.VerifySendAsync(new HttpMethod("PATCH"), $"/api/v1/integrations/erp/students/{jodoStudentId}", Times.Once());
        }

        [TestMethod]
        public async Task GetStudentDetails_Should_Return_StudentDetails()
        {
            // Arrange
            var expectedResponse = new GetStudentDetailsResponse { JodoStudentId = "stud_123", Fullname = "Test Student" };
            var jsonResponse = JsonSerializer.Serialize(expectedResponse);
            var mockHandler = new MockHttpMessageHandler();
            mockHandler.SetupSendAsync(HttpStatusCode.OK, jsonResponse);
            var client = JodoApiClientTestHelper.CreateClient(mockHandler);
            var jodoStudentId = "stud_123";

            // Act
            var result = await client.GetStudentDetails(jodoStudentId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedResponse.JodoStudentId, result.JodoStudentId);
            mockHandler.VerifySendAsync(HttpMethod.Get, $"/api/v1/integrations/erp/students/{jodoStudentId}", Times.Once());
        }

        [TestMethod]
        public async Task CancelPayment_Should_Send_DeleteRequest()
        {
            // Arrange
            var mockHandler = new MockHttpMessageHandler();
            mockHandler.SetupSendAsync(HttpStatusCode.OK, "");
            var client = JodoApiClientTestHelper.CreateClient(mockHandler);
            var jodoStudentId = "stud_123";
            var transactionId = "txn_123";

            // Act
            await client.CancelPayment(jodoStudentId, transactionId);

            // Assert
            mockHandler.VerifySendAsync(HttpMethod.Delete, $"/api/v1/integrations/erp/students/{jodoStudentId}/payments/{transactionId}", Times.Once());
        }

        [TestMethod]
        public async Task UpdateStudentFee_Should_Send_PatchRequest()
        {
            // Arrange
            var mockHandler = new MockHttpMessageHandler();
            mockHandler.SetupSendAsync(HttpStatusCode.OK, "{\"success\":true}");
            var client = JodoApiClientTestHelper.CreateClient(mockHandler);
            var jodoStudentId = "stud_123";
            var request = new UpdateStudentFeeRequest();

            // Act
            await client.UpdateStudentFee(jodoStudentId, request);

            // Assert
            mockHandler.VerifySendAsync(new HttpMethod("PATCH"), $"/api/v1/integrations/erp/students/{jodoStudentId}/fee", Times.Once());
        }

        [TestMethod]
        public async Task PostPayment_Should_Send_PostRequest()
        {
            // Arrange
            var mockHandler = new MockHttpMessageHandler();
            mockHandler.SetupSendAsync(HttpStatusCode.OK, "{\"success\":true}");
            var client = JodoApiClientTestHelper.CreateClient(mockHandler);
            var jodoStudentId = "stud_123";
            var request = new PostPaymentRequest();

            // Act
            await client.PostPayment(jodoStudentId, request);

            // Assert
            mockHandler.VerifySendAsync(HttpMethod.Post, $"/api/v1/integrations/erp/students/{jodoStudentId}/payments", Times.Once());
        }

        [TestMethod]
        public async Task ListStudentPayments_Should_Return_List()
        {
            // Arrange
            var mockHandler = new MockHttpMessageHandler();
            mockHandler.SetupSendAsync(HttpStatusCode.OK, "[{\"id\":\"p1\"}]");
            var client = JodoApiClientTestHelper.CreateClient(mockHandler);
            var jodoStudentId = "stud_123";

            // Act
            var result = await client.ListStudentPayments(jodoStudentId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            mockHandler.VerifySendAsync(HttpMethod.Get, $"/api/v1/integrations/erp/students/{jodoStudentId}/payments", Times.Once());
        }
    }
}
