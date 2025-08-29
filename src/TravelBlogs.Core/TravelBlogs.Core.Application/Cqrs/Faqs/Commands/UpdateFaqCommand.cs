using Mapster;
using MediatR;
using System.Text.Json.Serialization;
using TravelBlogs.Core.Application.Common.Exceptions;
using TravelBlogs.Core.Application.Common.Repositories;
using TravelBlogs.Core.Application.Common.Responses;
using TravelBlogs.Core.Application.Common.UnitOfWork;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.Faq;
using TravelBlogs.Core.Domain.Entities.Catalog;
using TravelBlogs.Core.Shared.Constants;

namespace TravelBlogs.Core.Application.Cqrs.Faqs.Commands;

public class UpdateFaqCommand : FaqBaseCommand, IRequest<FaqDto>
{
    [JsonIgnore]
    public long Id { get; private set; }

    public UpdateFaqCommand SetId(long id) { Id = id; return this; }
}

public class UpdateFaqCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateFaqCommand, FaqDto>
{
    private readonly IWriteRepository<Faq> _repo = unitOfWork.GetRepository<Faq>();

    public async Task<FaqDto> Handle(UpdateFaqCommand request, CancellationToken ct)
    {
        var entity = await _repo.GetFirstOrDefaultAsync(
            predicate: x => x.Id == request.Id,
            disableTracking: false)
            ?? throw new NotFoundException(MessageCommon.SetEntityNotFound(nameof(Faq), request.Id));

        entity.Update(request.Question, request.Answer);
        _repo.Update(entity);
        await unitOfWork.SaveChangesAsync();
        return entity.Adapt<FaqDto>();
    }
}