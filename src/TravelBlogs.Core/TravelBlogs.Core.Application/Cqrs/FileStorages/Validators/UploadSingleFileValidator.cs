using FluentValidation;
using TravelBlogs.Core.Application.Cqrs.FileStorages.Commands;

namespace TravelBlogs.Core.Application.Cqrs.FileStorages.Validators;

public class UploadSingleFileValidator : AbstractValidator<UploadSingleFileCommand>
{
    public UploadSingleFileValidator()
    {
        RuleFor(p => p.FileData)
            .NotNull()
            .WithMessage("File is required")
            .Must(x => x is { Length: > 0 })
            .WithMessage("File cannot be empty")
            .When(x => x.FileData != null);
    }
}