using Ardalis.Specification;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.Blog;
using TravelBlogs.Core.Domain.Entities.Catalog;

namespace TravelBlogs.Core.Application.Cqrs.Blogs.Specs;

public class BlogByIdSpec : Specification<Blog, BlogDto>
{
    public BlogByIdSpec(long id)
    {
        Query.Where(x => x.Id == id);

        Query.Include(x => x.Author);
        Query.Include(x => x.Category);
        Query.Include(x => x.Comments);
        Query.Include(x => x.Destination);
        Query.Include(x => x.Thumbnail);
    }
}