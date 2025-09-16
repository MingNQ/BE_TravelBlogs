using TravelBlogs.Core.Domain.Common.Contracts;
using TravelBlogs.Core.Domain.Common.Enums;
using TravelBlogs.Core.Domain.Entities.Identity;

namespace TravelBlogs.Core.Domain.Entities.Catalog;

public class Feedback : AuditableEntity<long>
{
    public FeedbackTypeEnum Type { get; private set; }
    public FeedbackRegardingEnum Regarding { get; private set; }
    public FeedbackStatusEnum Status { get; private set; }
    public string Content { get; private set; } = string.Empty;
    public long BlogId { get; private set; }
    public long UserId { get; private set; }
    
    private readonly List<FeedbackDocument> _feedbackDocuments = [];
    public IReadOnlyCollection<FeedbackDocument> FeedbackDocuments => _feedbackDocuments.AsReadOnly();
    
    public virtual Blog? Blog { get; set; }
    public virtual User? User { get; set; }

    public static Feedback Create(
        FeedbackTypeEnum type,
        FeedbackRegardingEnum regarding,
        FeedbackStatusEnum status,
        string content,
        long blogId,
        long userId)
    {
        return new Feedback
        {
            Type = type,
            Regarding = regarding,
            Status = status,
            Content = content,
            BlogId = blogId,
            UserId = userId
        };
    }

    public void Update(
        FeedbackTypeEnum type,
        FeedbackRegardingEnum regarding,
        FeedbackStatusEnum status,
        string content)
    {
        Type = type;
        Regarding = regarding;
        Status = status;
        Content = content;
    }

    public void UpdateStatus(FeedbackStatusEnum status)
    {
        Status = status;
    }

    public void UpdateContent(string content)
    {
        Content = content;
    }

    public void AddDocuments(List<FeedbackDocument> feedbackDocuments)
    {
        _feedbackDocuments.AddRange(feedbackDocuments);
    }

    public void UpdateFeedbackDocuments(List<FeedbackDocument> feedbackDocuments)
    {
        _feedbackDocuments.Clear();
        _feedbackDocuments.AddRange(feedbackDocuments);
    }
}
