using MediatR;
using TravelBlogs.Core.Application.Common.Persistences;
using TravelBlogs.Core.Application.Cqrs.Geo.Specs;
using TravelBlogs.Core.Application.Dto.Integrates.Geo;
using TravelBlogs.Core.Domain.Entities.Geo;

namespace TravelBlogs.Core.Application.Cqrs.Geo.Queries;

public class GetCountriesQuery : IRequest<List<CountryDto>>;

public class GetCountriesQueryHandler(IReadRepository<Country> repository)
	: IRequestHandler<GetCountriesQuery, List<CountryDto>>
{
	public async Task<List<CountryDto>> Handle(GetCountriesQuery request, CancellationToken cancellationToken)
	{
		var spec = new CountryForExternalSpec();
		var list = await repository.ListAsync(spec, cancellationToken);
		return list;
	}
}
