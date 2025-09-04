using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBlogs.Core.Application.Cqrs.Contacts.Commands;

namespace TravelBlogs.Core.Application.Cqrs.Contacts.Validators
{
    public class UpdateContactValidator : ContactValidatorBase<UpdateContactCommand>
    {
        public UpdateContactValidator() {
            RuleFor(x => x.Id)
              .GreaterThan(0)
              .WithMessage("Contact ID must be greater than 0");
        }
    }
}
