namespace TravelBlogs.Infrastructure.Persistences.Initialization;

public interface ICustomSeeder
{
    Task InitializeAsync(CancellationToken cancellationToken);
}