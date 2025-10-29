using FluentValidation;
using TravelBlogs.Core.Application.Cqrs.BlogRequests.Commands;

namespace TravelBlogs.Core.Application.Cqrs.BlogRequests.Validators;

public class ApprovalBlogRequestCommandValidator : AbstractValidator<ApprovalBlogRequestCommand>
{
    public ApprovalBlogRequestCommandValidator()
    {
        RuleFor(x => x.BlogId)
            .NotEmpty()
            .WithMessage("This field is required")
            .GreaterThan(0)
            .WithMessage("Blog Id must greater than 0");

        RuleFor(x => x.ApproverId)
            .GreaterThan(0)
            .WithMessage("Approver Id must greater than 0")
            .When(x => x.ApproverId != null);
    }
}