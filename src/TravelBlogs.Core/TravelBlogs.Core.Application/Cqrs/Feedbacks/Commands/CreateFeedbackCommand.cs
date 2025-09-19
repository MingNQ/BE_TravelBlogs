using Mapster;
using MediatR;
using TravelBlogs.Core.Application.Common.Repositories;
using TravelBlogs.Core.Application.Common.UnitOfWork;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.Feedback;
using TravelBlogs.Core.Domain.Entities.Catalog;

namespace TravelBlogs.Core.Application.Cqrs.Feedbacks.Commands;

public class CreateFeedbackCommand : FeedbackCommand, IRequest<FeedbackDto>
{
}

public class CreateFeedbackCommandHandler(
    IUnitOfWork unitOfWork)
    : IRequestHandler<CreateFeedbackCommand, FeedbackDto>
{
    private readonly IWriteRepository<Feedback> _feedbackRepository = unitOfWork.GetRepository<Feedback>();

    public async Task<FeedbackDto> Handle(CreateFeedbackCommand request, CancellationToken cancellationToken)
    {
        var feedback = Feedback.Create(
            request.Type,
            request.Regarding,
            request.Status,
            request.Content,
            request.BlogId,
            request.UserId);

        await _feedbackRepository.InsertAsync(feedback, cancellationToken);
        await unitOfWork.SaveChangesAsync();

        return feedback.Adapt<FeedbackDto>();
    }
}