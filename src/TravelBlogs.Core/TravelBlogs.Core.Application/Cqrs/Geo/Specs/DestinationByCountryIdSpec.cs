using Ardalis.Specification;
using TravelBlogs.Core.Application.Dto.Integrates.Geo;
using TravelBlogs.Core.Domain.Entities.Geo;

namespace TravelBlogs.Core.Application.Cqrs.Geo.Specs;

public class DestinationByCountryIdSpec : Specification<Destination, DestinationDto>
{
    public DestinationByCountryIdSpec(long countryId)
    {
        Query.Where(x => x.CountryId == countryId);
    }
}