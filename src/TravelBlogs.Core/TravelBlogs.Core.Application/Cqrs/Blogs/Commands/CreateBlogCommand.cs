using Mapster;
using MediatR;
using TravelBlogs.Core.Application.Common.Repositories;
using TravelBlogs.Core.Application.Common.UnitOfWork;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.Blog;
using TravelBlogs.Core.Domain.Entities.Catalog;

namespace TravelBlogs.Core.Application.Cqrs.Blogs.Commands;

public class CreateBlogCommand : BlogCommand, IRequest<BlogDto>
{
    public long AuthorId { get; set; }
}

public class CreateBlogCommandHandler(
    IUnitOfWork unitOfWork)
    : IRequestHandler<CreateBlogCommand, BlogDto>
{
    private readonly IWriteRepository<Blog> _blogRepository = unitOfWork.GetRepository<Blog>();

    public async Task<BlogDto> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
    {
        var blog = Blog.Create(
            request.Title,
            request.Description,
            request.Content,
            request.TimeRead,
            request.Status,
            request.AuthorId,
            request.CategoryId,
            request.DestinationId,
            request.ThumbnailId);

        await _blogRepository.InsertAsync(blog, cancellationToken);
        await unitOfWork.SaveChangesAsync();

        return blog.Adapt<BlogDto>();
    }
}