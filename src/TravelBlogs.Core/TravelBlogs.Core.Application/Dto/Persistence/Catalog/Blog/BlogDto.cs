using TravelBlogs.Core.Application.Common.Interfaces;
using TravelBlogs.Core.Application.Dto.Integrates.Geo;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.Categories;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.Comment;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.FileStorages;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.User;
using TravelBlogs.Core.Domain.Common.Enums;

namespace TravelBlogs.Core.Application.Dto.Persistence.Catalog.Blog;

public class BlogDto : IDto
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public float Rating { get; set; }
    public int TimeRead { get; set; }
    public BlogStatusEnum Status { get; set; }
    public long AuthorId { get; set; }
    public long CategoryId { get; set; }
    public long DestinationId { get; set; }
    public long ThumbnailId { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    public List<CommentDto> Comments { get; set; } = [];
    public SortUserInfo? Author { get; set; }
    public CategoryDto? Category { get; set; }
    public DestinationDto? Destination { get; set; }
    public FileStorageDto? Thumbnail { get; set; }
}

public class ShortBlogInfoDto
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public float Rating { get; set; }
    public BlogStatusEnum Status { get; set; }
    public long AuthorId { get; set; }
    public long CategoryId { get; set; }
    public long DestinationId { get; set; }
    public SortUserInfo? Author { get; set; }
    public CategoryDto? Category { get; set; }
    public DestinationDto? Destination { get; set; }
}

public class CreateExternalBlogResponse
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public float Rating { get; set; }
    public int TimeRead { get; set; }
    public BlogStatusEnum Status { get; set; }
    public long AuthorId { get; set; }
    public long CategoryId { get; set; }
    public long DestinationId { get; set; }
    public long ThumbnailId { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    public CategoryDto? Category { get; set; }
    public DestinationDto? Destination { get; set; }
}