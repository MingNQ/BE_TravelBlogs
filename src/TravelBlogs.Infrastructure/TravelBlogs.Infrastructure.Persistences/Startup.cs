using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using TravelBlogs.Core.Application.Common;
using TravelBlogs.Core.Application.Common.Persistences;
using TravelBlogs.Core.Shared.Constants;
using TravelBlogs.Infrastructure.Persistences.Context;
using TravelBlogs.Infrastructure.Persistences.Initialization;
using TravelBlogs.Infrastructure.Persistences.Repository;

namespace TravelBlogs.Infrastructure.Persistences;

public static class Startup
{
    private const string MigrationsAssembly = "TravelBlogs.Infrastructure.Migrators";

    public static IServiceCollection AddPersistences(this IServiceCollection services)
    {
        services.AddOptions<DatabaseSettings>()
            .BindConfiguration(nameof(DatabaseSettings))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        return services.AddDbContext<ApplicationDbContext>((p, m) =>
            {
                var databaseSettings = p.GetRequiredService<IOptions<DatabaseSettings>>().Value;
                m.UseDatabase(databaseSettings.DbProvider, databaseSettings.ConnectionString);
            })
            .AddTransient<IDatabaseInitializer, DatabaseInitializer>()
            .AddTransient<ApplicationDbInitializer>()
            .AddTransient<ApplicationDbSeeder>()
            .AddServices(typeof(ICustomSeeder), ServiceLifetime.Transient)
            .AddTransient<CustomSeederRunner>()
            .AddRepositories();
    }

    public static DbContextOptionsBuilder UseDatabase(this DbContextOptionsBuilder builder, string dbProvider, string connectionString)
    {
        return dbProvider.ToLowerInvariant() switch
        {
            DbProviderKeys.SqlServer => builder.UseSqlServer(connectionString, e =>
                e.MigrationsAssembly(MigrationsAssembly)),
            _ => throw new InvalidOperationException($"DB Provider {dbProvider} is not supported.")
        };
    }
    
    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IReadRepository<>), typeof(ApplicationDbRepository<>));

        return services;
    }
}