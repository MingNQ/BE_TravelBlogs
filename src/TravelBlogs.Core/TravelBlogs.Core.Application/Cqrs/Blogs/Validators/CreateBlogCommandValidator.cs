using FluentValidation;
using TravelBlogs.Core.Application.Cqrs.Blogs.Commands;

namespace TravelBlogs.Core.Application.Cqrs.Blogs.Validators;

public class CreateBlogCommandValidator : BlogValidatorBase<CreateBlogCommand>
{
    public CreateBlogCommandValidator()
    {
        RuleFor(x => x.AuthorId)
            .NotEmpty()
            .WithMessage("This field is required")
            .GreaterThan(0)
            .WithMessage("Author Id must greater than 0");
    }
}