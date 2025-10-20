using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using TravelBlogs.Core.Application.Configurations;
using TravelBlogs.Infrastructure.ExternalService.ExternalEndpointClients.DelegatingRequestHandler;
using TravelBlogs.Infrastructure.ExternalService.ExternalEndpointClients.RefitInterfaces;
using Uri = System.Uri;

namespace TravelBlogs.Infrastructure.ExternalService.ExternalEndpointClients;

public static class Startup
{
    public static void AddRefitClients(this IServiceCollection services, IConfiguration config)
    {
        services.AddTransient<AddBearerTokenHeader>();

        var externalBaseUriSettings = config.GetSection(nameof(ExternalUriSettings)).Get<ExternalUriSettings>();

        services.AddRefitClient<IEmailServiceClient>()
            .ConfigureHttpClient(c =>
            {
                c.BaseAddress = externalBaseUriSettings?.EmailService is not null
                    ? new Uri(externalBaseUriSettings.EmailService)
                    : throw new ArgumentNullException(nameof(externalBaseUriSettings.EmailService));
            });

        services.AddRefitClient<INotificationServiceClient>()
            .ConfigureHttpClient(c =>
            {
                c.BaseAddress = externalBaseUriSettings?.EmailService is not null
                    ? new Uri(externalBaseUriSettings.EmailService)
                    : throw new ArgumentNullException(nameof(externalBaseUriSettings.EmailService));
            });
    }
}