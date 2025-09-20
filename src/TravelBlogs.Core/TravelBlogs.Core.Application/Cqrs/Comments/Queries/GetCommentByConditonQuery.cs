using MediatR;
using TravelBlogs.Core.Application.Common.Models;
using TravelBlogs.Core.Application.Common.Persistences;
using TravelBlogs.Core.Application.Common.Services;
using TravelBlogs.Core.Application.Cqrs.Comments.Params;
using TravelBlogs.Core.Application.Cqrs.Comments.Specs;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.Comment;
using TravelBlogs.Core.Domain.Entities.Catalog;

namespace TravelBlogs.Core.Application.Cqrs.Comments.Queries;

public class GetCommentByConditionQuery : SearchCommentParams, IRequest<PaginationResponse<CommentDto>>;

public class GetCommentByConditionQueryHandler(
    IReadRepository<Comment> commentRepository,
    IPaginationService paginationService)
    : IRequestHandler<GetCommentByConditionQuery, PaginationResponse<CommentDto>>
{
    public async Task<PaginationResponse<CommentDto>> Handle(GetCommentByConditionQuery request, CancellationToken cancellationToken)
    {
        var spec = new CommentByConditionSpec(request);
        var comments = await paginationService.PaginatedListAsync(
            commentRepository,
            spec,
            request.PageNumber,
            request.PageSize,
            cancellationToken);

        return comments;
    }
}