using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using TravelBlogs.Core.Application.Cqrs.Geo.Queries;
using TravelBlogs.Core.Shared.Constants;
using TravelBlogs.Presentation.Host.Controllers.Base;

namespace TravelBlogs.Presentation.Host.Controllers.Manager.Catalog;

[ControllerName("countries")]
[Tags("Manager|Country")]
public class CountryController : BaseAdminAuthController
{
    [HttpPost("search")]
    public async Task<IActionResult> GetAsync(GetCountryByConditionQuery request)
    {
        var result = await Mediator.Send(request);
        return Ok(result, MessageCommon.GetDataSuccess);
    }

    [HttpGet("{countryId:long}/destinations")]
    public async Task<IActionResult> GetDestinationsByCountryAsync(long countryId)
    {
        var result = await Mediator.Send(new GetDestinationByCountryIdQuery(countryId));
        return Ok(result, MessageCommon.GetDataSuccess);
    }
}