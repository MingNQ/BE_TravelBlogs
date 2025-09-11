using TravelBlogs.Core.Domain.Common.Contracts;
using TravelBlogs.Core.Domain.Entities.Common;

namespace TravelBlogs.Core.Domain.Entities.Catalog;

public class BlogAttachment : AuditableEntity<long>
{
    public long BlogId { get; private set; }
    public long FileStorageId { get; private set; }
    public virtual Blog? Blog { get; set; }
    public virtual FileStorage? FileStorage { get; set; }

    public static BlogAttachment Create(
        long blogId,
        long fileStorageId)
    {
        return new BlogAttachment
        {
            BlogId = blogId,
            FileStorageId = fileStorageId
        };
    }

    public void Update(long fileStorageId)
    {
        FileStorageId = fileStorageId;
    }
}