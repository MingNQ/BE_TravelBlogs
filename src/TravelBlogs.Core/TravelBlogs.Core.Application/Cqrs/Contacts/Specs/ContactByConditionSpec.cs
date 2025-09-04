using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBlogs.Core.Application.Common.Specification;
using TravelBlogs.Core.Application.Cqrs.Faqs.Params;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.Contact;
using TravelBlogs.Core.Domain.Entities.Catalog;
using TravelBlogs.Core.Domain.Entities.Identity;

namespace TravelBlogs.Core.Application.Cqrs.Contacts.Specs
{
    public class ContactByConditionSpec(SearchFaqParam param) : BaseSpec<Contact, ContactDto>(param);

    public sealed class ContactByIdSpec : Specification<Contact, ContactDto>
    {
        public ContactByIdSpec(long id)
        {
            Query.Where(x => x.Id == id);
        }
    }
}
