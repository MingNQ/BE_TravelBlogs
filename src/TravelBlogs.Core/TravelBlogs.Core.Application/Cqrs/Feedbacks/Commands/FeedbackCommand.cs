using TravelBlogs.Core.Domain.Common.Enums;

namespace TravelBlogs.Core.Application.Cqrs.Feedbacks.Commands;

public class FeedbackCommand
{
    public FeedbackTypeEnum Type { get; set; }
    public FeedbackRegardingEnum Regarding { get; set; }
    public FeedbackStatusEnum Status { get; set; }
    public string Content { get; set; } = string.Empty;
    public long BlogId { get; set; }
    public long UserId { get; set; }
}

