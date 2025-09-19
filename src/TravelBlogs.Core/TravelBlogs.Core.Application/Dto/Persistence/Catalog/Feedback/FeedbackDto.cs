using TravelBlogs.Core.Application.Common.Interfaces;
using TravelBlogs.Core.Domain.Common.Enums;

namespace TravelBlogs.Core.Application.Dto.Persistence.Catalog.Feedback;

public class FeedbackDto : IDto
{
    public long Id { get; set; }
    public FeedbackTypeEnum Type { get; set; }
    public FeedbackRegardingEnum Regarding { get; set; }
    public FeedbackStatusEnum Status { get; set; }
    public string Content { get; set; } = string.Empty;
    public long BlogId { get; set; }
    public long UserId { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
}

