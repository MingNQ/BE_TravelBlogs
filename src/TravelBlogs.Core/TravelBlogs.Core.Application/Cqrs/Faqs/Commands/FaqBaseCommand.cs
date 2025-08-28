namespace TravelBlogs.Core.Application.Cqrs.Faqs.Commands;

public class FaqBaseCommand
{
	public string Question { get; set; } = string.Empty;
	public string Answer { get; set; } = string.Empty;
}



