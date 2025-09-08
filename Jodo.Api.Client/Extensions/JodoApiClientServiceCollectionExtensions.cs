using Jodo.Api.Client.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace Jodo.Api.Client.Extensions
{
    public static class JodoApiClientServiceCollectionExtensions
    {
        public static IServiceCollection AddJodoApiClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JodoApiOptions>(configuration.GetSection("JodoApi"));

            services.AddTransient<AuthenticationDelegatingHandler>();

            services.AddHttpClient<IJodoApiClient, JodoApiClient>()
                .ConfigureHttpClient((serviceProvider, client) =>
                {
                    var options = serviceProvider.GetRequiredService<IOptions<JodoApiOptions>>().Value;
                    client.BaseAddress = new Uri($"https://{options.ApiHost}");
                })
                .AddHttpMessageHandler<AuthenticationDelegatingHandler>();

            return services;
        }
    }
}
