using TravelBlogs.Core.Application.Common.Interfaces;

namespace TravelBlogs.Core.Application.Dto.Integrates.Geo;

public class DestinationDto : IDto
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public long CountryId { get; set; }
}