using TravelBlogs.Core.Domain.Common.Enums;

namespace TravelBlogs.Core.Application.Cqrs.Blogs.Commands;

public class BlogCommand
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public int? TimeRead { get; set; }
    public BlogStatusEnum Status { get; set; }
    public long CategoryId { get; set; }
    public long DestinationId { get; set; }
    public long? ThumbnailId { get; set; }
}