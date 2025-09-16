using TravelBlogs.Core.Application.Common.Interfaces;

namespace TravelBlogs.Core.Application.Dto.Persistence.Catalog.FeedbackDocument;

public class FeedbackDocumentDto : IDto
{
    public long Id { get; set; }
    public long FeedbackId { get; set; }
    public long FileStorageId { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
}


