using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBlogs.Core.Application.Cqrs.Contacts.Commands;

namespace TravelBlogs.Core.Application.Cqrs.Contacts.Validators
{
    public class CreateContactValidator : ContactValidatorBase<CreateContactCommand>;
}
