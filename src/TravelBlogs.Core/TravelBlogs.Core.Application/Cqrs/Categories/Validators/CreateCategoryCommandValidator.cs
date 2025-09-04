using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using TravelBlogs.Core.Application.Cqrs.Categories.Commands;

namespace TravelBlogs.Core.Application.Cqrs.Categories.Validators
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Tên danh mục không được để trống.");

            RuleFor(x => x.Name)
                .MaximumLength(100).WithMessage("Tên danh mục không được vượt quá 100 ký tự.");
        }
    }
}
