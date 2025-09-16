using MediatR;
using TravelBlogs.Core.Application.Common.Models;
using TravelBlogs.Core.Application.Common.Persistences;
using TravelBlogs.Core.Application.Cqrs.Feedbacks.Params;
using TravelBlogs.Core.Application.Cqrs.Feedbacks.Specs;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.Feedback;
using TravelBlogs.Core.Domain.Entities.Catalog;

namespace TravelBlogs.Core.Application.Cqrs.Feedbacks.Queries;

public class GetFeedbackByConditionQuery : SearchFeedbackParam, IRequest<PaginationResponse<FeedbackDto>>;

public class GetFeedbackByConditionQueryHandler(
    IReadRepository<Feedback> feedbackRepository)
    : IRequestHandler<GetFeedbackByConditionQuery, PaginationResponse<FeedbackDto>>
{
    public async Task<PaginationResponse<FeedbackDto>> Handle(GetFeedbackByConditionQuery request, CancellationToken cancellationToken)
    {
        // Create spec for counting (without pagination)
        var countSpec = new FeedbackByConditionSpec(new SearchFeedbackParam 
        { 
            BlogId = request.BlogId, 
            UserId = request.UserId,
            IgnorePagination = true 
        });
        
        // Create spec for data (with pagination)
        var dataSpec = new FeedbackByConditionSpec(request);
        
        // Get total count
        var totalCount = await feedbackRepository.CountAsync(countSpec, cancellationToken);
        
        // Get data with pagination
        var feedbacks = await feedbackRepository.ListAsync(dataSpec, cancellationToken);
        
        return new PaginationResponse<FeedbackDto>(
            feedbacks,
            totalCount,
            request.PageNumber,
            request.PageSize);
    }
}
