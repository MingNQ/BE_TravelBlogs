using System.Text.RegularExpressions;
using TravelBlogs.Core.Shared.Helpers;

namespace TravelBlogs.Core.Domain.ValueObjects.Verification;

public record ContactInfo
{
    private static readonly Regex EmailRegex = new(
    @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
    RegexOptions.Compiled | RegexOptions.IgnoreCase);

    private static readonly Regex PhoneRegex = new(
        @"^\+?[1-9]\d{7,14}$",
        RegexOptions.Compiled);

    public string Value { get; init; }
    public ContactType Type { get; init; }

    private ContactInfo(string value, ContactType type)
    {
        Value = value;
        Type = type;
    }

    public static ContactInfo Create(string contact)
    {
        if (string.IsNullOrWhiteSpace(contact))
            throw new Exception("Contact information cannot be empty");

        string trimmedContact = contact.Trim();

        // Try email first
        if (trimmedContact.Contains('@'))
        {
            return CreateEmail(trimmedContact);
        }

        // Otherwise treat as phone
        return CreatePhone(trimmedContact);
    }

    public static ContactInfo CreatePhone(string phone)
    {
        if (string.IsNullOrWhiteSpace(phone))
            throw new Exception("Phone number cannot be empty");

        string normalizedPhone = phone.Trim()
            .Replace(" ", "")
            .Replace("-", "");

        if (!normalizedPhone.StartsWith("+"))
        {
            normalizedPhone = "+" + normalizedPhone;
        }

        if (!PhoneRegex.IsMatch(normalizedPhone))
            throw new Exception("Invalid phone number format");

        return new ContactInfo(normalizedPhone, ContactType.Phone);
    }

    public static ContactInfo CreateEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new Exception("Email cannot be empty");

        string normalizedEmail = email.Trim().ToLowerInvariant();

        if (!EmailRegex.IsMatch(normalizedEmail))
            throw new Exception("Invalid email format");

        return new ContactInfo(normalizedEmail, ContactType.Email);
    }

    public bool IsEmail => Type == ContactType.Email;
    public bool IsPhone => Type == ContactType.Phone;

    public override string ToString() => Value;

    public string ValueMask()
    {
        if (IsEmail)
        {
            return MaskHelper.MaskEmail(Value);
        }

        return IsPhone ? MaskHelper.MaskPhone(Value) : Value;
    }
}

public enum ContactType
{
    None = 0,
    Email = 1,
    Phone = 2
}