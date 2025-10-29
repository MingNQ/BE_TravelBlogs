using MediatR;
using TravelBlogs.Core.Application.Common.Models;
using TravelBlogs.Core.Application.Common.Persistences;
using TravelBlogs.Core.Application.Common.Services;
using TravelBlogs.Core.Application.Cqrs.BlogRequests.Params;
using TravelBlogs.Core.Application.Cqrs.BlogRequests.Specs;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.Blog;
using TravelBlogs.Core.Domain.Entities.Catalog;

namespace TravelBlogs.Core.Application.Cqrs.BlogRequests.Queries;

public class GetBlogRequestByConditionQuery : SearchBlogRequestParam, IRequest<PaginationResponse<BlogDto>>;

public class GetBlogRequestByConditionQueryHandler(
    IReadRepository<Blog> blogRepository,
    IPaginationService paginationService)
    : IRequestHandler<GetBlogRequestByConditionQuery, PaginationResponse<BlogDto>>
{
    public async Task<PaginationResponse<BlogDto>> Handle(GetBlogRequestByConditionQuery request, CancellationToken cancellationToken)
    {
        var spec = new BlogRequestByConditionSpec(request);
        var result = await paginationService.PaginatedListAsync(
            blogRepository,
            spec,
            request.PageNumber,
            request.PageSize,
            cancellationToken
        );

        return result;
    }
}