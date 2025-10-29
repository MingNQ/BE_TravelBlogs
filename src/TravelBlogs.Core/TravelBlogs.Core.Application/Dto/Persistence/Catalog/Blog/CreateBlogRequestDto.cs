namespace TravelBlogs.Core.Application.Dto.Persistence.Catalog.Blog;

public class CreateBlogRequestDto
{
    public long AuthorId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public int? TimeRead { get; set; }
    public long CategoryId { get; set; }
    public long DestinationId { get; set; }
    public long? ThumbnailId { get; set; }
}