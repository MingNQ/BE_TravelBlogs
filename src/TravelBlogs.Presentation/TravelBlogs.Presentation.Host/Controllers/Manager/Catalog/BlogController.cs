using System.Threading.Tasks;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using TravelBlogs.Core.Application.Cqrs.Blogs.Commands;
using TravelBlogs.Core.Application.Cqrs.Blogs.Queries;
using TravelBlogs.Core.Shared.Constants;
using TravelBlogs.Presentation.Host.Controllers.Base;

namespace TravelBlogs.Presentation.Host.Controllers.Manager.Catalog;

[ControllerName("blogs")]
[Tags("Manager|Blog")]
public class BlogController : BaseAdminAuthController
{
    [HttpPost("search")]
    public async Task<IActionResult> GetAsync([FromBody] GetBlogByConditionQuery request)
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

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateBlogCommand request)
    {
        var result = await Mediator.Send(request);
        return Ok(result, MessageCommon.CreateSuccess);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> UpdateAsync(long id, [FromBody] UpdateBlogCommand request)
    {
        request.SetId(id);
        var result = await Mediator.Send(request);
        return Ok(result, MessageCommon.CreateSuccess);
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        var result = await Mediator.Send(new DeleteBlogCommand
        {
            Id = id
        });
        return Ok(result, MessageCommon.CreateSuccess);
    }
}