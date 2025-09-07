using FluentValidation;
using TravelBlogs.Core.Application.Cqrs.Contacts.Commands;

namespace TravelBlogs.Core.Application.Cqrs.Contacts.Validators;

public class ContactValidatorBase<T> : AbstractValidator<T> where T : ContactBaseCommand
{
    public ContactValidatorBase()
    {
        RuleFor(x => x.Subject)
            .NotEmpty()
            .WithMessage("Subject is required")
            .MaximumLength(100)
            .WithMessage("Subject must not exceed 100 characters");

        RuleFor(x => x.Content)
            .NotEmpty()
            .WithMessage("Content is required")
            .MaximumLength(1000)
            .WithMessage("Content length must not be more than 1000 characters");
    }
}