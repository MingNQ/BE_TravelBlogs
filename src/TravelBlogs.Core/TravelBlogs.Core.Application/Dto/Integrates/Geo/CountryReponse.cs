namespace TravelBlogs.Core.Application.Dto.Integrates.Geo;

public class CountryReponse
{
    public bool Error { get; set; }
    public string Msg { get; set; } = string.Empty;
    public List<CountryDto> Data { get; set; } = [];
}