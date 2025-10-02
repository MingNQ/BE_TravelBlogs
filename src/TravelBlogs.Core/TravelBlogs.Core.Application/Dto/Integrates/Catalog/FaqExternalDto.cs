using TravelBlogs.Core.Application.Common.Interfaces;

namespace TravelBlogs.Core.Application.Dto.Integrates.Catalog;

public class FaqExternalDto : IDto
{
	public long Id { get; set; }
    public string Question { get; set; } = string.Empty;
	public string Answer { get; set; } = string.Empty;
}