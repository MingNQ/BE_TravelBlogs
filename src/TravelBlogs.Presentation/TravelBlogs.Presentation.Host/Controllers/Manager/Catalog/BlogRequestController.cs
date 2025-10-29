using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using TravelBlogs.Core.Application.Cqrs.BlogRequests.Commands;
using TravelBlogs.Presentation.Host.Controllers.Base;

namespace TravelBlogs.Presentation.Host.Controllers.Manager.Catalog;

[ControllerName("blog-request")]
[Tags("Manager|BookingRequest")]
public class BlogRequestController : BaseAdminAuthController
{
    [HttpPost("{blogId:long}/approval")]
    public async Task<IActionResult> ApprovalBlogRequestAsync(long blogId, ApprovalBlogRequestCommand request)
    {
        request.BlogId = blogId;
        var result = await Mediator.Send(request);

        return Ok(result);
    }

    [HttpPost("{blogId:long}/reject")]
    public async Task<IActionResult> RejectBlogRequestAsync(long blogId, RejectBlogRequestCommand request)
    {
        request.BlogId = blogId;
        var result = await Mediator.Send(request);

        return Ok(result);
    }
}