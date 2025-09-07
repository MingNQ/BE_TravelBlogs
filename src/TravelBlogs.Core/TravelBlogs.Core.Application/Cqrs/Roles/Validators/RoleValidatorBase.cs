using FluentValidation;
using TravelBlogs.Core.Application.Cqrs.Roles.Commands;

namespace TravelBlogs.Core.Application.Cqrs.Roles.Validators;

public class RoleValidatorBase<T> : AbstractValidator<T> where T : RoleBaseCommand
{
    public RoleValidatorBase()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Role name is required.")
            .MaximumLength(256)
            .WithMessage("Role name must not exceed 256 characters.");
    }
}