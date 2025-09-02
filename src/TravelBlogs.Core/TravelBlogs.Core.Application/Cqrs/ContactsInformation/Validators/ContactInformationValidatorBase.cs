using FluentValidation;
using TravelBlogs.Core.Application.Cqrs.ContactsInformation.Commands;
using TravelBlogs.Core.Domain.Entities.Catalog;

namespace TravelBlogs.Core.Application.Cqrs.ContactsInformation.Validators;

public class ContactInformationValidatorBase<T> : AbstractValidator<T> where T : ContactInformationBaseCommand
{
    public ContactInformationValidatorBase()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("This field is required")
            .MaximumLength(255)
            .WithMessage("Email must not exceed 255 characters");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .WithMessage("This field is required")
            .MaximumLength(11)
            .WithMessage("PhoneNumber must not exceed 11 characters");
    }
}