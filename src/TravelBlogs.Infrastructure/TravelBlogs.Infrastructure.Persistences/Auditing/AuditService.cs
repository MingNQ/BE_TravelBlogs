using Microsoft.EntityFrameworkCore;
using TravelBlogs.Core.Application.Auditing;
using TravelBlogs.Infrastructure.Persistences.Context;
using Mapster;

namespace TravelBlogs.Infrastructure.Persistences.Auditing;

public class AuditService(ApplicationDbContext context) : IAuditService
{
    public async Task<List<AuditDto>> GetUserTrailsAsync(long userId)
    {
        var trails = await context.AuditTrails
            .Where(a => a.UserId == userId)
            .OrderByDescending(a => a.DateTime)
            .Take(250)
            .ToListAsync();

        return trails.Adapt<List<AuditDto>>();
    }
}