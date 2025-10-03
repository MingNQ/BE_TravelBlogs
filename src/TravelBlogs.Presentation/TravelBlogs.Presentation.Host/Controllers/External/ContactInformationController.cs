using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using TravelBlogs.Core.Application.Cqrs.ContactsInformation.Queries;
using TravelBlogs.Core.Shared.Constants;
using TravelBlogs.Presentation.Host.Controllers.Base;

namespace TravelBlogs.Presentation.Host.Controllers.External;

[ControllerName("contact-information")]
[Tags("External|Contact Information")]
public class ContactInformationController : BaseNoAuthController
{
	[HttpGet]
	public async Task<IActionResult> GetAsync()
	{
		var result = await Mediator.Send(new GetContactInformationForExternalQuery());
		return Ok(result, MessageCommon.GetDataSuccess);
	}
}