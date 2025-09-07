using MediatR;
using TravelBlogs.Core.Application.Common.Models;
using TravelBlogs.Core.Application.Common.Persistences;
using TravelBlogs.Core.Application.Common.Services;
using TravelBlogs.Core.Application.Cqrs.Categories.Params;
using TravelBlogs.Core.Application.Cqrs.Categories.Specs;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.Categories;
using TravelBlogs.Core.Domain.Entities.Catalog;

namespace TravelBlogs.Core.Application.Cqrs.Categories.Queries;

public class GetCategoryByConditionQuery : SearchCategoryParam, IRequest<PaginationResponse<CategoryDto>>;

public class GetCategoryByConditionQueryHandler(
    IReadRepository<Category> categoryRepository,
    IPaginationService paginationService)
    : IRequestHandler<GetCategoryByConditionQuery, PaginationResponse<CategoryDto>>
{
    public async Task<PaginationResponse<CategoryDto>> Handle(GetCategoryByConditionQuery request, CancellationToken cancellationToken)
    {
        var spec = new CategoryByConditionSpec(request);
        var result = await paginationService.PaginatedListAsync(
            categoryRepository,
            spec,
            request.PageNumber,
            request.PageSize,
            cancellationToken);

        return result;
    }
}