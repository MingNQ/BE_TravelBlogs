using TravelBlogs.Infrastructure.Auth.Jwt;

namespace TravelBlogs.Infrastructure.Auth;

public class SecuritySettings
{
    public string? Provider { get; set; }
    public bool RequireConfirmedAccount { get; set; }

    public JwtSettings JwtSettings { get; set; } = new();
}