using Ardalis.Specification;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.Feedback;
using TravelBlogs.Core.Domain.Entities.Catalog;

namespace TravelBlogs.Core.Application.Cqrs.Feedbacks.Specs;

public class FeedbackByIdSpec : Specification<Feedback, FeedbackDto>
{
    public FeedbackByIdSpec(long id)
    {
        Query.Where(x => x.Id == id);

        Query.Include(x => x.Blog);
        Query.Include(x => x.User);
    }
}