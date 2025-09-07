using Ardalis.Specification;
using TravelBlogs.Core.Application.Common.Specification;
using TravelBlogs.Core.Application.Cqrs.Faqs.Params;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.Contact;
using TravelBlogs.Core.Domain.Entities.Catalog;

namespace TravelBlogs.Core.Application.Cqrs.Contacts.Specs;

public class ContactByConditionSpec(SearchFaqParam param) : BaseSpec<Contact, ContactDto>(param);

public sealed class ContactByIdSpec : Specification<Contact, ContactDto>
{
    public ContactByIdSpec(long id)
    {
        Query.Where(x => x.Id == id);
    }
}