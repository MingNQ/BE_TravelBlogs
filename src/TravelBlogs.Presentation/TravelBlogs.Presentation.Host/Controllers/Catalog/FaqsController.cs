using Microsoft.AspNetCore.Mvc;
using TravelBlogs.Core.Application.Cqrs.Faqs.Commands;
using TravelBlogs.Core.Application.Cqrs.Faqs.Queries;
using TravelBlogs.Core.Shared.Constants;
using TravelBlogs.Presentation.Host.Controllers.Base;

namespace TravelBlogs.Presentation.Host.Controllers.Catalog;

public class FaqsController : BaseAuthController
{
    [HttpPost("search")]
    public async Task<IActionResult> SearchAsync([FromBody] GetFaqByConditionQuery request)
    {
        var result = await Mediator.Send(request);
        return Ok(result, MessageCommon.GetDataSuccess);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateFaqCommand request)
    {
        var result = await Mediator.Send(request);
        return Ok(result, MessageCommon.CreateSuccess);
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
    {
        var result = await Mediator.Send(new GetFaqByIdQuery { Id = id });
        return Ok(result, MessageCommon.GetDataSuccess);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> UpdateAsync(long id, [FromBody] UpdateFaqCommand request)
    {
        request.SetId(id);
        var result = await Mediator.Send(request);
        return Ok(result, MessageCommon.UpdateSuccess);
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        var result = await Mediator.Send(new DeleteFaqCommand { Id = id });
        return Ok(result, MessageCommon.DeleteSuccess);
    }
}
