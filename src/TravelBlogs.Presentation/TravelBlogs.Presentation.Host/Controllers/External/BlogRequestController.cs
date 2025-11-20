using System.Threading.Tasks;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using TravelBlogs.Core.Application.Cqrs.BlogRequests.Commands;
using TravelBlogs.Core.Application.Cqrs.BlogRequests.Queries;
using TravelBlogs.Core.Shared.Constants;
using TravelBlogs.Presentation.Host.Controllers.Base;

namespace TravelBlogs.Presentation.Host.Controllers.External;

[ControllerName("blog-request")]
[Tags("External|BlogRequest")]
public class BlogRequestController : BaseAuthController
{
    [HttpPost]
    public async Task<IActionResult> CreateBlogRequestAsync(CreateBlogRequestCommand request)
    {
        var result = await Mediator.Send(request);

        return Ok(result, MessageCommon.CreateSuccess);
    }

    [HttpPost("my/search")]
    public async Task<IActionResult> GetBlogRequestAsync(GetBlogRequestByConditionQuery request)
    {
        var result = await Mediator.Send(request);
        return Ok(result, MessageCommon.GetDataSuccess);
    }

    [HttpGet("my/{id:long}")]
    public async Task<IActionResult> GetBlogRequestByIdAsync(long id)
    {
        var result = await Mediator.Send(new GetBlogRequestByIdQuery
        {
            BlogId = id
        });
        return Ok(result, MessageCommon.GetDataSuccess);
    }

    [HttpPost("{blogId:long}/cancel")]
    public async Task<IActionResult> CancelBlogRequestAsync(long blogId, CancelBlogRequestCommand request)
    {
        request.BlogId = blogId;
        var result = await Mediator.Send(request);
        return Ok(result, MessageCommon.GetDataSuccess);
    }
}