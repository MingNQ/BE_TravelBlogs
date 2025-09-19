using Ardalis.Specification;
using TravelBlogs.Core.Application.Cqrs.FeedbackDocuments.Params;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.FeedbackDocument;
using TravelBlogs.Core.Domain.Entities.Catalog;

namespace TravelBlogs.Core.Application.Cqrs.FeedbackDocuments.Specs;

public class FeedbackDocumentByConditionSpec : Specification<FeedbackDocument, FeedbackDocumentDto>
{
    public FeedbackDocumentByConditionSpec(SearchFeedbackDocumentParam param)
    {
        if (param.FeedbackId.HasValue)
        {
            Query.Where(x => x.FeedbackId == param.FeedbackId.Value);
        }

        if (param.FileStorageId.HasValue)
        {
            Query.Where(x => x.FileStorageId == param.FileStorageId.Value);
        }

        Query.Include(x => x.Feedback);
        Query.Include(x => x.FileStorage);

        if (!param.IgnorePagination)
        {
            Query.Skip((param.PageNumber - 1) * param.PageSize)
                 .Take(param.PageSize);
        }
    }
}