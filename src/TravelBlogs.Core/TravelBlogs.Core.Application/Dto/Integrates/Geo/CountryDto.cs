using TravelBlogs.Core.Application.Common.Interfaces;

namespace TravelBlogs.Core.Application.Dto.Integrates.Geo;

public class CountryDto : IDto
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<DestinationDto> Destinations { get; set; } = [];
}