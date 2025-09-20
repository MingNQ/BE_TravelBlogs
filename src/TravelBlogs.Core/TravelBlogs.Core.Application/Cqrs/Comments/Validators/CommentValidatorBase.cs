using FluentValidation;
using TravelBlogs.Core.Application.Cqrs.Comments.Commands;

namespace TravelBlogs.Core.Application.Cqrs.Comments.Validators;

public class CommentValidatorBase<T> : AbstractValidator<T> where T : CommentBaseCommand
{
    public CommentValidatorBase()
    {
        RuleFor(x => x.Content)
            .NotEmpty()
            .WithMessage("This field is required.")
            .MaximumLength(5000)
            .WithMessage("Content must not exceed 5000 characters.");
    }
}