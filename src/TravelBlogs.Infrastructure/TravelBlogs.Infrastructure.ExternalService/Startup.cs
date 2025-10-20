using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TravelBlogs.Core.Application.Configurations;
using TravelBlogs.Core.Application.Interfaces.Integrates;
using TravelBlogs.Infrastructure.ExternalService.ExternalEndpointClients;

namespace TravelBlogs.Infrastructure.ExternalService;

public static class Startup
{
    public static IServiceCollection AddExternalService(this IServiceCollection services, IConfiguration config)
    {
        services.AddOptions<ExternalUriSettings>()
            .BindConfiguration(nameof(ExternalUriSettings))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        services.AddHttpClient<IExternalEnpointClient, ExternalEnpointClient>();
        services.AddRefitClients(config);

        return services;
    }
}