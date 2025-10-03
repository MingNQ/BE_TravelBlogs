using MediatR;
using TravelBlogs.Core.Application.Common.Persistences;
using TravelBlogs.Core.Application.Cqrs.Categories.Specs;
using TravelBlogs.Core.Application.Dto.Integrates.Catalog;
using TravelBlogs.Core.Domain.Entities.Catalog;

namespace TravelBlogs.Core.Application.Cqrs.Categories.Queries;

public class GetCategoryForExternalQuery : IRequest<List<CategoryExternalDto>>;

public class GetCategoryForExternalQueryHandler(IReadRepository<Category> categoryRepository)
	: IRequestHandler<GetCategoryForExternalQuery, List<CategoryExternalDto>>
{
	public async Task<List<CategoryExternalDto>> Handle(GetCategoryForExternalQuery request, CancellationToken cancellationToken)
	{
		var spec = new CategoryForExternalSpec();
		var list = await categoryRepository.ListAsync(spec, cancellationToken);
		return list;
	}
}