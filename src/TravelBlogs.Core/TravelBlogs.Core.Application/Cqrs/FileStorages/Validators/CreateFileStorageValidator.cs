using FluentValidation;
using TravelBlogs.Core.Application.Common.Persistences;
using TravelBlogs.Core.Application.Cqrs.FileStorages.Commands;
using TravelBlogs.Core.Application.Cqrs.FileStorages.Specs;
using TravelBlogs.Core.Domain.Entities.Common;

namespace TravelBlogs.Core.Application.Cqrs.FileStorages.Validators;

public class CreateFileStorageValidator : FileStorageValidatorBase<CreateFileStorageCommand>
{
    public CreateFileStorageValidator(IReadRepository<FileStorage> fileStorageRepository)
    {
        RuleFor(x => x)
            .MustAsync(async (command, ct) =>
                await fileStorageRepository.FirstOrDefaultAsync(
                    new DuplicateFileStorage(command.FileUniqueName!, command.FullPath!,
                        command.FileName!, command.Path!, command.FullPath!), ct) is null)
            .OverridePropertyName("FileUniqueName, FullPath, FileName, Path, FullPath")
            .WithMessage("This is duplicated, please try again.");
    }
}