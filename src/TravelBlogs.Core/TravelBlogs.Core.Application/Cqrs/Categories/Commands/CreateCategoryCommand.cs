using Mapster;
using MediatR;
using TravelBlogs.Core.Application.Common.Repositories;
using TravelBlogs.Core.Application.Common.UnitOfWork;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.Categories;
using TravelBlogs.Core.Domain.Entities.Catalog;

namespace TravelBlogs.Core.Application.Cqrs.Categories.Commands;

public class CreateCategoryCommand : CategoryBaseCommand, IRequest<CategoryDto>;

public class CreateCategoryCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<CreateCategoryCommand, CategoryDto>
{
    private readonly IWriteRepository<Category> _categoryRepository = unitOfWork.GetRepository<Category>();

    public async Task<CategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        // tạo entities mới 
        var category = Category.Create(request.Name);

        // thêm vào repository
        await _categoryRepository.InsertAsync(category, cancellationToken);

        // lưu vào database
        await unitOfWork.SaveChangesAsync();

        // map từ biến 'category' gốc sau khi đã được lưu
        return category.Adapt<CategoryDto>();
    }
}