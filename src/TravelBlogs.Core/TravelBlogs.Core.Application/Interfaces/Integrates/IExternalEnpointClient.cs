using TravelBlogs.Core.Application.Dto.Integrates.Geo;

namespace TravelBlogs.Core.Application.Interfaces.Integrates;

public interface IExternalEnpointClient
{
    Task<List<CountryDto>> GetAllCountries();
}