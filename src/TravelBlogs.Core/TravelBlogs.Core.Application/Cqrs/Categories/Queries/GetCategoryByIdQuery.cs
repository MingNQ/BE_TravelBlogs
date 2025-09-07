using Mapster;
using MediatR;
using TravelBlogs.Core.Application.Common.Exceptions;
using TravelBlogs.Core.Application.Common.Persistences;
using TravelBlogs.Core.Application.Cqrs.Categories.Specs;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.Categories;
using TravelBlogs.Core.Domain.Entities.Catalog;
using TravelBlogs.Core.Shared.Constants;

namespace TravelBlogs.Core.Application.Cqrs.Categories.Queries;

public class GetCategoryByIdQuery : IRequest<CategoryDto>
{
    public long Id { get; set; }
}

public class GetCategoryByIdQueryHandler(IReadRepository<Category> categoryRepository)
    : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
{
    public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await categoryRepository.FirstOrDefaultAsync(new CategoryByIdSpec(request.Id), cancellationToken)
                    ?? throw new NotFoundException(MessageCommon.SetEntityNotFound(nameof(Category), request.Id));

        return category.Adapt<CategoryDto>();
    }
}