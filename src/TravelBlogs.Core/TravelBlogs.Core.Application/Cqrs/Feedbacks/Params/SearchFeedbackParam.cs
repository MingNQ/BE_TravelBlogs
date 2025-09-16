using TravelBlogs.Core.Application.Common.Models;

namespace TravelBlogs.Core.Application.Cqrs.Feedbacks.Params;

public class SearchFeedbackParam : PaginationFilter
{
    public long? BlogId { get; set; }
    public long? UserId { get; set; }
}

