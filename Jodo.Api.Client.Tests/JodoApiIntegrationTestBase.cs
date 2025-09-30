using Jodo.Api.Client;
using Jodo.Api.Client.Extensions;
using Jodo.Api.Client.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jodo.Api.Client.Tests
{
    public abstract class JodoApiIntegrationTestBase
    {
        protected IJodoApiClient Client { get; private set; }

        [TestInitialize]
        public void InitializeClient()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .AddJsonFile("appsettings.Development.json", optional: true)
                .AddUserSecrets(typeof(JodoApiIntegrationTestBase).Assembly, optional: true)
                .AddEnvironmentVariables(prefix: "JODO_")
                .Build();

            var services = new ServiceCollection();

            services.Configure<JodoApiOptions>(config.GetSection("JodoApi"));
            services.AddJodoApiClient(config);

            var provider = services.BuildServiceProvider();
            Client = provider.GetRequiredService<IJodoApiClient>();

            // Subscribe to HTTP trace events to capture back-and-forth
            Jodo.Api.Client.Internal.HttpTrace.RequestLogged += (line, body) =>
            {
                TestHttpTrace.LastRequest = line;
                TestHttpTrace.LastRequestBody = body;
                System.Console.Error.WriteLine("REQUEST: " + line);
                if (!string.IsNullOrEmpty(body)) System.Console.Error.WriteLine("REQUEST BODY: " + body);
            };
            Jodo.Api.Client.Internal.HttpTrace.ResponseLogged += (status, body) =>
            {
                TestHttpTrace.LastResponseStatus = status;
                TestHttpTrace.LastResponseBody = body;
                System.Console.Error.WriteLine("RESPONSE: " + status);
                if (!string.IsNullOrEmpty(body)) System.Console.Error.WriteLine("RESPONSE BODY: " + body);
            };
        }

        protected async System.Threading.Tasks.Task<T> RunAndReport<T>(System.Func<System.Threading.Tasks.Task<T>> action)
        {
            try
            {
                return await action().ConfigureAwait(false);
            }
            catch (Jodo.Api.Client.Exceptions.JodoApiException ex)
            {
                System.Console.Error.WriteLine("REQUEST: " + TestHttpTrace.LastRequest);
                System.Console.Error.WriteLine("REQUEST BODY: " + TestHttpTrace.LastRequestBody);
                System.Console.Error.WriteLine("RESPONSE: " + TestHttpTrace.LastResponseStatus);
                System.Console.Error.WriteLine("RESPONSE BODY: " + TestHttpTrace.LastResponseBody);
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail($"API call failed: {ex.Message}\nREQUEST: {TestHttpTrace.LastRequest}\nREQUEST BODY: {TestHttpTrace.LastRequestBody}\nRESPONSE: {TestHttpTrace.LastResponseStatus}\nRESPONSE BODY: {TestHttpTrace.LastResponseBody}");
                throw;
            }
            catch (System.Exception ex)
            {
                System.Console.Error.WriteLine("REQUEST: " + TestHttpTrace.LastRequest);
                System.Console.Error.WriteLine("REQUEST BODY: " + TestHttpTrace.LastRequestBody);
                System.Console.Error.WriteLine("RESPONSE: " + TestHttpTrace.LastResponseStatus);
                System.Console.Error.WriteLine("RESPONSE BODY: " + TestHttpTrace.LastResponseBody);
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail($"Unexpected error: {ex}\nREQUEST: {TestHttpTrace.LastRequest}\nREQUEST BODY: {TestHttpTrace.LastRequestBody}\nRESPONSE: {TestHttpTrace.LastResponseStatus}\nRESPONSE BODY: {TestHttpTrace.LastResponseBody}");
                throw;
            }
        }

        protected async System.Threading.Tasks.Task RunAndReport(System.Func<System.Threading.Tasks.Task> action)
        {
            try
            {
                await action().ConfigureAwait(false);
            }
            catch (Jodo.Api.Client.Exceptions.JodoApiException ex)
            {
                System.Console.Error.WriteLine("REQUEST: " + TestHttpTrace.LastRequest);
                System.Console.Error.WriteLine("REQUEST BODY: " + TestHttpTrace.LastRequestBody);
                System.Console.Error.WriteLine("RESPONSE: " + TestHttpTrace.LastResponseStatus);
                System.Console.Error.WriteLine("RESPONSE BODY: " + TestHttpTrace.LastResponseBody);
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail($"API call failed: {ex.Message}\nREQUEST: {TestHttpTrace.LastRequest}\nREQUEST BODY: {TestHttpTrace.LastRequestBody}\nRESPONSE: {TestHttpTrace.LastResponseStatus}\nRESPONSE BODY: {TestHttpTrace.LastResponseBody}");
                throw;
            }
            catch (System.Exception ex)
            {
                System.Console.Error.WriteLine("REQUEST: " + TestHttpTrace.LastRequest);
                System.Console.Error.WriteLine("REQUEST BODY: " + TestHttpTrace.LastRequestBody);
                System.Console.Error.WriteLine("RESPONSE: " + TestHttpTrace.LastResponseStatus);
                System.Console.Error.WriteLine("RESPONSE BODY: " + TestHttpTrace.LastResponseBody);
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail($"Unexpected error: {ex}\nREQUEST: {TestHttpTrace.LastRequest}\nREQUEST BODY: {TestHttpTrace.LastRequestBody}\nRESPONSE: {TestHttpTrace.LastResponseStatus}\nRESPONSE BODY: {TestHttpTrace.LastResponseBody}");
                throw;
            }
        }
    }
}


