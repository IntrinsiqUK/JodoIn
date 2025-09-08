using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Jodo.Api.Client.Tests
{
    [TestClass]
    public class MetaApiTests
    {
        [TestMethod]
        public async Task ListBranches_Should_Return_ListOfBranches()
        {
            // Arrange
            var expectedResponse = new List<object> { new { id = 1, name = "Main Branch" } };
            var jsonResponse = JsonConvert.SerializeObject(expectedResponse);
            var mockHandler = new MockHttpMessageHandler();
            mockHandler.SetupSendAsync(HttpStatusCode.OK, jsonResponse);
            var client = JodoApiClientTestHelper.CreateClient(mockHandler);

            // Act
            var result = await client.ListBranches();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            mockHandler.VerifySendAsync(HttpMethod.Get, "/api/v1/integrations/erp/branches", Times.Once());
        }

        [TestMethod]
        public async Task ListGrades_Should_Return_ListOfGrades()
        {
            // Arrange
            var expectedResponse = new List<object> { new { id = "g1", name = "Grade 1" } };
            var jsonResponse = JsonConvert.SerializeObject(expectedResponse);
            var mockHandler = new MockHttpMessageHandler();
            mockHandler.SetupSendAsync(HttpStatusCode.OK, jsonResponse);
            var client = JodoApiClientTestHelper.CreateClient(mockHandler);

            // Act
            var result = await client.ListGrades();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            mockHandler.VerifySendAsync(HttpMethod.Get, "/api/v1/integrations/erp/grades", Times.Once());
        }

        [TestMethod]
        public async Task ListDiscounts_Should_Return_ListOfDiscounts()
        {
            // Arrange
            var expectedResponse = new List<object> { new { id = "d1", name = "Discount 1" } };
            var jsonResponse = JsonConvert.SerializeObject(expectedResponse);
            var mockHandler = new MockHttpMessageHandler();
            mockHandler.SetupSendAsync(HttpStatusCode.OK, jsonResponse);
            var client = JodoApiClientTestHelper.CreateClient(mockHandler);

            // Act
            var result = await client.ListDiscounts("some_code");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            mockHandler.VerifySendAsync(HttpMethod.Get, "/api/v1/integrations/erp/discounts?collector_code=some_code", Times.Once());
        }
    }
}
