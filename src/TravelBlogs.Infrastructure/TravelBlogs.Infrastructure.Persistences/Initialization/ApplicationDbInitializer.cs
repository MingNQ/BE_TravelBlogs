using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TravelBlogs.Infrastructure.Persistences.Context;

namespace TravelBlogs.Infrastructure.Persistences.Initialization;

public class ApplicationDbInitializer(
    ApplicationDbContext dbContext, 
    ILogger<ApplicationDbInitializer> logger,
    ApplicationDbSeeder dbSeeder)
{
    public async Task InitializeAsync(CancellationToken cancellationToken)
    {
        if (dbContext.Database.GetMigrations().Any())
        {
            if ((await dbContext.Database.GetPendingMigrationsAsync(cancellationToken)).Any())
            {
                logger.LogInformation("Applying Migrations");
                await dbContext.Database.MigrateAsync(cancellationToken);
            }

            if (await dbContext.Database.CanConnectAsync(cancellationToken))
            {
                logger.LogInformation("Connection to Database Succeeded.");

                await dbSeeder.SeedDatabaseAsync(dbContext, cancellationToken);
            }
        }
    }
}