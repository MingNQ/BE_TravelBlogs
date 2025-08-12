namespace TravelBlogs.Core.Application.Interfaces.Authentication;

public interface IRefreshTokenGenerator
{
    string GenerateToken();
}