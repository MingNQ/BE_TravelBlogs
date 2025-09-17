namespace TravelBlogs.Core.Application.Cqrs.FeedbackDocuments.Commands;

public class FeedbackDocumentCommand
{
    public long FeedbackId { get; set; }
    public long FileStorageId { get; set; }
}