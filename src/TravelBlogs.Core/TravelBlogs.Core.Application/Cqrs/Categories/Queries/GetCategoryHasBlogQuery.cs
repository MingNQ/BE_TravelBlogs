using MediatR;
using TravelBlogs.Core.Application.Common.Persistences;
using TravelBlogs.Core.Application.Cqrs.Categories.Specs;
using TravelBlogs.Core.Application.Dto.Integrates.Catalog;
using TravelBlogs.Core.Domain.Entities.Catalog;

namespace TravelBlogs.Core.Application.Cqrs.Categories.Queries;

public class GetCategoryHasBlogQuery : IRequest<List<CategoryExternalDto>>;

public class GetCategoryHasBlogQueryHandler(
    IReadRepository<Category> categoryRepository)
    : IRequestHandler<GetCategoryHasBlogQuery, List<CategoryExternalDto>>
{
    public async Task<List<CategoryExternalDto>> Handle(GetCategoryHasBlogQuery request, CancellationToken cancellationToken)
    {
        var spec = new CategoryHasBlogSpec();
        var result = await categoryRepository.ListAsync(spec, cancellationToken);
        return result;
    }
}