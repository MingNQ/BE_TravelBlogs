using MediatR;
using TravelBlogs.Core.Application.Common.Exceptions;
using TravelBlogs.Core.Application.Common.Repositories;
using TravelBlogs.Core.Application.Common.Responses;
using TravelBlogs.Core.Application.Common.UnitOfWork;
using TravelBlogs.Core.Domain.Entities.Catalog;
using TravelBlogs.Core.Shared.Constants;

namespace TravelBlogs.Core.Application.Cqrs.Faqs.Commands;

public class DeleteFaqCommand : IRequest<long>
{
    public long Id { get; set; }
}

public class DeleteFaqCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteFaqCommand, long>
{
    private readonly IWriteRepository<Faq> _repo = unitOfWork.GetRepository<Faq>();

    public async Task<long> Handle(DeleteFaqCommand request, CancellationToken ct)
    {
        var entity = await _repo.GetFirstOrDefaultAsync(
            predicate: x => x.Id == request.Id,
            disableTracking: false)
            ?? throw new NotFoundException(MessageCommon.SetEntityNotFound(nameof(Faq), request.Id));

        _repo.Delete(entity);
        await unitOfWork.SaveChangesAsync();
        return entity.Id;
    }
}