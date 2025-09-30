using Jodo.Api.Client.Models.Shared;
using Jodo.Api.Client.Models.Webhook;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Jodo.Api.Client.Tests
{
    [TestClass]
    public class WebhookApiTests : JodoApiIntegrationTestBase
    {
        [TestMethod]
        public async Task Webhook_List_Disable_Add_Then_List_Should_Work()
        {
            var testUrl = "https://example.com/webhook-test";
            var eventCode = Jodo.Api.Client.Models.Webhook.WebhookEventCode.PayPaymentDebited;
            var failureEmails = "you@example.com";

            // list existing
            var list1 = await RunAndReport(() => Client.ListWebhooks());
            Assert.IsNotNull(list1);

            // if exists, disable it
            var existing = list1.Find(w => w.Url == testUrl && w.EventCode == eventCode);
            if (existing != null)
            {
                await RunAndReport(() => Client.DisableWebhook(existing.Id));
            }

            // add webhook
            var addResponse = await RunAndReport(() => Client.AddWebhook(new AddWebhookRequest { Url = testUrl, EventCode = eventCode, FailureNotificationEmail = failureEmails }));
            Assert.IsNotNull(addResponse);
            Assert.IsFalse(string.IsNullOrWhiteSpace(addResponse.Id));
            Assert.AreEqual(testUrl, addResponse.Url);
            Assert.AreEqual(eventCode, addResponse.EventCode);

            // list again and assert present
            var list2 = await RunAndReport(() => Client.ListWebhooks());
            Assert.IsTrue(list2.Exists(w => w.Url == testUrl && w.EventCode == eventCode));
        }
    }
}
