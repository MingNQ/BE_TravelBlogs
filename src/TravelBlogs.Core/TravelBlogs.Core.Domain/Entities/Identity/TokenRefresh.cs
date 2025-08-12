using TravelBlogs.Core.Domain.Common.Contracts;

namespace TravelBlogs.Core.Domain.Entities.Identity;

public class TokenRefresh : AuditableEntity<long>
{
    public long UserId { get; private set; }
    public string Token { get; private set; } = string.Empty;
    public DateTimeOffset ExpiredDate { get; private set; }

    public static TokenRefresh Create(long userId, string token, DateTimeOffset expiredDate)
    {
        return new TokenRefresh
        {
            UserId = userId,
            Token = token,
            ExpiredDate = expiredDate
        };
    }
}