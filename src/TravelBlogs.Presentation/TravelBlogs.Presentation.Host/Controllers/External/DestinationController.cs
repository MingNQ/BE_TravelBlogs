using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using TravelBlogs.Core.Application.Cqrs.Geo.Queries;
using TravelBlogs.Presentation.Host.Controllers.Base;

namespace TravelBlogs.Presentation.Host.Controllers.External;

[ControllerName("destinations")]
[Tags("External|Geography")]
public class DestinationController : BaseNoAuthController
{
	[HttpGet("{countryId:long}")]
	public async Task<IActionResult> GetByCountryAsync(long countryId)
	{
		var result = await Mediator.Send(new GetDestinationsByCountryQuery(countryId));
		return Ok(result);
	}
}