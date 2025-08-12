using System.Security.Claims;

namespace TravelBlogs.Infrastructure.Auth;

public interface ICurrentUserInitializer
{
    void SetCurrentUser(ClaimsPrincipal user);

    void SetCurrentUserId(int userId);

}
