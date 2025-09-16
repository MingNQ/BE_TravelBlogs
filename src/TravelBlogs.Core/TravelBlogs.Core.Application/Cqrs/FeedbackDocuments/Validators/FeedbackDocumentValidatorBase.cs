using FluentValidation;
using TravelBlogs.Core.Application.Cqrs.FeedbackDocuments.Commands;

namespace TravelBlogs.Core.Application.Cqrs.FeedbackDocuments.Validators;

public class FeedbackDocumentValidatorBase<T> : AbstractValidator<T> where T : FeedbackDocumentCommand
{
    public FeedbackDocumentValidatorBase()
    {
        RuleFor(x => x.FeedbackId)
            .NotEmpty()
            .WithMessage("This field is required")
            .GreaterThan(0)
            .WithMessage("Feedback Id must greater than 0");

        RuleFor(x => x.FileStorageId)
            .NotEmpty()
            .WithMessage("This field is required")
            .GreaterThan(0)
            .WithMessage("File Storage Id must greater than 0");
    }
}




