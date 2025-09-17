using TravelBlogs.Core.Domain.Common.Contracts;
using TravelBlogs.Core.Domain.Entities.Common;

namespace TravelBlogs.Core.Domain.Entities.Catalog;

public class FeedbackDocument : AuditableEntity<long>
{
    public long FeedbackId { get; private set; }
    public long FileStorageId { get; private set; }
    
    public virtual Feedback? Feedback { get; set; }
    public virtual FileStorage? FileStorage { get; set; }

    public static FeedbackDocument Create(
        long feedbackId,
        long fileStorageId)
    {
        return new FeedbackDocument
        {
            FeedbackId = feedbackId,
            FileStorageId = fileStorageId
        };
    }

    public void Update(long fileStorageId)
    {
        FileStorageId = fileStorageId;
    }
}