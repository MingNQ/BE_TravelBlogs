using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using TravelBlogs.Core.Application.Cqrs.Categories.Queries;
using TravelBlogs.Core.Shared.Constants;
using TravelBlogs.Presentation.Host.Controllers.Base;

namespace TravelBlogs.Presentation.Host.Controllers.External;

[ControllerName("categories")]
[Tags("External|Category")]
public class CategoryController : BaseNoAuthController
{
	[HttpGet]
	public async Task<IActionResult> GetAsync()
	{
		var result = await Mediator.Send(new GetCategoryForExternalQuery());
		return Ok(result, MessageCommon.GetDataSuccess);
	}
}