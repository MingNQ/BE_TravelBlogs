using TravelBlogs.Core.Application.Dto.Persistence.Catalog.Blog;

namespace TravelBlogs.Core.Application.Interfaces.Services;

public interface IBlogRequestService
{
    Task<CreateExternalBlogResponse> CreateBlogRequestAsync(CreateBlogRequestDto request, CancellationToken cancellationToken = default);
    Task<BlogDto> CancelBlogRequestAsync(long blogId, CancellationToken cancellationToken = default);
    Task<BlogDto> ApprovalBlogRequestAsync(long blogId, long? approverId = null, CancellationToken cancellationToken = default);
    Task<BlogDto> RejectBlogRequestAsync(long blogId, long? rejectorId = null, CancellationToken cancellationToken = default);
}