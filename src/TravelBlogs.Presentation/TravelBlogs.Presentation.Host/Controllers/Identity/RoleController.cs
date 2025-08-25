using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelBlogs.Core.Application.Cqrs.Roles.Commands;
using TravelBlogs.Core.Application.Cqrs.Roles.Queries;
using TravelBlogs.Core.Shared.Constants;
using TravelBlogs.Presentation.Host.Controllers.Base;

namespace TravelBlogs.Presentation.Host.Controllers.Identity;

public class RoleController : BaseAuthController
{
    [HttpPost("search")]
    public async Task<IActionResult> GetAsync()
    {
        var result = await Mediator.Send(new GetRoleByConditionQuery());
        return Ok(result, MessageCommon.GetDataSuccess);
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
    {
        var result = await Mediator.Send(new GetRoleByIdQuery
        {
            Id = id
        });
        return Ok(result, MessageCommon.GetDataSuccess);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateRoleCommand request)
    {
        var result = await Mediator.Send(request);
        return Ok(result, MessageCommon.CreateSuccess);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> UpdateAsync(long id, [FromBody] UpdateRoleCommand request)
    {
        request.SetId(id);
        var result = await Mediator.Send(request);
        return Ok(result, MessageCommon.UpdateSuccess);
    }

    [HttpDelete("{id:long}")]
    public IActionResult DeleteAsync(long id)
    {   
        var result = Mediator.Send(new DeleteRoleCommand
        {
            Id = id
        });
        return Ok(result, MessageCommon.DeleteSuccess);
    }
}