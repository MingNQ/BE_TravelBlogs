using FluentValidation;
using TravelBlogs.Core.Application.Cqrs.Feedbacks.Commands;

namespace TravelBlogs.Core.Application.Cqrs.Feedbacks.Validators;

public class CreateFeedbackCommandValidator : FeedbackValidatorBase<CreateFeedbackCommand>
{
    public CreateFeedbackCommandValidator()
    {
    }
}




