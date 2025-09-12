using FluentValidation;
using TravelBlogs.Core.Application.Cqrs.Blogs.Commands;

namespace TravelBlogs.Core.Application.Cqrs.Blogs.Validators;

public class UpdateBlogCommandValidator : BlogValidatorBase<UpdateBlogCommand>
{
    public UpdateBlogCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("This field is required")
            .GreaterThan(0)
            .WithMessage("Blog Id must greater than 0");
    }
}