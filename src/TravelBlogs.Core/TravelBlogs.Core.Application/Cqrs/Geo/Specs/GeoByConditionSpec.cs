using Ardalis.Specification;
using System.Linq;
using TravelBlogs.Core.Application.Dto.Integrates.Geo;
using TravelBlogs.Core.Domain.Entities.Geo;

namespace TravelBlogs.Core.Application.Cqrs.Geo.Specs;

public sealed class CountryForExternalSpec : Specification<Country, CountryDto>
{
	public CountryForExternalSpec()
	{
		Query.Select(x => new CountryDto
		{
			Id = x.Id,
			Country = x.Name,
			Iso2 = x.Iso2,
			Iso3 = x.Iso3,
			Cities = x.Cities.Select(c => c.Name).ToList()
		});
	}
}

public sealed class DestinationByCountrySpec : Specification<Destination, DestinationDto>
{
	public DestinationByCountrySpec(long countryId)
	{
        Query.Where(x => x.CountryId == countryId);
        Query.Select(x => new DestinationDto
        {
            Id = x.Id,
            Name = x.Name,
            CountryId = x.CountryId
        });
	}
}