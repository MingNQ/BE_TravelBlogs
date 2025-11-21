using Ardalis.Specification;
using TravelBlogs.Core.Application.Common.Specification;
using TravelBlogs.Core.Application.Cqrs.BlogRequests.Params;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.Blog;
using TravelBlogs.Core.Domain.Entities.Catalog;

namespace TravelBlogs.Core.Application.Cqrs.BlogRequests.Specs;

public sealed class BlogRequestByConditionSpec : BaseSpec<Blog, BlogDto>
{
    public BlogRequestByConditionSpec(long id, SearchBlogRequestParam param)
    {
        Query.Where(x => x.AuthorId == id);
    }
}