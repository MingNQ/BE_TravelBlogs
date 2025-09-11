using TravelBlogs.Core.Application.Common.Specification;
using TravelBlogs.Core.Application.Cqrs.Blogs.Params;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.Blog;
using TravelBlogs.Core.Domain.Entities.Catalog;

namespace TravelBlogs.Core.Application.Cqrs.Blogs.Specs;

public class BlogByConditionSpec(SearchBlogParam param) : BaseSpec<Blog, BlogDto>(param);