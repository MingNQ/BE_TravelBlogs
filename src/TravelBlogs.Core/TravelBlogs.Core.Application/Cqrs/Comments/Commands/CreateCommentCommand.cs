using Mapster;
using MediatR;
using TravelBlogs.Core.Application.Common.Repositories;
using TravelBlogs.Core.Application.Common.UnitOfWork;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.Comment;
using TravelBlogs.Core.Domain.Entities.Catalog;

namespace TravelBlogs.Core.Application.Cqrs.Comments.Commands;

public class CreateCommentCommand : CommentBaseCommand, IRequest<CommentDto>
{
    public long BlogId { get; set; }
    public long UserId { get; set; }
    public long? ParentCommentId { get; set; }
}

public class CreateCommentCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<CreateCommentCommand, CommentDto>
{
    private readonly IWriteRepository<Comment> _commentWriteRepository = unitOfWork.GetRepository<Comment>();

    public async Task<CommentDto> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = Comment.Create(
            request.Content,
            request.BlogId,
            request.UserId,
            request.ParentCommentId);

        await _commentWriteRepository.InsertAsync(comment, cancellationToken);
        await unitOfWork.SaveChangesAsync();

        return comment.Adapt<CommentDto>();
    }
}