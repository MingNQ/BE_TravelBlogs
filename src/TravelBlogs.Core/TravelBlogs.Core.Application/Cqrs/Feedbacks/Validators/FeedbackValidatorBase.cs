using FluentValidation;
using TravelBlogs.Core.Application.Cqrs.Feedbacks.Commands;

namespace TravelBlogs.Core.Application.Cqrs.Feedbacks.Validators;

public class FeedbackValidatorBase<T> : AbstractValidator<T> where T : FeedbackCommand
{
    public FeedbackValidatorBase()
    {
        RuleFor(x => x.Content)
            .NotEmpty()
            .WithMessage("This field is required");

        RuleFor(x => x.BlogId)
            .NotEmpty()
            .WithMessage("This field is required")
            .GreaterThan(0)
            .WithMessage("Blog Id must greater than 0");

        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("This field is required")
            .GreaterThan(0)
            .WithMessage("User Id must greater than 0");
    }
}




