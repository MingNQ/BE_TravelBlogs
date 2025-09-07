using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using TravelBlogs.Core.Application.Cqrs.Contacts.Commands;
using TravelBlogs.Core.Application.Cqrs.Contacts.Queries;
using TravelBlogs.Core.Shared.Constants;
using TravelBlogs.Presentation.Host.Controllers.Base;

namespace TravelBlogs.Presentation.Host.Controllers.Manager.Catalog;

[ControllerName("contacts")]
[Tags("Manager|Contact")]
public class ContactController : BaseAdminAuthController
{
    [HttpPost("search")]
    public async Task<IActionResult> SearchAsync(GetContactByConditionQuery request)
    {
        var result = await Mediator.Send(request);
        return Ok(result, MessageCommon.GetDataSuccess);
    }
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateContactCommand request)
    {
        var result = await Mediator.Send(request);
        return Ok(result, MessageCommon.CreateSuccess);
    }
    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
    {
        var result = await Mediator.Send(new GetContactByIdQuery { ID = id });
        return Ok(result, MessageCommon.GetDataSuccess);
    }
    [HttpPut("{id:long}")]
    public async Task<IActionResult> UpdateAsync(long id, [FromBody] UpdateContactCommand request)
    {
        request.SetID(id);
        var result = await Mediator.Send(request);
        return Ok(result, MessageCommon.UpdateSuccess);
    }
    [HttpDelete("{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        var result = await Mediator.Send(new DeleteContactCommand { Id = id });
        return Ok(result, MessageCommon.DeleteSuccess);
    }
}