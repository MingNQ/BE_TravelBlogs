using Mapster;
using MediatR;
using System.Text.Json.Serialization;
using TravelBlogs.Core.Application.Common.Interfaces;
using TravelBlogs.Core.Application.Common.Repositories;
using TravelBlogs.Core.Application.Common.UnitOfWork;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.Comment;
using TravelBlogs.Core.Domain.Entities.Catalog;

namespace TravelBlogs.Core.Application.Cqrs.Comments.Commands;

public class CreateCommentCommand : CommentBaseCommand, IRequest<CommentDto>
{
    [JsonIgnore]
    public long BlogId { get; set; }

    public void SetBlogId(long blogId)
    {
        BlogId = blogId;
    }

    public long? ParentCommentId { get; set; }
}

public class CreateCommentCommandHandler(
    IUnitOfWork unitOfWork,
    ICurrentUser currentUser)
    : IRequestHandler<CreateCommentCommand, CommentDto>
{
    private readonly IWriteRepository<Comment> _commentWriteRepository = unitOfWork.GetRepository<Comment>();

    public async Task<CommentDto> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = Comment.Create(
            request.Content,
            request.BlogId,
            currentUser.UserId,
            request.ParentCommentId);

        await _commentWriteRepository.InsertAsync(comment, cancellationToken);
        await unitOfWork.SaveChangesAsync();

        return comment.Adapt<CommentDto>();
    }
}