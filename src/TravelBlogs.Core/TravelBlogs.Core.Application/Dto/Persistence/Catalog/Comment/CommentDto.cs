using TravelBlogs.Core.Application.Common.Interfaces;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.Blog;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.User;

namespace TravelBlogs.Core.Application.Dto.Persistence.Catalog.Comment;

public class CommentDto : IDto
{
    public long Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public long BlogId { get; set; }
    public long UserId { get; set; }
    public long? ParentCommentId { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    public DateTimeOffset? LastModifiedOn { get; set; }
    public ShortBlogInfoDto? Blog { get; set; }
    public SortUserInfo? User { get; set; }
}