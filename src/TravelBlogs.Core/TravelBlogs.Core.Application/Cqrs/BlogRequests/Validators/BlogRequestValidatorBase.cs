using FluentValidation;
using TravelBlogs.Core.Application.Cqrs.BlogRequests.Commands;

namespace TravelBlogs.Core.Application.Cqrs.BlogRequests.Validators;

public class BlogRequestValidatorBase<T> : AbstractValidator<T> where T : BlogRequestBaseCommand
{
    public BlogRequestValidatorBase()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("This field is required")
            .MaximumLength(256)
            .WithMessage("Title length must not exceed 256 characters");

        RuleFor(x => x.Description)
            .MaximumLength(1000)
            .WithMessage("Description length must not exceed 1000 characters")
            .When(x => x.Description != null);

        RuleFor(x => x.Content)
            .NotEmpty()
            .WithMessage("This field is required");

        RuleFor(x => x.TimeRead)
           .NotEmpty()
           .WithMessage("This field is required");

        RuleFor(x => x.CategoryId)
            .NotEmpty()
            .WithMessage("This field is required")
            .GreaterThan(0)
            .WithMessage("Category Id must greater than 0");

        RuleFor(x => x.DestinationId)
            .NotEmpty()
            .WithMessage("This field is required")
            .GreaterThan(0)
            .WithMessage("Destination Id must greater than 0");
    }
}