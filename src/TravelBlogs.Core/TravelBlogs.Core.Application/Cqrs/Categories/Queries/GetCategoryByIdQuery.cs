using MediatR;
using Mapster;
using TravelBlogs.Core.Application.Common.Exceptions;
using TravelBlogs.Core.Application.Common.Repositories;
using TravelBlogs.Core.Application.Common.Responses;
using TravelBlogs.Core.Application.Cqrs.Categories.Specs;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.Categories;
using TravelBlogs.Core.Domain.Entities;
using TravelBlogs.Core.Shared.Constants;
using TravelBlogs.Core.Application.Common.Persistences;

namespace TravelBlogs.Core.Application.Cqrs.Categories.Queries;

public class GetCategoryByIdQuery : IRequest<ResponseBase<CategoryDto>>
{
    public long Id { get; set; }
}

public class GetCategoryByIdQueryHandler(IReadRepository<Category> categoryRepository)
    : IRequestHandler<GetCategoryByIdQuery, ResponseBase<CategoryDto>>
{
    public async Task<ResponseBase<CategoryDto>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await categoryRepository.FirstOrDefaultAsync(new CategoryByIdSpec(request.Id), cancellationToken)
                    ?? throw new NotFoundException(MessageCommon.SetEntityNotFound(nameof(Category), request.Id));

        return new ResponseBase<CategoryDto>(category.Adapt<CategoryDto>());
    }
}