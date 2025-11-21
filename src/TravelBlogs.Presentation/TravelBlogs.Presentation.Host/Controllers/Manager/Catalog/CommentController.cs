using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using TravelBlogs.Core.Application.Cqrs.Comments.Queries;
using TravelBlogs.Core.Shared.Constants;
using TravelBlogs.Presentation.Host.Controllers.Base;

namespace TravelBlogs.Presentation.Host.Controllers.Manager.Catalog;

[ControllerName("comment")]
[Tags("Manager|Comment")]
public class CommentController : BaseAdminAuthController
{   
    [HttpPost("search")]
    public async Task<IActionResult> GetAsync([FromBody] GetCommentByConditionQuery request)
    {
        var result = await Mediator.Send(request);
        return Ok(result, MessageCommon.GetDataSuccess);
    }
}