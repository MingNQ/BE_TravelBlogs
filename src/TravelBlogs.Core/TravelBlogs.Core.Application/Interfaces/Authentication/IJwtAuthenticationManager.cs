using System.Security.Claims;
using TravelBlogs.Core.Application.Dto.Authorization;

namespace Application.Interfaces.Authentication;

public interface IJwtAuthenticationManager
{
    Task<AuthenticateResultModel> Authenticate(string username, string password);

    Task<AuthenticateResultModel> Authenticate(int userId, Claim[] claims);

    Task<bool> ValidToken(int userId, string refreshToken);

    // Task<AuthenticateResultModel> VerifyGoogleToken(ExternalAuthDto externalAuth);

    // Task<AuthenticateResultModel> VerifyFacebookToken(ExternalAuthDto externalAuth);
}