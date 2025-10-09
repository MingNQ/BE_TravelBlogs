using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using TravelBlogs.Core.Application.Cqrs.FileStorages.Queries;
using TravelBlogs.Core.Shared.Constants;
using TravelBlogs.Presentation.Host.Controllers.Base;

namespace TravelBlogs.Presentation.Host.Controllers.Common;

[ControllerName("file-storage")]
[Tags("Common|FileStorage")]
public class FileStorageController : BaseNoAuthController
{
    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
    {
        var result = await Mediator.Send(new GetFileStorageByIdQuery
        {
            Id = id
        });

        return Ok(result, MessageCommon.GetDataSuccess);
    }
}