using FluentValidation;
using TravelBlogs.Core.Application.Cqrs.FeedbackDocuments.Commands;

namespace TravelBlogs.Core.Application.Cqrs.FeedbackDocuments.Validators;

public class CreateFeedbackDocumentCommandValidator : FeedbackDocumentValidatorBase<CreateFeedbackDocumentCommand>
{
    public CreateFeedbackDocumentCommandValidator()
    {
    }
}