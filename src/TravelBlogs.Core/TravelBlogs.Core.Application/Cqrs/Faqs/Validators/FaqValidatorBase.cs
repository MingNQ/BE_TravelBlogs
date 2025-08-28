using FluentValidation;
using TravelBlogs.Core.Application.Cqrs.Faqs.Commands;

namespace TravelBlogs.Core.Application.Cqrs.Faqs.Validators;

public class FaqValidatorBase<T> : AbstractValidator<T> where T : FaqBaseCommand
{
	public FaqValidatorBase()
	{
		RuleFor(x => x.Question)
			.NotEmpty()
			.WithMessage("Question is required.")
			.MaximumLength(500)
			.WithMessage("Question must not exceed 500 characters.");

		RuleFor(x => x.Answer)
			.NotEmpty()
			.WithMessage("Answer is required.")
			.MaximumLength(4000)
			.WithMessage("Answer must not exceed 4000 characters.");
	}
}



