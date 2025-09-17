using MediatR;
using TravelBlogs.Core.Application.Common.Exceptions;
using TravelBlogs.Core.Application.Common.Persistences;
using TravelBlogs.Core.Application.Cqrs.FeedbackDocuments.Specs;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.FeedbackDocument;
using TravelBlogs.Core.Domain.Entities.Catalog;
using TravelBlogs.Core.Shared.Constants;

namespace TravelBlogs.Core.Application.Cqrs.FeedbackDocuments.Queries;

public class GetFeedbackDocumentByIdQuery : IRequest<FeedbackDocumentDto>
{
    public long Id { get; set; }
}

public class GetFeedbackDocumentByIdQueryHandler(IReadRepository<FeedbackDocument> repository)
    : IRequestHandler<GetFeedbackDocumentByIdQuery, FeedbackDocumentDto>
{
    public async Task<FeedbackDocumentDto> Handle(GetFeedbackDocumentByIdQuery request, CancellationToken cancellationToken)
    {
        var spec = new FeedbackDocumentByIdSpec(request.Id);
        var entity = await repository.FirstOrDefaultAsync(spec, cancellationToken)
            ?? throw new NotFoundException(MessageCommon.SetEntityNotFound(nameof(FeedbackDocument), request.Id));
        return entity;
    }
}