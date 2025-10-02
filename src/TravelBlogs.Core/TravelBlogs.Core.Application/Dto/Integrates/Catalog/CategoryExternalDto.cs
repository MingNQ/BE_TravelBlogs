using TravelBlogs.Core.Application.Common.Interfaces;

namespace TravelBlogs.Core.Application.Dto.Integrates.Catalog;

public class CategoryExternalDto : IDto
{
	public long Id { get; set; }
	public string Name { get; set; } = string.Empty;
}