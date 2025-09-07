using TravelBlogs.Core.Application.Common.Interfaces;

namespace TravelBlogs.Core.Application.Dto.Persistence.Catalog.ContactInformation;

public class ContactInformationDto : IDto
{
    public long Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public bool IsDefault { get; set; }
}