using FluentValidation;
using TravelBlogs.Core.Application.Cqrs.Users.Commands;

namespace TravelBlogs.Core.Application.Cqrs.Users.Validators;

public class UpdateUserCommandValidator : UserValidatorBase<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("User ID must be greater than 0");
    }
}