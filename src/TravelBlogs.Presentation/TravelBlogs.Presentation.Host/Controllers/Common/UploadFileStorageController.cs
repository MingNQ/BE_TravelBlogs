using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using TravelBlogs.Core.Application.Cqrs.FileStorages.Commands;
using TravelBlogs.Core.Shared.Constants;
using TravelBlogs.Presentation.Host.Controllers.Base;

namespace TravelBlogs.Presentation.Host.Controllers.Common;

[ControllerName("upload-file")]
[Tags("Common|Upload File Storage")]
public class UploadSingleFileStorageController : BaseAuthController
{
    [HttpPost("single")]
    public async Task<IActionResult> UploadSingleFileAsync(UploadSingleFileCommand request)
    {
        var result = await Mediator.Send(request);

        return Ok(result, MessageCommon.UploadSuccess);
    }

    [HttpPost("multiple")]
    public async Task<IActionResult> UploadMultipleFileAsync(UploadMultipleFileCommand request)
    {
        var result = await Mediator.Send(request);
        return Ok(result, MessageCommon.UploadSuccess);
    }
}