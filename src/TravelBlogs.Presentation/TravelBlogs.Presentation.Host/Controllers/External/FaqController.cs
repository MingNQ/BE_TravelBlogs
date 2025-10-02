using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using TravelBlogs.Core.Application.Cqrs.Faqs.Queries;
using TravelBlogs.Presentation.Host.Controllers.Base;

namespace TravelBlogs.Presentation.Host.Controllers.External;

[ControllerName("faqs")]
[Tags("External|FAQs")]
public class FaqController : BaseNoAuthController
{
	[HttpGet]
	public async Task<IActionResult> GetAsync()
	{
		var result = await Mediator.Send(new GetFaqForExternalQuery());
		return Ok(result);
	}
}