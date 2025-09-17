using MediatR;
using TravelBlogs.Core.Application.Common.Models;
using TravelBlogs.Core.Application.Common.Persistences;
using TravelBlogs.Core.Application.Cqrs.FeedbackDocuments.Params;
using TravelBlogs.Core.Application.Cqrs.FeedbackDocuments.Specs;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.FeedbackDocument;
using TravelBlogs.Core.Domain.Entities.Catalog;

namespace TravelBlogs.Core.Application.Cqrs.FeedbackDocuments.Queries;

public class GetFeedbackDocumentByConditionQuery : SearchFeedbackDocumentParam, IRequest<PaginationResponse<FeedbackDocumentDto>>;

public class GetFeedbackDocumentByConditionQueryHandler(IReadRepository<FeedbackDocument> repository)
    : IRequestHandler<GetFeedbackDocumentByConditionQuery, PaginationResponse<FeedbackDocumentDto>>
{
    public async Task<PaginationResponse<FeedbackDocumentDto>> Handle(GetFeedbackDocumentByConditionQuery request, CancellationToken cancellationToken)
    {
        var countSpec = new FeedbackDocumentByConditionSpec(new SearchFeedbackDocumentParam
        {
            FeedbackId = request.FeedbackId,
            FileStorageId = request.FileStorageId,
            IgnorePagination = true
        });

        var dataSpec = new FeedbackDocumentByConditionSpec(request);

        var totalCount = await repository.CountAsync(countSpec, cancellationToken);
        var items = await repository.ListAsync(dataSpec, cancellationToken);

        return new PaginationResponse<FeedbackDocumentDto>(
            items,
            totalCount,
            request.PageNumber,
            request.PageSize);
    }
}