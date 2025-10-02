using MediatR;
using TravelBlogs.Core.Application.Common.Persistences;
using TravelBlogs.Core.Application.Cqrs.Categories.Specs;
using TravelBlogs.Core.Application.Dto.Integrates.Catalog;
using TravelBlogs.Core.Domain.Entities.Catalog;

namespace TravelBlogs.Core.Application.Cqrs.Categories.Queries;

public class GetCategoryForExternalQuery : IRequest<List<CategoryExternalDto>>;

public class GetCategoryForExternalQueryHandler(IReadRepository<Category> repo)
	: IRequestHandler<GetCategoryForExternalQuery, List<CategoryExternalDto>>
{
	public async Task<List<CategoryExternalDto>> Handle(GetCategoryForExternalQuery request, CancellationToken ct)
	{
		var spec = new CategoryForExternalSpec();
		var list = await repo.ListAsync(spec, ct);
		return list;
	}
}