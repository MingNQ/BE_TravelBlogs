using MediatR;
using TravelBlogs.Core.Application.Common.Persistences;
using TravelBlogs.Core.Application.Cqrs.Geo.Specs;
using TravelBlogs.Core.Application.Dto.Integrates.Geo;
using TravelBlogs.Core.Domain.Entities.Geo;

namespace TravelBlogs.Core.Application.Cqrs.Geo.Queries;

public class GetDestinationByCountryIdQuery(long countryId) : IRequest<List<DestinationDto>>
{
    public long CountryId { get; } = countryId;
}

public class GetDestinationByCountryIdQueryHandler(IReadRepository<Destination> repository)
    : IRequestHandler<GetDestinationByCountryIdQuery, List<DestinationDto>>
{
    public async Task<List<DestinationDto>> Handle(GetDestinationByCountryIdQuery request, CancellationToken cancellationToken)
    {
        var spec = new DestinationByCountryIdSpec(request.CountryId);
        var list = await repository.ListAsync(spec, cancellationToken);
        return list;
    }
}