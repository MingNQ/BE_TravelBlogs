using Ardalis.Specification;
using TravelBlogs.Core.Application.Common.Specification;
using TravelBlogs.Core.Application.Cqrs.Faqs.Params;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.Faq;
using TravelBlogs.Core.Application.Dto.Integrates.Catalog;
using TravelBlogs.Core.Domain.Entities.Catalog;

namespace TravelBlogs.Core.Application.Cqrs.Faqs.Specs;

public class FaqByConditionSpec(SearchFaqParam param) : BaseSpec<Faq, FaqDto>(param);

public sealed class FaqByIdSpec : Specification<Faq, FaqDto>
{
    public FaqByIdSpec(long id)
    {
        Query.Where(x => x.Id == id);
    }
}

public sealed class FaqForExternalSpec : Specification<Faq, FaqExternalDto>
{
    public FaqForExternalSpec()
    {
        Query.Select(x => new FaqExternalDto
        {
            Id = x.Id,
            Question = x.Question,
            Answer = x.Answer
        });
    }
}