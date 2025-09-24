using FluentValidation;
using TravelBlogs.Core.Application.Cqrs.FileStorages.Commands;

namespace TravelBlogs.Core.Application.Cqrs.FileStorages.Validators;

public class UploadMultipleFileValidator : AbstractValidator<UploadMultipleFileCommand>
{
    public UploadMultipleFileValidator()
    {
        RuleFor(p => p.Files)
            .NotNull()
            .NotEmpty()
            .WithMessage("Files is required");
    }
}