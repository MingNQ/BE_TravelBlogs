using System.Text.Json.Serialization;
using MediatR;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.Blog;
using TravelBlogs.Core.Application.Interfaces.Services;

namespace TravelBlogs.Core.Application.Cqrs.BlogRequests.Commands;

public class RejectBlogRequestCommand : IRequest<BlogDto>
{
    [JsonIgnore]
    public long BlogId { get; set; }
    public long? RejectorId { get; set; }
}

public class RejectBlogRequestCommandHandler(
    IBlogRequestService blogRequestService) 
    : IRequestHandler<RejectBlogRequestCommand, BlogDto>
{
    public async Task<BlogDto> Handle(RejectBlogRequestCommand request, CancellationToken cancellationToken)
    {
        return await blogRequestService.RejectBlogRequestAsync(request.BlogId, request.RejectorId, cancellationToken);
    }
}