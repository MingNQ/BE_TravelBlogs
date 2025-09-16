using MediatR;
using Microsoft.EntityFrameworkCore;
using TravelBlogs.Core.Application.Common.Exceptions;
using TravelBlogs.Core.Application.Common.Repositories;
using TravelBlogs.Core.Application.Common.UnitOfWork;
using TravelBlogs.Core.Domain.Entities.Catalog;
using TravelBlogs.Core.Shared.Constants;

namespace TravelBlogs.Core.Application.Cqrs.Feedbacks.Commands;

public class DeleteFeedbackCommand : IRequest<long>
{
    public long Id { get; set; }
}

public class DeleteFeedbackCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteFeedbackCommand, long>
{
    private readonly IWriteRepository<Feedback> _feedbackRepository = unitOfWork.GetRepository<Feedback>();

    public async Task<long> Handle(DeleteFeedbackCommand request, CancellationToken cancellationToken)
    {
        var feedback = await _feedbackRepository.GetFirstOrDefaultAsync(
            predicate: x => x.Id == request.Id,
            include: x => x.Include(f => f.Blog)
                            .Include(f => f.User),
            disableTracking: false)
            ?? throw new NotFoundException(MessageCommon.SetEntityNotFound(nameof(Feedback), request.Id));

        _feedbackRepository.Delete(feedback);
        await unitOfWork.SaveChangesAsync();

        return request.Id;
    }
}

