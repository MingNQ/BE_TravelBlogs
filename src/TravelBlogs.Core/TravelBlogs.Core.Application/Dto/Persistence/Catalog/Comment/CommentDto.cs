using TravelBlogs.Core.Application.Common.Interfaces;

namespace TravelBlogs.Core.Application.Dto.Persistence.Catalog.Comment;

public class CommentDto : IDto
{
    public long Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public long BlogId { get; set; }
    public long UserId { get; set; }
    public long? ParentCommentId { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}