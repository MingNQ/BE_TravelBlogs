using MediatR;
using Microsoft.AspNetCore.Mvc;
using TravelBlogs.Core.Application.Cqrs.Categories.Commands;
using TravelBlogs.Core.Application.Cqrs.Categories.Queries;

namespace TravelBlogs.Presentation.Host.Controllers
{ 
    [ApiController]
    [Route("api/v1/categories")]
    public class CategoriesController : ControllerBase 
    {
        private readonly IMediator _mediator;
        public CategoriesController(IMediator mediator) => _mediator = mediator;

        [HttpPost("search")]
        public async Task<IActionResult> Search(SearchCategoriesQuery query) =>
            Ok(await _mediator.Send(query));

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryCommand command)
        {
            var categoryId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = categoryId }, command);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id) =>
            Ok(await _mediator.Send(new GetCategoryByIdQuery { Id = id }));

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, UpdateCategoryCommand command)
        {
            if (id != command.Id) return BadRequest();
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _mediator.Send(new DeleteCategoryCommand { Id = id });
            return NoContent();
        }
    }
} 