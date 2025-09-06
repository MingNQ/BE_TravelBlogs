using Mapster;
using MediatR;
using TravelBlogs.Core.Application.Common.Repositories;
using TravelBlogs.Core.Application.Common.Responses;
using TravelBlogs.Core.Application.Common.UnitOfWork;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.Categories;
using TravelBlogs.Core.Domain.Entities;
using TravelBlogs.Core.Shared.Constants;

namespace TravelBlogs.Core.Application.Cqrs.Categories.Commands;

public class CreateCategoryCommand : IRequest<ResponseBase<CategoryDto>>
{
    public string Name { get; set; } = string.Empty;
}

public class CreateCategoryCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<CreateCategoryCommand, ResponseBase<CategoryDto>>
{
    private readonly IWriteRepository<Category> _repo = unitOfWork.GetRepository<Category>();

    public async Task<ResponseBase<CategoryDto>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        // tạo entities mới 
        var category = new Category { Name = request.Name };

        // thêm vào repository
        await _repo.InsertAsync(category, cancellationToken);

        // lưu vào database
        await unitOfWork.SaveChangesAsync();

        // map từ biến 'category' gốc sau khi đã được lưu
        return new ResponseBase<CategoryDto>(
            category.Adapt<CategoryDto>(),
            MessageCommon.CreateSuccess);
    }
}