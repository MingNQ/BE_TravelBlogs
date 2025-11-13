using Asp.Versioning;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TravelBlogs.Core.Application.Common;
using TravelBlogs.Core.Application.Configurations;
using TravelBlogs.Infrastructure.Auth;
using TravelBlogs.Infrastructure.Cors;
using TravelBlogs.Infrastructure.ExternalService;
using TravelBlogs.Infrastructure.Persistences;
using TravelBlogs.Infrastructure.Persistences.Context;
using TravelBlogs.Infrastructure.Persistences.Initialization;
using TravelBlogs.Infrastructure.Services;
using TravelBlogs.Infrastructure.UnitOfWork;

namespace TravelBlogs.Infrastructure;

public static class Startup
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        return services
            .AddSettings()
            .AddApiVersioning()
            .AddAuth(config)
            .AddUnitOfWork<ApplicationDbContext>()
            .AddCustomRepository()
            .AddCorsPolicy(config)
            .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()))
            .AddPersistences()
            .AddRouting(options => options.LowercaseUrls = true)
            .AddServices()
            .AddExternalService(config)
            .AddRegisterService();
    }

    private static IServiceCollection AddApiVersioning(this IServiceCollection service)
    {
        service.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ReportApiVersions = true;
        })
        .AddApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        });

        service.AddEndpointsApiExplorer();
        return service;
    }

    private static IServiceCollection AddSettings(this IServiceCollection service)
    {
        service.AddOptions<AppSettings>()
            .BindConfiguration($"{nameof(AppSettings)}");

        return service;
    }

    public static async Task InitializeDatabasesAsync(this IServiceProvider services, CancellationToken cancellationToken = default)
    {
        // Create a new scope to retrieve scoped services
        using var scope = services.CreateScope();

        await scope.ServiceProvider.GetRequiredService<IDatabaseInitializer>()
            .InitializeDatabasesAsync(cancellationToken);
    }

    public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder builder, IConfiguration config, IWebHostEnvironment environment) =>
        builder
            .UseRequestLocalization()
            .UseStaticFiles()
            .UseRouting()
            .UseCorsPolicy()
            .UseAuthentication()
            .UseCurrentUser()
            .UseAuthorization();
}