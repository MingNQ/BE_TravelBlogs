using Ardalis.Specification;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.Blog;
using TravelBlogs.Core.Domain.Entities.Catalog;

namespace TravelBlogs.Core.Application.Cqrs.BlogRequests.Specs;

public sealed class BlogRequestByIdSpec : Specification<Blog, BlogDto>
{
    public BlogRequestByIdSpec(long blogId)
    {
        Query.Where(x => x.Id == blogId);

        Query.Include(x => x.Author);

        Query.Include(x => x.Category);

        Query.Include(x => x.Destination);
    }
}