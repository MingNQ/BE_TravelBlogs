using Microsoft.AspNetCore.Authorization;

namespace TravelBlogs.Presentation.Host.Controllers.Base;

[AllowAnonymous]
public class BaseNoAuthController : VersionedApiController
{

}
