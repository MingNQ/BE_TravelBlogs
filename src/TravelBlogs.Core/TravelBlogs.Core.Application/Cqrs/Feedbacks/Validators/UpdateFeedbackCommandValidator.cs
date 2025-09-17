using FluentValidation;
using TravelBlogs.Core.Application.Cqrs.Feedbacks.Commands;

namespace TravelBlogs.Core.Application.Cqrs.Feedbacks.Validators;

public class UpdateFeedbackCommandValidator : FeedbackValidatorBase<UpdateFeedbackCommand>
{
    public UpdateFeedbackCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("This field is required")
            .GreaterThan(0)
            .WithMessage("Feedback Id must greater than 0");
    }
}