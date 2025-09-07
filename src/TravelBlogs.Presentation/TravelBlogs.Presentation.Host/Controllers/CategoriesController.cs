using Microsoft.AspNetCore.Mvc;
using TravelBlogs.Core.Application.Cqrs.Categories.Commands;
using TravelBlogs.Core.Application.Cqrs.Categories.Queries;
using TravelBlogs.Presentation.Host.Controllers.Base;

namespace TravelBlogs.Presentation.Host.Controllers;

[Route("api/v1/categories")]
public class CategoriesController : BaseApiController
{
    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateCategoryCommand request)
    {
        return Ok(await Mediator.Send(request));
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
    {
        return Ok(await Mediator.Send(new GetCategoryByIdQuery { Id = id }));
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> UpdateAsync(long id, UpdateCategoryCommand request)
    {
        return Ok(await Mediator.Send(request.SetId(id)));
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        return Ok(await Mediator.Send(new DeleteCategoryCommand { Id = id }));
    }
}