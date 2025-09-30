using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jodo.Api.Client.Models.Meta;

namespace Jodo.Api.Client.Tests
{
    [TestClass]
    public class MetaApiTests : JodoApiIntegrationTestBase
    {
        [TestMethod]
        public async Task ListBranches_Should_Return_ListOfBranches()
        {
            // Act
            var result = await RunAndReport(() => Client.ListBranches());

            // Assert
            Assert.IsNotNull(result);           // Validate that we have a response
            Assert.IsTrue(result.Count >= 1);   // Validate that we have at least one branch
            Assert.IsFalse(string.IsNullOrWhiteSpace(result[0].Name)); // Validate that the first branch has a name
        }

        [TestMethod]
        public async Task ListGrades_Should_Return_ListOfGrades()
        {
            // Act
            var result = await RunAndReport(() => Client.ListGrades());

            // Assert
            Assert.IsNotNull(result);           // Validate that we have a response
            
            // This test doesn't currently check for grades as the system may not have any setup.
        }

        [TestMethod]
        public async Task ListDiscounts_Should_Return_ListOfDiscounts()
        {
            // Act
            var result = await RunAndReport(() => Client.ListDiscounts("some_code"));

            // Assert
            Assert.IsNotNull(result);

            // This test doesn't currently check for discounts as the system may not have any setup.
        }

        [TestMethod]
        public async Task ListFeeComponents_Should_Return_List()
        {
            // Act
            var result = await RunAndReport(() => Client.ListFeeComponents("some_code"));

            // Assert
            Assert.IsNotNull(result);

            // This test doesn't currently check for fee components as the system may not have any setup.
        }
    }
}
