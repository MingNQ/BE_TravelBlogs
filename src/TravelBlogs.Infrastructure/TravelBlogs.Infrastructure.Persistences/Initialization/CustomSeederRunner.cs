using Microsoft.Extensions.DependencyInjection;

namespace TravelBlogs.Infrastructure.Persistences.Initialization;

public class CustomSeederRunner(IServiceProvider serviceProvider)
{
    private readonly ICustomSeeder[] _seeders = serviceProvider.GetServices<ICustomSeeder>().ToArray();

    public async Task RunSeedersAsync(CancellationToken cancellationToken)
    {
        foreach (var seeder in _seeders)
        {
            await seeder.InitializeAsync(cancellationToken);
        }
    }
}