using MediatR;
using TravelBlogs.Core.Application.Common.Persistences;
using TravelBlogs.Core.Application.Cqrs.Geo.Specs;
using TravelBlogs.Core.Application.Dto.Integrates.Geo;
using TravelBlogs.Core.Domain.Entities.Geo;

namespace TravelBlogs.Core.Application.Cqrs.Geo.Queries;

public class GetDestinationsByCountryQuery(long countryId) : IRequest<List<DestinationDto>>
{
	public long CountryId { get; } = countryId;
}

public class GetDestinationsByCountryQueryHandler(IReadRepository<Destination> repository)
	: IRequestHandler<GetDestinationsByCountryQuery, List<DestinationDto>>
{
	public async Task<List<DestinationDto>> Handle(GetDestinationsByCountryQuery request, CancellationToken cancellationToken)
	{
		var spec = new DestinationByCountrySpec(request.CountryId);
		var list = await repository.ListAsync(spec, cancellationToken);
		return list;
	}
}
