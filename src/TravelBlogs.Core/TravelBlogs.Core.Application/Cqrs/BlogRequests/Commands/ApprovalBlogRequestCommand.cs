using System.Text.Json.Serialization;
using MediatR;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.Blog;
using TravelBlogs.Core.Application.Interfaces.Services;

namespace TravelBlogs.Core.Application.Cqrs.BlogRequests.Commands;

public class ApprovalBlogRequestCommand : IRequest<BlogDto>
{
    [JsonIgnore]
    public long BlogId { get; set; }
    public long? ApproverId { get; set; }
}

public class ApprovalBlogRequestCommandHandler(
    IBlogRequestService blogRequestService) 
    : IRequestHandler<ApprovalBlogRequestCommand, BlogDto>
{
    public async Task<BlogDto> Handle(ApprovalBlogRequestCommand request, CancellationToken cancellationToken)
    {
        return await blogRequestService.ApprovalBlogRequestAsync(request.BlogId, request.ApproverId, cancellationToken);    
    }
}