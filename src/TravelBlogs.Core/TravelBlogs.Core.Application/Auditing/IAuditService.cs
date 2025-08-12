namespace TravelBlogs.Core.Application.Auditing;

public interface IAuditService
{
    Task<List<AuditDto>> GetUserTrailsAsync(long userId);
}