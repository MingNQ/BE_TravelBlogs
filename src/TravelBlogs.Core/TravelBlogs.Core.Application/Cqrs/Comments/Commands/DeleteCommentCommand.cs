using MediatR;
using TravelBlogs.Core.Application.Common.Exceptions;
using TravelBlogs.Core.Application.Common.Repositories;
using TravelBlogs.Core.Application.Common.UnitOfWork;
using TravelBlogs.Core.Domain.Entities.Catalog;
using TravelBlogs.Core.Shared.Constants;

namespace TravelBlogs.Core.Application.Cqrs.Comments.Commands;

public class DeleteCommentCommand : IRequest<long>
{
    public long Id { get; set; }
}

public class DeleteCommentCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteCommentCommand, long>
{
    private readonly IWriteRepository<Comment> _commentRepository = unitOfWork.GetRepository<Comment>();

    public async Task<long> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = await _commentRepository.GetFirstOrDefaultAsync(
            predicate: x => x.Id == request.Id,
            disableTracking: false)
            ?? throw new NotFoundException(MessageCommon.SetEntityNotFound(nameof(Comment), request.Id));
        
        _commentRepository.Delete(comment);
        await unitOfWork.SaveChangesAsync();

        return request.Id;
    }
}