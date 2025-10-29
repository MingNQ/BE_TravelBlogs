using FluentValidation;
using TravelBlogs.Core.Application.Cqrs.BlogRequests.Commands;

namespace TravelBlogs.Core.Application.Cqrs.BlogRequests.Validators;

public class RejectBlogRequestCommandValidator : AbstractValidator<RejectBlogRequestCommand>
{
    public RejectBlogRequestCommandValidator()
    {
        RuleFor(x => x.BlogId)
            .NotEmpty()
            .WithMessage("This field is required")
            .GreaterThan(0)
            .WithMessage("Blog Id must greater than 0");

        RuleFor(x => x.RejectorId)
            .GreaterThan(0)
            .WithMessage("Approver Id must greater than 0")
            .When(x => x.RejectorId != null);
    }
}