using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using TravelBlogs.Core.Application.Cqrs.Blogs.Queries;
using TravelBlogs.Core.Shared.Constants;
using TravelBlogs.Presentation.Host.Controllers.Base;

namespace TravelBlogs.Presentation.Host.Controllers.External;

[ControllerName("blogs")]
[Tags("External|Blog")]
public class BlogController : BaseNoAuthController
{
    [HttpPost("search")]
    public async Task<IActionResult> GetAsync(GetBlogByConditionQuery request)
    {
        var result = await Mediator.Send(request);
        return Ok(result, MessageCommon.GetDataSuccess);
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
    {
        var result = await Mediator.Send(new GetBlogByIdQuery
        {
            Id = id
        });
        return Ok(result, MessageCommon.GetDataSuccess);
    }
}