using System.Threading.Tasks;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using TravelBlogs.Core.Application.Cqrs.FeedbackDocuments.Commands;
using TravelBlogs.Core.Application.Cqrs.FeedbackDocuments.Queries;
using TravelBlogs.Core.Shared.Constants;
using TravelBlogs.Presentation.Host.Controllers.Base;

namespace TravelBlogs.Presentation.Host.Controllers.Manager.Catalog;

[ControllerName("feedback-documents")]
[Tags("Manager|Feedback Documents")]
public class FeedbackDocumentsController : BaseAdminAuthController
{
    [HttpPost("search")]
    public async Task<IActionResult> GetAsync([FromBody] GetFeedbackDocumentByConditionQuery request)
    {
        var result = await Mediator.Send(request);
        return Ok(result, MessageCommon.GetDataSuccess);
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetByIdAsync(long id)
    {
        var result = await Mediator.Send(new GetFeedbackDocumentByIdQuery { Id = id });
        return Ok(result, MessageCommon.GetDataSuccess);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateFeedbackDocumentCommand request)
    {
        var result = await Mediator.Send(request);
        return Ok(result, MessageCommon.CreateSuccess);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> UpdateAsync(long id, [FromBody] UpdateFeedbackDocumentCommand request)
    {
        request.SetId(id);
        var result = await Mediator.Send(request);
        return Ok(result, MessageCommon.UpdateSuccess);
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        var result = await Mediator.Send(new DeleteFeedbackDocumentCommand { Id = id });
        return Ok(result, MessageCommon.DeleteSuccess);
    }
}




