using TravelBlogs.Core.Application.Common.Specification;
using TravelBlogs.Core.Application.Cqrs.Comments.Params;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.Comment;
using TravelBlogs.Core.Domain.Entities.Catalog;

namespace TravelBlogs.Core.Application.Cqrs.Comments.Specs;

public class CommentByConditionSpec(SearchCommentParams param) : BaseSpec<Comment, CommentDto>(param);