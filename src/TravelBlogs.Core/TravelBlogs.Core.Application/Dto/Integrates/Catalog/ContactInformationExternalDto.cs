using TravelBlogs.Core.Application.Common.Interfaces;

namespace TravelBlogs.Core.Application.Dto.Integrates.Catalog;

public class ContactInformationExternalDto : IDto
{
	public long Id { get; set; }
    public string Email { get; set; } = string.Empty;
	public string PhoneNumber { get; set; } = string.Empty;
}