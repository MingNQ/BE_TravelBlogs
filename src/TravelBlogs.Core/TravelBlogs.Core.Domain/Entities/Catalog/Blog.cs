using TravelBlogs.Core.Domain.Common.Contracts;
using TravelBlogs.Core.Domain.Common.Enums;
using TravelBlogs.Core.Domain.Entities.Common;
using TravelBlogs.Core.Domain.Entities.Geo;
using TravelBlogs.Core.Domain.Entities.Identity;

namespace TravelBlogs.Core.Domain.Entities.Catalog;

public class Blog : AuditableEntity<long>
{
    public string Title { get; private set; } = string.Empty;
    public string? Description { get; private set; } = string.Empty;
    public string Content { get; private set; } = string.Empty;
    public float? Rating { get; private set; }
    public int? TimeRead { get; private set; }
    public BlogStatusEnum Status { get; private set; }
    public long AuthorId { get; private set; }
    public long CategoryId { get; private set; }
    public long DestinationId { get; private set; }
    public long? ThumbnailId { get; private set; }
    public long? ApproverId { get; private set; }
    public long? RejectorId { get; private set; }
    private readonly List<Feedback> _feedbacks = [];
    public IReadOnlyCollection<Feedback> Feedbacks => _feedbacks.AsReadOnly();
    private readonly List<Comment> _comments = [];
    public IReadOnlyCollection<Comment> Comments => _comments.AsReadOnly();
    public virtual User? Author { get; set; }
    public virtual User? Approver { get; set; }
    public virtual User? Rejector { get; set; }
    public virtual Category? Category { get; set; }
    public virtual Destination? Destination { get; set; }
    public virtual FileStorage? Thumbnail { get; set; }

    public static Blog Create(
        string title,
        string? description,
        string content,
        int? timeRead,
        BlogStatusEnum status,
        long authorId,
        long categoryId,
        long destinationId,
        long? thumbnaiId)
    {
        return new Blog
        {
            Title = title,
            Description = description,
            Content = content,
            TimeRead = timeRead,
            Status = status,
            AuthorId = authorId,
            CategoryId = categoryId,
            DestinationId = destinationId,
            ThumbnailId = thumbnaiId,
        };
    }

    public void Update(
        string title,
        string? description,
        string content,
        int? timeRead,
        BlogStatusEnum status,
        long categoryId,
        long destinationId,
        long? thumbnaiId)
    {
        Title = title;
        Description = description;
        Content = content;
        TimeRead = timeRead;
        Status = status;
        CategoryId = categoryId;
        DestinationId = destinationId;
        ThumbnailId = thumbnaiId;
    }

    public void UpdateAuthor(long authorId)
    {
        AuthorId = authorId;
    }

    public void UpdateRating(float rating)
    {
        Rating = rating;
    }

    public void Approve(long? approverId)
    {
        if (Status == BlogStatusEnum.InReview)
        {
            Status = BlogStatusEnum.Approved;
            ApproverId = approverId;
        }
    }

    public void Reject(long? rejectorId)
    {
        if (Status == BlogStatusEnum.InReview)
        {
            Status = BlogStatusEnum.Rejected;
            RejectorId = rejectorId;
        }
    }

    public void Cancel()
    {
        Status = BlogStatusEnum.Cancelled;
    }
}