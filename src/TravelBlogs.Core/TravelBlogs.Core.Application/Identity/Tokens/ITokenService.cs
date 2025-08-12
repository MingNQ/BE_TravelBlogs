using TravelBlogs.Core.Application.Common.Interfaces;
using TravelBlogs.Core.Application.Identity.Tokens;

namespace Application.Identity.Tokens;

public interface ITokenService : ITransientService
{
    Task<TokenResponse> GetTokenAsync(TokenRequest request, string ipAddress, CancellationToken cancellationToken);

    Task<TokenResponse> RefreshTokenAsync(RefreshTokenRequest request, string ipAddress);
}