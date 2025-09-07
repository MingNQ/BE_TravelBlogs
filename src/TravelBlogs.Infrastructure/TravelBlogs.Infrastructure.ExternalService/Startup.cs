using Microsoft.Extensions.DependencyInjection;
using TravelBlogs.Core.Application.Configurations;
using TravelBlogs.Core.Application.Interfaces.Integrates;

namespace TravelBlogs.Infrastructure.ExternalService;

public static class Startup
{
    public static IServiceCollection AddExternalService(this IServiceCollection services)
    {
        services.AddOptions<ExternalUriSettings>()
            .BindConfiguration(nameof(ExternalUriSettings))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        services.AddHttpClient<IExternalEnpointClient, ExternalEnpointClient>();

        return services;
    }
}