using MediatR;
using TravelBlogs.Core.Application.Common.Exceptions;
using TravelBlogs.Core.Application.Common.Persistences;
using TravelBlogs.Core.Application.Cqrs.Feedbacks.Specs;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.Feedback;
using TravelBlogs.Core.Domain.Entities.Catalog;
using TravelBlogs.Core.Shared.Constants;

namespace TravelBlogs.Core.Application.Cqrs.Feedbacks.Queries;

public class GetFeedbackByIdQuery : IRequest<FeedbackDto>
{
    public long Id { get; set; }
}

public class GetFeedbackByIdQueryHandler(IReadRepository<Feedback> feedbackRepository)
    : IRequestHandler<GetFeedbackByIdQuery, FeedbackDto>
{
    public async Task<FeedbackDto> Handle(GetFeedbackByIdQuery request, CancellationToken cancellationToken)
    {
        var spec = new FeedbackByIdSpec(request.Id);
        var feedback = await feedbackRepository.FirstOrDefaultAsync(spec, cancellationToken)
            ?? throw new NotFoundException(MessageCommon.SetEntityNotFound(nameof(Feedback), request.Id));

        return feedback;
    }
}

