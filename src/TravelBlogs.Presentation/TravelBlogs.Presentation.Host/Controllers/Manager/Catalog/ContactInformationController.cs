using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using TravelBlogs.Core.Application.Cqrs.ContactsInformation.Commands;
using TravelBlogs.Core.Application.Cqrs.ContactsInformation.Queries;
using TravelBlogs.Core.Application.Cqrs.Faqs.Queries;
using TravelBlogs.Core.Shared.Constants;
using TravelBlogs.Presentation.Host.Controllers.Base;

namespace TravelBlogs.Presentation.Host.Controllers.Manager.Catalog;

[ControllerName("contact-information")]
[Tags("Manager|Contact Information")]
public class ContactInformationController : BaseAdminAuthController
{
    [HttpPost("search")]
    public async Task<IActionResult> SearchAsync([FromBody] GetFaqByConditionQuery request)
    {
        var result = await Mediator.Send(request);
        return Ok(result, MessageCommon.GetDataSuccess);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateContactInformationCommand request)
    {
        var result = await Mediator.Send(request);
        return Ok(result, MessageCommon.CreateSuccess);
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
    {
        var result = await Mediator.Send(new GetContactInformationByIdQuery { Id = id });
        return Ok(result, MessageCommon.GetDataSuccess);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> UpdateAsync(long id, [FromBody] UpdateContactInformationCommand request)
    {
        request.SetId(id);
        var result = await Mediator.Send(request);
        return Ok(result, MessageCommon.UpdateSuccess);
    }

    [HttpPut("{id:long}/set-default")]
    public async Task<IActionResult> UpdateDefaultAsync(long id, SetContactInformationDefaultCommand request)
    {
        request.SetId(id);
        var result = await Mediator.Send(request);
        return Ok(result, MessageCommon.UpdateSuccess);
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        var result = await Mediator.Send(new DeleteContactInformationCommand { Id = id });
        return Ok(result, MessageCommon.DeleteSuccess);
    }
}