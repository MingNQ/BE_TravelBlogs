using MediatR;
using TravelBlogs.Core.Application.Common.Interfaces;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.Blog;
using TravelBlogs.Core.Application.Interfaces.Services;

namespace TravelBlogs.Core.Application.Cqrs.BlogRequests.Commands;

public class CreateBlogRequestCommand : BlogRequestBaseCommand, IRequest<CreateExternalBlogResponse>;

public class CreateBlogRequestCommandHandler(IBlogRequestService blogRequestService, ICurrentUser currentUser)
    : IRequestHandler<CreateBlogRequestCommand, CreateExternalBlogResponse>
{
    public async Task<CreateExternalBlogResponse> Handle(CreateBlogRequestCommand request, CancellationToken cancellationToken)
    {
        var createBlogRequest = new CreateBlogRequestDto
        {
            Title = request.Title,
            Description = request.Description,
            Content = request.Content,
            TimeRead = request.TimeRead,
            CategoryId = request.CategoryId,
            DestinationId = request.DestinationId,
            ThumbnailId = request.ThumbnailId,
            AuthorId = currentUser.UserId
        };

        return await blogRequestService.CreateBlogRequestAsync(createBlogRequest, cancellationToken);
    }
}