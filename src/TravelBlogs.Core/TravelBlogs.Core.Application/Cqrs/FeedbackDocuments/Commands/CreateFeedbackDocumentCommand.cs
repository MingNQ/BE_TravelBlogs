using Mapster;
using MediatR;
using TravelBlogs.Core.Application.Common.Repositories;
using TravelBlogs.Core.Application.Common.UnitOfWork;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.FeedbackDocument;
using TravelBlogs.Core.Domain.Entities.Catalog;

namespace TravelBlogs.Core.Application.Cqrs.FeedbackDocuments.Commands;

public class CreateFeedbackDocumentCommand : FeedbackDocumentCommand, IRequest<FeedbackDocumentDto>
{
}

public class CreateFeedbackDocumentCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<CreateFeedbackDocumentCommand, FeedbackDocumentDto>
{
    private readonly IWriteRepository<FeedbackDocument> _repository = unitOfWork.GetRepository<FeedbackDocument>();

    public async Task<FeedbackDocumentDto> Handle(CreateFeedbackDocumentCommand request, CancellationToken cancellationToken)
    {
        var entity = FeedbackDocument.Create(request.FeedbackId, request.FileStorageId);

        await _repository.InsertAsync(entity, cancellationToken);
        await unitOfWork.SaveChangesAsync();

        return entity.Adapt<FeedbackDocumentDto>();
    }
}


