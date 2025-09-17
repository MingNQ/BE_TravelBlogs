using FluentValidation;
using TravelBlogs.Core.Application.Cqrs.FeedbackDocuments.Commands;

namespace TravelBlogs.Core.Application.Cqrs.FeedbackDocuments.Validators;

public class UpdateFeedbackDocumentCommandValidator : FeedbackDocumentValidatorBase<UpdateFeedbackDocumentCommand>
{
    public UpdateFeedbackDocumentCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("This field is required")
            .GreaterThan(0)
            .WithMessage("Feedback Document Id must greater than 0");
    }
}