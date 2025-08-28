using Mapster;
using MediatR;
using TravelBlogs.Core.Application.Common.Repositories;
using TravelBlogs.Core.Application.Common.Responses;
using TravelBlogs.Core.Application.Common.UnitOfWork;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.Faq;
using TravelBlogs.Core.Domain.Entities.Identity;
using TravelBlogs.Core.Shared.Constants;

namespace TravelBlogs.Core.Application.Cqrs.Faqs.Commands;

public class CreateFaqCommand : FaqBaseCommand, IRequest<ResponseBase<FaqDto>>;
public class CreateFaqCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateFaqCommand, ResponseBase<FaqDto>>
{
    private readonly IWriteRepository<Faq> _repo = unitOfWork.GetRepository<Faq>();

    public async Task<ResponseBase<FaqDto>> Handle(CreateFaqCommand request, CancellationToken ct)
    {
        var entity = Faq.Create(request.Question, request.Answer);
        var result = await _repo.InsertAsync(entity, ct);
        await unitOfWork.SaveChangesAsync();
        return new ResponseBase<FaqDto>(result.Entity.Adapt<FaqDto>(), MessageCommon.CreateSuccess);
    }
}
