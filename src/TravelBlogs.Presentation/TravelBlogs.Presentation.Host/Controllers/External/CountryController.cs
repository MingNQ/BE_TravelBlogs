using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using TravelBlogs.Core.Application.Cqrs.Geo.Queries;
using TravelBlogs.Presentation.Host.Controllers.Base;

namespace TravelBlogs.Presentation.Host.Controllers.External;

[ControllerName("country")]
[Tags("External|Geography")]
public class CountryController : BaseNoAuthController
{
    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var result = await Mediator.Send(new GetCountriesQuery());
        return Ok(result);
    }

    [HttpGet("{countryId:long}/destinations")]
    public async Task<IActionResult> GetDestinationsByCountryAsync(long countryId)
    {
        var result = await Mediator.Send(new GetDestinationsByCountryQuery(countryId));
        return Ok(result);
    }
}