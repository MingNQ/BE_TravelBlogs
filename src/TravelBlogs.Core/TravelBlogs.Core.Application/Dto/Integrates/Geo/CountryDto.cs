using TravelBlogs.Core.Application.Common.Interfaces;

namespace TravelBlogs.Core.Application.Dto.Integrates.Geo;

/// <summary>
/// DTO For Sync Service
/// </summary>
public class CountryDto : IDto
{
    public long Id { get; set; }
    public string Country { get; set; } = string.Empty;
    public string Iso2 { get; set; } = string.Empty;
    public string Iso3 { get; set; } = string.Empty;
    public List<string> Cities { get; set; } = [];
}

/// <summary>
/// DTO for external
/// </summary>
public class CountryInfo : IDto
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Iso2 { get; set; } = string.Empty;
    public string Iso3 { get; set; } = string.Empty;
    public List<DestinationDto> Cities { get; set; } = [];
}