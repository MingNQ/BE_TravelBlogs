using MediatR;
using TravelBlogs.Core.Application.Common.Exceptions;
using TravelBlogs.Core.Application.Common.Repositories;
using TravelBlogs.Core.Application.Common.Responses;
using TravelBlogs.Core.Application.Common.UnitOfWork;
using TravelBlogs.Core.Domain.Entities;
using TravelBlogs.Core.Shared.Constants;

namespace TravelBlogs.Core.Application.Cqrs.Categories.Commands;

public class DeleteCategoryCommand : IRequest<ResponseBase<long>>
{
    public long Id { get; set; }
}

public class DeleteCategoryCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteCategoryCommand, ResponseBase<long>>
{
    private readonly IWriteRepository<Category> _repo = unitOfWork.GetRepository<Category>();

    public async Task<ResponseBase<long>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _repo.GetFirstOrDefaultAsync(predicate: c => c.Id == request.Id, disableTracking: false)
                     ?? throw new NotFoundException(MessageCommon.SetEntityNotFound(nameof(Category), request.Id));

        _repo.Delete(category);
        await unitOfWork.SaveChangesAsync();

        return new ResponseBase<long>(category.Id, MessageCommon.DeleteSuccess);
    }
}