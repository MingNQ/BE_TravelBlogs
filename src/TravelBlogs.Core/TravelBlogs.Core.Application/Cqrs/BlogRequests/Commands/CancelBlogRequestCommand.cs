using System.Text.Json.Serialization;
using MediatR;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.Blog;
using TravelBlogs.Core.Application.Interfaces.Services;

namespace TravelBlogs.Core.Application.Cqrs.BlogRequests.Commands;

public class CancelBlogRequestCommand : IRequest<BlogDto>
{
    [JsonIgnore]
    public long BlogId { get; set; }
}

public class CancelBlogRequestCommandHandler(IBlogRequestService blogRequestService)
    : IRequestHandler<CancelBlogRequestCommand, BlogDto>
{
    public async Task<BlogDto> Handle(CancelBlogRequestCommand request, CancellationToken cancellationToken)
    {
        return await blogRequestService.CancelBlogRequestAsync(request.BlogId, cancellationToken);
    }
}