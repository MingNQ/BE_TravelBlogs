using MediatR;
using TravelBlogs.Core.Application.Common.Exceptions;
using TravelBlogs.Core.Application.Common.Persistences;
using TravelBlogs.Core.Application.Cqrs.Blogs.Specs;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.Blog;
using TravelBlogs.Core.Domain.Entities.Catalog;
using TravelBlogs.Core.Shared.Constants;

namespace TravelBlogs.Core.Application.Cqrs.Blogs.Queries;

public class GetBlogByIdQuery : IRequest<BlogDto>
{
    public long Id { get; set; }
}

public class GetBlogByIdQueryHandler(IReadRepository<Blog> blogRepository)
    : IRequestHandler<GetBlogByIdQuery, BlogDto>
{
    public async Task<BlogDto> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
    {
        var spec = new BlogByIdSpec(request.Id);
        var blog = await blogRepository.FirstOrDefaultAsync(spec, cancellationToken)
            ?? throw new NotFoundException(MessageCommon.SetEntityNotFound(nameof(Blog), request.Id));

        return blog;
    }
}