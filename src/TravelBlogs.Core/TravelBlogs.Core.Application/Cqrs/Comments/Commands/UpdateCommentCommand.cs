using System.Text.Json.Serialization;
using Mapster;
using MediatR;
using TravelBlogs.Core.Application.Common.Exceptions;
using TravelBlogs.Core.Application.Common.Repositories;
using TravelBlogs.Core.Application.Common.UnitOfWork;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.Comment;
using TravelBlogs.Core.Domain.Entities.Catalog;
using TravelBlogs.Core.Shared.Constants;

namespace TravelBlogs.Core.Application.Cqrs.Comments.Commands;

public class UpdateCommentCommand : CommentBaseCommand, IRequest<CommentDto>
{
    [JsonIgnore]
    public long Id { get; private set; }
    public void SetId(long id)
    {
        Id = id;
    }
}

public class UpdateCommentCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateCommentCommand, CommentDto>
{
    private readonly IWriteRepository<Comment> _commentRepository = unitOfWork.GetRepository<Comment>();

    public async Task<CommentDto> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = await _commentRepository.GetFirstOrDefaultAsync(
            predicate: x => x.Id == request.Id,
            disableTracking: false)
            ?? throw new NotFoundException(MessageCommon.SetEntityNotFound(nameof(Comment), request.Id));
        comment.Update(request.Content);

        _commentRepository.Update(comment);
        await unitOfWork.SaveChangesAsync();

        return comment.Adapt<CommentDto>();
    }
}