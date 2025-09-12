using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelBlogs.Core.Application.Common.Responses;
using TravelBlogs.Core.Shared.Constants;

namespace TravelBlogs.Presentation.Host.Controllers.Base;

[Authorize]
public class BaseAuthController : VersionedApiController
{
    /// <summary>
    /// Return a success response in ResponseBase and with a message.
    /// </summary>
    protected OkObjectResult Ok(object value, string message) => Ok(new ResponseBase<object>(value, message));

    /// <summary>
    /// Return a success response in ResponseBase and with a message.
    /// </summary>
    protected OkObjectResult Ok<T>(T result, string message) => Ok(new ResponseBase<T>(result, message));
}

[Authorize(Roles = $"{AppConsts.AdminRoleName}")]
[Route("api/v{version:apiVersion}/admin/[controller]")]
public class BaseAdminAuthController : BaseAuthController;

[Authorize(Roles = $"{AppConsts.ManagerRoleName}")]
[Route("api/v{version:apiVersion}/manager/[controller]")]
public class BaseManagerAuthController : BaseAuthController;