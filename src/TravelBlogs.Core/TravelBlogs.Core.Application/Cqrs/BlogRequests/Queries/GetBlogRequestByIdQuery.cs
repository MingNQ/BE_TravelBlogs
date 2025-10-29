using Mapster;
using MediatR;
using TravelBlogs.Core.Application.Common.Exceptions;
using TravelBlogs.Core.Application.Common.Persistences;
using TravelBlogs.Core.Application.Cqrs.BlogRequests.Specs;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.Blog;
using TravelBlogs.Core.Domain.Entities.Catalog;
using TravelBlogs.Core.Shared.Constants;

namespace TravelBlogs.Core.Application.Cqrs.BlogRequests.Queries;

public class GetBlogRequestByIdQuery : IRequest<BlogDto>
{
    public long BlogId { get; set; }
}

public class GetBlogRequestByIdQueryHandler(
    IReadRepository<Blog> blogRepository)
    : IRequestHandler<GetBlogRequestByIdQuery, BlogDto>
{
    public async Task<BlogDto> Handle(GetBlogRequestByIdQuery request, CancellationToken cancellationToken)
    {
        var spec = new BlogRequestByIdSpec(request.BlogId);
        var blog = await blogRepository.FirstOrDefaultAsync(spec, cancellationToken)
            ?? throw new NotFoundException(MessageCommon.SetEntityNotFound(nameof(Blog), request.BlogId));
        return blog;
    }
}