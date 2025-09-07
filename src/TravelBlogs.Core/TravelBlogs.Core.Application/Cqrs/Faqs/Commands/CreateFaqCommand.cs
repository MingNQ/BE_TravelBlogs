using Mapster;
using MediatR;
using TravelBlogs.Core.Application.Common.Repositories;
using TravelBlogs.Core.Application.Common.UnitOfWork;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.Faq;
using TravelBlogs.Core.Domain.Entities.Catalog;

namespace TravelBlogs.Core.Application.Cqrs.Faqs.Commands;

public class CreateFaqCommand : FaqBaseCommand, IRequest<FaqDto>;
public class CreateFaqCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateFaqCommand, FaqDto>
{
    private readonly IWriteRepository<Faq> _repo = unitOfWork.GetRepository<Faq>();

    public async Task<FaqDto> Handle(CreateFaqCommand request, CancellationToken ct)
    {
        var entity = Faq.Create(request.Question, request.Answer);
        var result = await _repo.InsertAsync(entity, ct);
        await unitOfWork.SaveChangesAsync();
        return result.Adapt<FaqDto>();
    }
}