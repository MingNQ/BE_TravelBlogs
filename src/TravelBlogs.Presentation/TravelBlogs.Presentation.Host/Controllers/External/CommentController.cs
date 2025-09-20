using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using TravelBlogs.Core.Application.Cqrs.Comments.Commands;
using TravelBlogs.Presentation.Host.Controllers.Base;

namespace TravelBlogs.Presentation.Host.Controllers.External;

[ControllerName("comment")]
[Tags("External|Comment")]
public class CommentController : BaseAuthController
{
    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateCommentCommand request)
    {
        var result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPut("{id:long}")]
    public IActionResult UpdateAsync(long id, UpdateCommentCommand request)
    {
        request.SetId(id);
        var result = Mediator.Send(request);
        return Ok(result);
    }

    [HttpDelete("{id:long}")]
    public IActionResult DeleteAsync(long id)
    {
        var result = Mediator.Send(new DeleteCommentCommand
        {
            Id = id
        });
        return Ok(result);
    }
}