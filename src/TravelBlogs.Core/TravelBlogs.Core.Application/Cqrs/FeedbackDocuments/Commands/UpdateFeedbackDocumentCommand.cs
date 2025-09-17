using System.Text.Json.Serialization;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TravelBlogs.Core.Application.Common.Exceptions;
using TravelBlogs.Core.Application.Common.Repositories;
using TravelBlogs.Core.Application.Common.UnitOfWork;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.FeedbackDocument;
using TravelBlogs.Core.Domain.Entities.Catalog;
using TravelBlogs.Core.Shared.Constants;

namespace TravelBlogs.Core.Application.Cqrs.FeedbackDocuments.Commands;

public class UpdateFeedbackDocumentCommand : FeedbackDocumentCommand, IRequest<FeedbackDocumentDto>
{
    [JsonIgnore]
    public long Id { get; private set; }

    public void SetId(long id)
    {
        Id = id;
    }
}

public class UpdateFeedbackDocumentCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateFeedbackDocumentCommand, FeedbackDocumentDto>
{
    private readonly IWriteRepository<FeedbackDocument> _repository = unitOfWork.GetRepository<FeedbackDocument>();

    public async Task<FeedbackDocumentDto> Handle(UpdateFeedbackDocumentCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetFirstOrDefaultAsync(
            predicate: x => x.Id == request.Id,
            include: x => x.Include(d => d.FileStorage)
                           .Include(d => d.Feedback),
            disableTracking: false)
            ?? throw new NotFoundException(MessageCommon.SetEntityNotFound(nameof(FeedbackDocument), request.Id));

        entity.Update(request.FileStorageId);

        _repository.Update(entity);
        await unitOfWork.SaveChangesAsync();

        return entity.Adapt<FeedbackDocumentDto>();
    }
}