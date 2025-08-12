using TravelBlogs.Core.Application.Dto.Authorization;

namespace TravelBlogs.Core.Application.Interfaces.Authentication;

public interface ITokenRefresher
{
    Task<AuthenticateResultModel> Refresh(RefreshTokenModel refreshInput);
}