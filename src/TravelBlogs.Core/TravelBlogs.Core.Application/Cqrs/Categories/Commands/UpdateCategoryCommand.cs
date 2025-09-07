using Mapster;
using MediatR;
using System.Text.Json.Serialization;
using TravelBlogs.Core.Application.Common.Exceptions;
using TravelBlogs.Core.Application.Common.Repositories;
using TravelBlogs.Core.Application.Common.UnitOfWork;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.Categories;
using TravelBlogs.Core.Domain.Entities.Catalog;
using TravelBlogs.Core.Shared.Constants;

namespace TravelBlogs.Core.Application.Cqrs.Categories.Commands;

public class UpdateCategoryCommand : CategoryBaseCommand, IRequest<CategoryDto>   
{
    [JsonIgnore]
    public long Id { get; private set; }
    public UpdateCategoryCommand SetId(long id) { Id = id; return this; }
}

public class UpdateCategoryCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateCategoryCommand, CategoryDto>
{
    private readonly IWriteRepository<Category> _categoryRepository = unitOfWork.GetRepository<Category>();

    public async Task<CategoryDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetFirstOrDefaultAsync(predicate: c => c.Id == request.Id, disableTracking: false)
                      ?? throw new NotFoundException(MessageCommon.SetEntityNotFound(nameof(Category), request.Id));

        category.Update(request.Name);
        _categoryRepository.Update(category);
        await unitOfWork.SaveChangesAsync();

        return category.Adapt<CategoryDto>();
    }
}