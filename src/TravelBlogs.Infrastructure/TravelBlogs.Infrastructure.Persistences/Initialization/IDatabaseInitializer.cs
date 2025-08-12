namespace TravelBlogs.Infrastructure.Persistences.Initialization;

public interface IDatabaseInitializer
{
    Task InitializeDatabasesAsync(CancellationToken cancellationToken);
}