using MediatR;
using TravelBlogs.Core.Application.Common.Models;
using TravelBlogs.Core.Application.Common.Persistences;
using TravelBlogs.Core.Application.Common.Services;
using TravelBlogs.Core.Application.Cqrs.Blogs.Params;
using TravelBlogs.Core.Application.Cqrs.Blogs.Specs;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.Blog;
using TravelBlogs.Core.Domain.Entities.Catalog;

namespace TravelBlogs.Core.Application.Cqrs.Blogs.Queries;

public class GetBlogByConditionQuery : SearchBlogParam, IRequest<PaginationResponse<BlogDto>>;

public class GetBlogByConditionQueryHandler(
    IReadRepository<Blog> blogRepository,
    IPaginationService paginationService,
    IFilePathService filePathService)
    : IRequestHandler<GetBlogByConditionQuery, PaginationResponse<BlogDto>>
{
    public async Task<PaginationResponse<BlogDto>> Handle(GetBlogByConditionQuery request, CancellationToken cancellationToken)
    {
        var spec = new BlogByConditionSpec(request);
        var blogs = await paginationService.PaginatedListAsync(
            blogRepository,
            spec,
            request.PageNumber,
            request.PageSize,
            cancellationToken);

        foreach (var blog in blogs.Data)
        {
            if (blog.Thumbnail != null)
            {
                filePathService.BindFullPaths(blog.Thumbnail);
            }
        }

        return blogs;
    }
}