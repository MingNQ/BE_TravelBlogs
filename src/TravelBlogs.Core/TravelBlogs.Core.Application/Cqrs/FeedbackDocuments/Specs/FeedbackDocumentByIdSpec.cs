using Ardalis.Specification;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.FeedbackDocument;
using TravelBlogs.Core.Domain.Entities.Catalog;

namespace TravelBlogs.Core.Application.Cqrs.FeedbackDocuments.Specs;

public class FeedbackDocumentByIdSpec : Specification<FeedbackDocument, FeedbackDocumentDto>
{
    public FeedbackDocumentByIdSpec(long id)
    {
        Query.Where(x => x.Id == id);
        Query.Include(x => x.Feedback);
        Query.Include(x => x.FileStorage);
    }
}