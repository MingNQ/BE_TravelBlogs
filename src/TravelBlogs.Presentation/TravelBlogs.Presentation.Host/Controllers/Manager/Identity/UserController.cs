using Application.Cqrs.Users.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelBlogs.Core.Application.Common.Interfaces;
using TravelBlogs.Core.Application.Cqrs.Users.Commands;
using TravelBlogs.Core.Application.Cqrs.Users.Queries;
using TravelBlogs.Core.Shared.Constants;
using TravelBlogs.Presentation.Host.Controllers.Base;

namespace TravelBlogs.Presentation.Host.Controllers.Manager.Identity;

public class UserController(ICurrentUser currentUser) : BaseAdminAuthController
{
    [Authorize(Roles = $"{AppConsts.AdminRoleName}")]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateUserCommand request)
    {
        var result = await Mediator.Send(request);
        return Ok(result);
    }

    [Authorize(Roles = $"{AppConsts.AdminRoleName}")]
    [HttpPut("{id:long}")]
    public async Task<IActionResult> UpdateAsync(long id, UpdateUserCommand request)
    {
        request.SetId(id);
        var result = await Mediator.Send(request);
        return Ok(result);
    }

    [Authorize(Roles = $"{AppConsts.AdminRoleName}")]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await Mediator.Send(new DeleteUserCommand
        {
            Id = id
        });
        return Ok(result);
    }

    [Authorize(Roles = $"{AppConsts.AdminRoleName}")]
    [HttpPost("search")]
    public async Task<IActionResult> GetAsync(GetUserByConditionQuery request)
    {
        var result = await Mediator.Send(request);
        return Ok(result);
    }

    [Authorize(Roles = $"{AppConsts.AdminRoleName}")]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await Mediator.Send(new GetUserByIdQuery
        {
            Id = id
        }));
    }

    [Authorize(Roles = $"{AppConsts.AdminRoleName}")]
    [HttpGet("current-user")]
    public async Task<IActionResult> GetCurrentUserDetail()
    {
        return Ok(await Mediator.Send(new GetUserByIdQuery
        {
            Id = currentUser.UserId
        }));
    }

    //[Authorize(Roles = $"{AppConsts.AdminRoleName}")]
    //[HttpGet("users-by-role")]
    //public async Task<IActionResult> GetUserByRole([FromQuery] GetUserByRoleQuery request)
    //{
    //    return Ok(await Mediator.Send(request));
    //}

    [Authorize(Roles = $"{AppConsts.AdminRoleName}")]
    [HttpPost("{id:long}/change-password")]
    public async Task<IActionResult> UpdateAsync(long id, UpdatePasswordCommand request)
    {
        request.SetUserId(id);
        var result = await Mediator.Send(request);
        return Ok(result);
    }

    [Authorize(Roles = $"{AppConsts.AdminRoleName}")]
    [HttpPost("change-password")]
    public async Task<IActionResult> UpdateCurrentUserPasswordAsync(UpdatePasswordCommand request)
    {
        request.SetUserId(currentUser.UserId);
        var result = await Mediator.Send(request);
        return Ok(result);
    }
}
