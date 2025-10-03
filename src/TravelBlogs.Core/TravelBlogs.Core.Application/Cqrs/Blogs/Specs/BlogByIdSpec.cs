using Ardalis.Specification;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.Blog;
using TravelBlogs.Core.Domain.Entities.Catalog;

namespace TravelBlogs.Core.Application.Cqrs.Blogs.Specs;

public class BlogByIdSpec : Specification<Blog, BlogDto>
{
    public BlogByIdSpec(long id)
    {
        Query.Where(x => x.Id == id);
    }
}