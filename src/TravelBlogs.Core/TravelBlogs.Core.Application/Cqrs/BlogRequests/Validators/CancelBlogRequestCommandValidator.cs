using FluentValidation;
using TravelBlogs.Core.Application.Cqrs.BlogRequests.Commands;

namespace TravelBlogs.Core.Application.Cqrs.BlogRequests.Validators;

public class CancelBlogRequestCommandValidator : AbstractValidator<CancelBlogRequestCommand>
{
    public CancelBlogRequestCommandValidator()
    {
        RuleFor(x => x.BlogId)
            .NotEmpty()
            .WithMessage("This field is required")
            .GreaterThan(0)
            .WithMessage("Blog Id must greater than 0");
    }
}