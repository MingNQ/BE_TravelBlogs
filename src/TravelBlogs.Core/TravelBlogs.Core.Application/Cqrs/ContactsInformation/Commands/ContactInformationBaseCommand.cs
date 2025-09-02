namespace TravelBlogs.Core.Application.Cqrs.ContactsInformation.Commands;

public class ContactInformationBaseCommand
{
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public bool IsDefault { get; set; }
}