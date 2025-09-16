using TravelBlogs.Core.Application.Common.Models;

namespace TravelBlogs.Core.Application.Cqrs.FeedbackDocuments.Params;

public class SearchFeedbackDocumentParam : PaginationFilter
{
    public long? FeedbackId { get; set; }
    public long? FileStorageId { get; set; }
}




