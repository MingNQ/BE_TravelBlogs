using Microsoft.AspNetCore.Mvc;
using TravelBlogs.Core.Application.Interfaces.Services;
using TravelBlogs.Presentation.Host.Controllers.Base;

namespace TravelBlogs.Presentation.Host.Controllers.Setup;

public class SetupController(ISyncService syncService) : BaseNoAuthController
{
    [HttpPost("sync-countries")]
    public async Task<IActionResult> SyncCountries(CancellationToken cancellationToken = default)
    {
        await syncService.SyncCountriesData(cancellationToken);
        return Ok();
    }
}