using Ardalis.Specification;
using TravelBlogs.Core.Application.Common.Specification;
using TravelBlogs.Core.Application.Cqrs.ContactsInformation.Params;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.ContactInformation;
using TravelBlogs.Core.Domain.Entities.Catalog;

namespace TravelBlogs.Core.Application.Cqrs.ContactsInformation.Specs;

public class ContactInformationByConditionSpec(SearchContactInformationParam param) : BaseSpec<ContactInformation, ContactInformationDto>(param);

public class ContactInformationByIdSpec : Specification<ContactInformation, ContactInformationDto>
{
    public ContactInformationByIdSpec(long id)
    {
        Query.Where(x => x.Id == id);
    }
}