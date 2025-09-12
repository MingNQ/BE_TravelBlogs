using TravelBlogs.Core.Application.Common.Interfaces;

namespace TravelBlogs.Core.Application.Dto.Persistence.Catalog.BlogAttachment;

public class BlogAttachmentDto : IDto
{
    public long BlogId { get; set; }
    public long FileStorageId { get; set; }
}