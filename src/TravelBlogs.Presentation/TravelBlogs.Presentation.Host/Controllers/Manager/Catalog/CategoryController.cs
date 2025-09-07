using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using TravelBlogs.Core.Application.Cqrs.Categories.Commands;
using TravelBlogs.Core.Application.Cqrs.Categories.Queries;
using TravelBlogs.Core.Shared.Constants;
using TravelBlogs.Presentation.Host.Controllers.Base;

namespace TravelBlogs.Presentation.Host.Controllers.Manager.Catalog;

[ControllerName("categories")]
[Tags("Manager|Category")]
public class CategoryController : BaseAdminAuthController
{
    [HttpPost("search")]
    public async Task<IActionResult> GetAsync(GetCategoryByConditionQuery request)
    {
        var result = await Mediator.Send(request);
        return Ok(result, MessageCommon.GetDataSuccess);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateCategoryCommand request)
    {
        var result = await Mediator.Send(request);
        return Ok(result, MessageCommon.CreateSuccess);
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
    {
        var result = await Mediator.Send(new GetCategoryByIdQuery { Id = id });
        return Ok(result, MessageCommon.GetDataSuccess);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> UpdateAsync(long id, UpdateCategoryCommand request)
    {
        var result = await Mediator.Send(request.SetId(id));
        return Ok(result, MessageCommon.UpdateSuccess);
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        var result = await Mediator.Send(new DeleteCategoryCommand { Id = id });
        return Ok(result, MessageCommon.DeleteSuccess);
    }
}