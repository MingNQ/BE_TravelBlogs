using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TravelBlogs.Core.Application.Common.Interfaces;
using TravelBlogs.Infrastructure.Auth.Jwt;

namespace TravelBlogs.Infrastructure.Auth;

public static class Startup
{
    public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration config)
    {
        services.AddCurrentUser();
        services.Configure<SecuritySettings>(config.GetSection(nameof(SecuritySettings)));
        return services.AddJwtAuth();
    }

    public static IApplicationBuilder UseCurrentUser(this IApplicationBuilder app) =>
        app.UseMiddleware<CurrentUserMiddleware>();

    private static void AddCurrentUser(this IServiceCollection services)
    {
        services
            .AddScoped<CurrentUserMiddleware>()
            .AddScoped<ICurrentUser, CurrentUser>()
            .AddScoped(sp => (ICurrentUserInitializer)sp.GetRequiredService<ICurrentUser>());
    }
}