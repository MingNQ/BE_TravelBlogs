using TravelBlogs.Core.Application.Common.Interfaces;

namespace TravelBlogs.Core.Application.Dto.Persistence.Catalog.Categories;

public class CategoryDto : IDto
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int NumberOfPosts { get; set; }
}