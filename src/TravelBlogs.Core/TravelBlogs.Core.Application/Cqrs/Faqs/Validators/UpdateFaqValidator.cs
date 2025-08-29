using FluentValidation;
using TravelBlogs.Core.Application.Cqrs.Faqs.Commands;

namespace TravelBlogs.Core.Application.Cqrs.Faqs.Validators;

public class UpdateFaqValidator : FaqValidatorBase<UpdateFaqCommand>
{
	public UpdateFaqValidator()
	{
		RuleFor(x => x.Id)
			.GreaterThan(0)
			.WithMessage("Faq ID must be greater than 0");
	}
}