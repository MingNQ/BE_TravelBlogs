using TravelBlogs.Core.Domain.Common.Contracts;
using TravelBlogs.Core.Domain.Entities.Identity;

namespace TravelBlogs.Core.Domain.Entities.Catalog;

public class Comment : AuditableEntity<long>
{
    public string Content { get; private set; } = string.Empty;
    public long BlogId { get; private set; }
    public virtual Blog? Blog { get; private set; } = null!;
    public long UserId { get; private set; }
    public virtual User? User { get; private set; } = null!;
    public long? ParentCommentId { get; private set; }
    public virtual Comment? ParentComment { get; private set; } = null!;

    public static Comment Create(string content, long blogId, long userId, long? parentCommentId = null)
    {
        return new Comment
        {
            Content = content,
            BlogId = blogId,
            UserId = userId,
            ParentCommentId = parentCommentId
        };
    }

    public void Update(string content)
    {
        Content = content;
    }
}