using MediatR;
using Microsoft.EntityFrameworkCore;
using TravelBlogs.Core.Application.Common.Exceptions;
using TravelBlogs.Core.Application.Common.Repositories;
using TravelBlogs.Core.Application.Common.UnitOfWork;
using TravelBlogs.Core.Domain.Entities.Catalog;
using TravelBlogs.Core.Shared.Constants;

namespace TravelBlogs.Core.Application.Cqrs.Blogs.Commands;

public class DeleteBlogCommand : IRequest<long>
{
    public long Id { get; set; }
}

public class DeleteBlogCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteBlogCommand, long>
{
    private readonly IWriteRepository<Blog> _blogRepository = unitOfWork.GetRepository<Blog>();

    public async Task<long> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
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

        _blogRepository.Delete(blog);
        await unitOfWork.SaveChangesAsync();

        return request.Id;
    }
}