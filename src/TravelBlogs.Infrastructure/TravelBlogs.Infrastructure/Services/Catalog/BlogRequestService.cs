using Mapster;
using Microsoft.EntityFrameworkCore;
using TravelBlogs.Core.Application.Common.Exceptions;
using TravelBlogs.Core.Application.Common.Repositories;
using TravelBlogs.Core.Application.Common.UnitOfWork;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.Blog;
using TravelBlogs.Core.Application.Interfaces.Services;
using TravelBlogs.Core.Domain.Common.Enums;
using TravelBlogs.Core.Domain.Entities.Catalog;
using TravelBlogs.Core.Shared.Constants;

namespace TravelBlogs.Infrastructure.Services.Catalog;

public class BlogRequestService(
    IUnitOfWork unitOfWork) : IBlogRequestService
{
    IWriteRepository<Blog> _blogRepository = unitOfWork.GetRepository<Blog>();

    public async Task<CreateExternalBlogResponse> CreateBlogRequestAsync(CreateBlogRequestDto request, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);

        var blog = Blog.Create(
            request.Title,
            request.Description,
            request.Content,
            request.TimeRead,
            BlogStatusEnum.InReview,
            request.AuthorId,
            request.CategoryId,
            request.DestinationId,
            request.ThumbnailId);

        await _blogRepository.InsertAsync(blog, cancellationToken);
        await unitOfWork.SaveChangesAsync();

        return blog.Adapt<CreateExternalBlogResponse>();
    }

    public async Task<BlogDto> ApprovalBlogRequestAsync(long blogId, long? approverId = null, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(blogId);

        var blog = await _blogRepository.GetFirstOrDefaultAsync(
            predicate: b => b.Id == blogId,
            include: b => b.Include(b => b.Category!).Include(b => b.Destination!).Include(b => b.Author!),
            disableTracking: false);

        if (blog == null)
        {
            throw new NotFoundException(MessageCommon.SetEntityNotFound(nameof(Blog), blogId));
        }

        blog.Approve(approverId);

        _blogRepository.Update(blog);
        await unitOfWork.SaveChangesAsync();

        return blog.Adapt<BlogDto>();
    }

    public async Task<BlogDto> CancelBlogRequestAsync(long blogId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(blogId);

        var blog = await _blogRepository.GetFirstOrDefaultAsync(
            predicate: b => b.Id == blogId,
            include: b => b.Include(b => b.Category!).Include(b => b.Destination!).Include(b => b.Author!),
            disableTracking: false);

        if (blog == null)
        {
            throw new NotFoundException(MessageCommon.SetEntityNotFound(nameof(Blog), blogId));
        }

        blog.Cancel();

        _blogRepository.Update(blog);
        await unitOfWork.SaveChangesAsync();

        return blog.Adapt<BlogDto>();
    }

    public async Task<BlogDto> RejectBlogRequestAsync(long blogId, long? rejectorId = null, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(blogId);

        var blog = await _blogRepository.GetFirstOrDefaultAsync(
            predicate: b => b.Id == blogId,
            include: b => b.Include(b => b.Category!).Include(b => b.Destination!).Include(b => b.Author!),
            disableTracking: false);

        if (blog == null)
        {
            throw new NotFoundException(MessageCommon.SetEntityNotFound(nameof(Blog), blogId));
        }

        blog.Reject(rejectorId);

        _blogRepository.Update(blog);
        await unitOfWork.SaveChangesAsync();

        return blog.Adapt<BlogDto>();
    }
}