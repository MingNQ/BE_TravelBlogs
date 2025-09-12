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
    public float Rating { get; private set; }
    public int TimeRead { get; private set; }
    public BlogStatusEnum Status { get; private set; }
    public long AuthorId { get; private set; }
    public long CategoryId { get; private set; }
    public long DestinationId { get; private set; }
    public long? ThumbnailId { get; private set; }
    private readonly List<BlogAttachment> _blogAttachments = [];
    public IReadOnlyCollection<BlogAttachment> BlogAttachments => _blogAttachments.AsReadOnly();
    public virtual User? Author { get; set; }
    public virtual Category? Category { get; set; }
    public virtual Destination? Destination { get; set; }
    public virtual FileStorage? Thumbnail { get; set; }

    public static Blog Create(
        string title,
        string? description,
        string content,
        float rating,
        int timeRead,
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
            Rating = rating,
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
        int timeRead,
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

    public void AddAttachments(List<BlogAttachment> blogAttachments)
    {
        _blogAttachments.AddRange(blogAttachments);
    }

    public void UpdateBlogAttachments(List<BlogAttachment> blogAttachments)
    {
        throw new NotImplementedException();
    }
}