namespace TravelBlogs.Core.Application.Interfaces.Services;

public interface ISyncService
{
    Task SyncCountriesData(CancellationToken cancellationToken = default);
}