using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using TravelBlogs.Core.Application.Cqrs.Geo.Queries;
using TravelBlogs.Presentation.Host.Controllers.Base;

namespace TravelBlogs.Presentation.Host.Controllers.External;

[ControllerName("countries")]
[Tags("External|Geography")]
public class CountryController : BaseNoAuthController
{
    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var result = await Mediator.Send(new GetCountriesQuery());
        return Ok(result);
    }
}