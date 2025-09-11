using System.Text.Json.Serialization;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TravelBlogs.Core.Application.Common.Exceptions;
using TravelBlogs.Core.Application.Common.Repositories;
using TravelBlogs.Core.Application.Common.UnitOfWork;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.Blog;
using TravelBlogs.Core.Domain.Entities.Catalog;
using TravelBlogs.Core.Shared.Constants;

namespace TravelBlogs.Core.Application.Cqrs.Blogs.Commands;

public class UpdateBlogCommand : BlogCommand, IRequest<BlogDto>
{
    [JsonIgnore]
    public long Id { get; private set; }
    public void SetId(long id)
    {
        Id = id;
    }
    public List<BlogAttachmentCommand> BlogAttachments { get; set; } = [];
}

public class UpdateBlogCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateBlogCommand, BlogDto>
{
    private readonly IWriteRepository<Blog> _blogRepository = unitOfWork.GetRepository<Blog>();

    public async Task<BlogDto> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
    {
        var blog = await _blogRepository.GetFirstOrDefaultAsync(
            predicate: x => x.Id == request.Id,
            include: x => x.Include(b => b.Author)
                            .Include(b => b.Category)
                            .Include(b => b.Destination)
                            .Include(b => b.Thumbnail)
                            .Include(b => b.BlogAttachments),
            disableTracking: false)
            ?? throw new NotFoundException(MessageCommon.SetEntityNotFound(nameof(Blog), request.Id));

        blog.Update(
            request.Title,
            request.Description,
            request.Content,
            request.TimeRead,
            request.Status,
            request.CategoryId,
            request.DestinationId,
            request.ThumbnailId);
        blog.UpdateBlogAttachments(request.BlogAttachments.Select(x => BlogAttachment.Create(blog.Id, x.FileStorageId)).ToList());

        _blogRepository.Update(blog);
        await unitOfWork.SaveChangesAsync();

        return blog.Adapt<BlogDto>();
    }
}