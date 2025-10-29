using TravelBlogs.Core.Application.Common.Specification;
using TravelBlogs.Core.Application.Cqrs.BlogRequests.Params;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.Blog;
using TravelBlogs.Core.Domain.Entities.Catalog;

namespace TravelBlogs.Core.Application.Cqrs.BlogRequests.Specs;

public class BlogRequestByConditionSpec(SearchBlogRequestParam param) : BaseSpec<Blog, BlogDto>(param); 