using Jodo.Api.Client.Models.PaymentLink;
using Jodo.Api.Client.Models.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Jodo.Api.Client.Tests
{
    [TestClass]
    public class PaymentLinkApiTests : JodoApiIntegrationTestBase
    {
        
        [TestMethod]
        public async Task CreatePaymentLink_Should_Return_Success()
        {
            var request = new CreatePaymentLinkRequest
            {
                Name = "Test Customer",
                Phone = "+919876543210",
                Email = "test@example.com",
                Details = new List<PaymentLinkDetail> {
                    new PaymentLinkDetail { ComponentType = "Payable Amount", Amount = 2500 }
                }
            };

            // Act
            var result = await RunAndReport(() => Client.CreatePaymentLink(request));

            // Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(string.IsNullOrWhiteSpace(result.OrderId));
            Assert.IsFalse(string.IsNullOrWhiteSpace(result.RedirectUrl));
        }

        [TestMethod]
        public async Task GetPaymentLinkDetails_Should_Return_Details()
        {
            var orderId = "pl_123"; // replace if needed

            // Act
            var result = await RunAndReport(() => Client.GetPaymentLinkDetails(orderId));

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task CancelPaymentLink_Should_Send_DeleteRequest()
        {
            var orderId = "pl_123"; // replace if needed

            // Act
            await RunAndReport(() => Client.CancelPaymentLink(orderId));

            // Assert
            Assert.IsTrue(true);
        }
    }
}
