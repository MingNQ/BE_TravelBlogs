using Application.Identity.Tokens;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelBlogs.Core.Application.Identity.Tokens;
using TravelBlogs.Presentation.Host.Controllers.Base;

namespace TravelBlogs.Presentation.Host.Controllers.Common;

[ApiController]
public class TokenController(ITokenService tokenService) : VersionedApiController
{
    [HttpPost]
    [AllowAnonymous]
    public Task<TokenResponse> GetTokenAsync(TokenRequest request, CancellationToken cancellationToken)
    {
        return tokenService.GetTokenAsync(request, GetIpAddress()!, cancellationToken);
    }

    [HttpPost("refresh")]
    [AllowAnonymous]
    public Task<TokenResponse> RefreshAsync(RefreshTokenRequest request)
    {
        return tokenService.RefreshTokenAsync(request, GetIpAddress()!);
    }

    private string? GetIpAddress() =>
        Request.Headers.ContainsKey("X-Forwarded-For")
            ? Request.Headers["X-Forwarded-For"]
            : HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString() ?? "N/A";
}
