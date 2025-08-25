using System.Text.Json;
using Microsoft.Extensions.Options;
using TravelBlogs.Core.Application.Configurations;
using TravelBlogs.Core.Application.Dto.Integrates.Geo;
using TravelBlogs.Core.Application.Interfaces.Integrates;

namespace TravelBlogs.Infrastructure.ExternalService;

public class ExternalEnpointClient(HttpClient httpClient, IOptions<ExternalUriSettings> options) 
    : IExternalEnpointClient
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly ExternalUriSettings _externalUriSettings = options.Value;

    public async Task<List<CountryDto>> GetAllCountries()
    {
        var response = await _httpClient.GetStringAsync(_externalUriSettings.CountriesEndpoint);
        var countries = JsonSerializer.Deserialize<CountryReponse>(response
            , new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        return countries?.Data ?? [];
    }
}
