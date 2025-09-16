using MediatR;
using Microsoft.EntityFrameworkCore;
using TravelBlogs.Core.Application.Common.Exceptions;
using TravelBlogs.Core.Application.Common.Repositories;
using TravelBlogs.Core.Application.Common.UnitOfWork;
using TravelBlogs.Core.Domain.Entities.Catalog;
using TravelBlogs.Core.Shared.Constants;

namespace TravelBlogs.Core.Application.Cqrs.FeedbackDocuments.Commands;

public class DeleteFeedbackDocumentCommand : IRequest<long>
{
    public long Id { get; set; }
}

public class DeleteFeedbackDocumentCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteFeedbackDocumentCommand, long>
{
    private readonly IWriteRepository<FeedbackDocument> _repository = unitOfWork.GetRepository<FeedbackDocument>();

    public async Task<long> Handle(DeleteFeedbackDocumentCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetFirstOrDefaultAsync(
            predicate: x => x.Id == request.Id,
            include: x => x.Include(d => d.FileStorage)
                           .Include(d => d.Feedback),
            disableTracking: false)
            ?? throw new NotFoundException(MessageCommon.SetEntityNotFound(nameof(FeedbackDocument), request.Id));

        _repository.Delete(entity);
        await unitOfWork.SaveChangesAsync();

        return request.Id;
    }
}




