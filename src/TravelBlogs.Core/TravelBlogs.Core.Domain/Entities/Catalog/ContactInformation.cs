using System.ComponentModel.DataAnnotations;
using TravelBlogs.Core.Domain.Common.Contracts;

namespace TravelBlogs.Core.Domain.Entities.Catalog;

public class ContactInformation : AuditableEntity<long>
{
    public string Email { get; private set; } = string.Empty;

    [MaxLength(255)]
    public string PhoneNumber { get; private set; } = string.Empty;

    [MaxLength(11)]
    public bool IsDefault { get; private set; }

    public static ContactInformation Create(
        string email,
        string phoneNumber,
        bool isDefault)
    {

        return new ContactInformation
        {
            Email = email,
            PhoneNumber = phoneNumber,
            IsDefault = isDefault
        };
    }

    public void Update(
        string email,
        string phoneNumber,
        bool isDefault)
    {
        Email = email;
        PhoneNumber = phoneNumber;
        IsDefault = isDefault;
    }

    public void SetDefault(bool isDefault)
    {
        IsDefault = isDefault;
    }
}