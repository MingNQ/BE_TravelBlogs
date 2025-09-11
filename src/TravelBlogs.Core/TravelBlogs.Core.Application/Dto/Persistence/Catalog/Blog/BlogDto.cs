using TravelBlogs.Core.Application.Common.Interfaces;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.BlogAttachment;
using TravelBlogs.Core.Domain.Common.Enums;

namespace TravelBlogs.Core.Application.Dto.Persistence.Catalog.Blog;

public class BlogDto : IDto
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public float Rating { get; set; }
    public int TimeRead { get; set; }
    public BlogStatusEnum Status { get; set; }
    public long AuthorId { get; set; }
    public long CategoryId { get; set; }
    public long DestinationId { get; set; }
    public long ThumbnailId { get; set; }
    public List<BlogAttachmentDto> BlogAttachments { get; set; } = [];
    public DateTimeOffset CreatedOn { get; set; }
}