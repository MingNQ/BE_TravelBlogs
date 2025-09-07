using Mapster;
using MediatR;
using System.Text.Json.Serialization;
using TravelBlogs.Core.Application.Common.Exceptions;
using TravelBlogs.Core.Application.Common.Repositories;
using TravelBlogs.Core.Application.Common.Responses;
using TravelBlogs.Core.Application.Common.UnitOfWork;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.Categories;
using TravelBlogs.Core.Domain.Entities;
using TravelBlogs.Core.Shared.Constants;

namespace TravelBlogs.Core.Application.Cqrs.Categories.Commands;

public class UpdateCategoryCommand : IRequest<ResponseBase<CategoryDto>>
{
    [JsonIgnore]
    public long Id { get; private set; }
    public string Name { get; set; } = string.Empty;
    public UpdateCategoryCommand SetId(long id) { Id = id; return this; }
}

public class UpdateCategoryCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateCategoryCommand, ResponseBase<CategoryDto>>
{
    private readonly IWriteRepository<Category> _repo = unitOfWork.GetRepository<Category>();

    public async Task<ResponseBase<CategoryDto>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _repo.GetFirstOrDefaultAsync(predicate: c => c.Id == request.Id, disableTracking: false)
                      ?? throw new NotFoundException(MessageCommon.SetEntityNotFound(nameof(Category), request.Id));

        category.Name = request.Name;
        _repo.Update(category);
        await unitOfWork.SaveChangesAsync();

        return new ResponseBase<CategoryDto>(category.Adapt<CategoryDto>(), MessageCommon.UpdateSuccess);
    }
}