using Ardalis.Specification;
using TravelBlogs.Core.Application.Cqrs.Feedbacks.Params;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.Feedback;
using TravelBlogs.Core.Domain.Entities.Catalog;

namespace TravelBlogs.Core.Application.Cqrs.Feedbacks.Specs;

public class FeedbackByConditionSpec : Specification<Feedback, FeedbackDto>
{
    public FeedbackByConditionSpec(SearchFeedbackParam param)
    {
        if (param.BlogId.HasValue)
        {
            Query.Where(x => x.BlogId == param.BlogId.Value);
        }

        if (param.UserId.HasValue)
        {
            Query.Where(x => x.UserId == param.UserId.Value);
        }

        Query.Include(x => x.Blog);
        Query.Include(x => x.User);

        // Apply pagination
        if (!param.IgnorePagination)
        {
            Query.Skip((param.PageNumber - 1) * param.PageSize)
                 .Take(param.PageSize);
        }
    }
}
