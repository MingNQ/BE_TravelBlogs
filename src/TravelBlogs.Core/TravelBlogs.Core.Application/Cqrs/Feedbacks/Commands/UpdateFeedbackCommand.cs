using System.Text.Json.Serialization;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TravelBlogs.Core.Application.Common.Exceptions;
using TravelBlogs.Core.Application.Common.Repositories;
using TravelBlogs.Core.Application.Common.UnitOfWork;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.Feedback;
using TravelBlogs.Core.Domain.Entities.Catalog;
using TravelBlogs.Core.Shared.Constants;

namespace TravelBlogs.Core.Application.Cqrs.Feedbacks.Commands;

public class UpdateFeedbackCommand : FeedbackCommand, IRequest<FeedbackDto>
{
    [JsonIgnore]
    public long Id { get; private set; }
    public void SetId(long id)
    {
        Id = id;
    }
}

public class UpdateFeedbackCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateFeedbackCommand, FeedbackDto>
{
    private readonly IWriteRepository<Feedback> _feedbackRepository = unitOfWork.GetRepository<Feedback>();

    public async Task<FeedbackDto> Handle(UpdateFeedbackCommand request, CancellationToken cancellationToken)
    {
        var feedback = await _feedbackRepository.GetFirstOrDefaultAsync(
            predicate: x => x.Id == request.Id,
            include: x => x.Include(f => f.Blog)
                            .Include(f => f.User),
            disableTracking: false)
            ?? throw new NotFoundException(MessageCommon.SetEntityNotFound(nameof(Feedback), request.Id));

        feedback.Update(
            request.Type,
            request.Regarding,
            request.Status,
            request.Content);

        _feedbackRepository.Update(feedback);
        await unitOfWork.SaveChangesAsync();

        return feedback.Adapt<FeedbackDto>();
    }
}