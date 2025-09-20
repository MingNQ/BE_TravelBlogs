using System.Text.RegularExpressions;
using TravelBlogs.Core.Domain.Common.Contracts;
using TravelBlogs.Core.Domain.Entities.Catalog;
using TravelBlogs.Core.Domain.Entities.Common;

namespace TravelBlogs.Core.Domain.Entities.Identity;

public class User : AuditableEntity<long>
{
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string UserName { get; private set; } = string.Empty;
    public string NormalizedUserName { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string NormalizedEmail { get; private set; } = string.Empty;
    public string PhoneNumber { get; private set; } = string.Empty;
    public string PasswordHash { get; private set; } = string.Empty;
    public DateTimeOffset? DateOfBirth { get; private set; }
    public long? AvatarId { get; private set; }
    public DateTimeOffset JoinDate { get; private set; }
    public bool? IsVerifiedPhone { get; private set; }
    public bool? IsVerifiedEmail { get; private set; }
    public FileStorage? Avatar { get; private set; }
    private readonly List<UserRole> _userRoles = new();
    public IReadOnlyCollection<UserRole> UserRoles => _userRoles.AsReadOnly();
    private readonly List<Comment> _comments = [];
    public IReadOnlyCollection<Comment> Comments => _comments.AsReadOnly();

    public User(string userName, string email, string? firstName, string? lastName)
    {
        SetUserName(userName);
        SetEmail(email);
        FirstName = firstName ?? string.Empty;
        LastName = lastName ?? string.Empty;
        JoinDate = DateTimeOffset.UtcNow;
    }

    public void SetEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new ArgumentException("Email cannot be empty", nameof(email));
        }

        // Basic email validation using regex
        if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            throw new ArgumentException("Invalid email format", nameof(email));
        }

        Email = email;
        NormalizedEmail = email.ToUpperInvariant();

        // Reset verification when email changes
        IsVerifiedEmail = false;
    }

    public void SetUserName(string userName)
    {
        UserName = userName;
        NormalizedUserName = userName.ToUpperInvariant();
    }

    public void SetPassword(string passwordHash)
    {
        if (string.IsNullOrWhiteSpace(passwordHash))
        {
            throw new ArgumentException("Password hash cannot be empty", nameof(passwordHash));
        }

        PasswordHash = passwordHash;
    }

    public void SetPhoneNumber(string phoneNumber)
    {
        if (!string.IsNullOrWhiteSpace(phoneNumber))
        {
            // Basic phone number validation - can be enhanced
            if (!Regex.IsMatch(phoneNumber.Trim(), @"^\+?[0-9]{10,15}$"))
            {
                throw new ArgumentException("Invalid phone number format", nameof(phoneNumber));
            }
        }

        PhoneNumber = phoneNumber;

        // Reset verification when phone changes
        IsVerifiedPhone = false;
    }

    public void SetAvatar(long avatarId)
    {
        AvatarId = avatarId;
    }

    public void SetDateOfBirth(DateTimeOffset? dateOfBirth)
    {
        if (dateOfBirth.HasValue && dateOfBirth.Value > DateTimeOffset.UtcNow)
        {
            throw new ArgumentException("Date of birth cannot be in the future", nameof(dateOfBirth));
        }

        DateOfBirth = dateOfBirth;
    }

    public void VerifyEmail()
    {
        IsVerifiedEmail = true;
    }

    public void VerifyPhone()
    {
        IsVerifiedPhone = true;
    }

    public void AddRole(long roleId)
    {
        if (_userRoles.Any(ur => ur.RoleId == roleId))
        {
            return; // Role already exists, do nothing
        }

        var userRole = new UserRole
        {
            UserId = Id,
            RoleId = roleId
        };

        _userRoles.Add(userRole);
    }

    public void AddRoles(IEnumerable<long> roleIds)
    {
        foreach (long roleId in roleIds)
        {
            AddRole(roleId);
        }
    }

    public void RemoveRole(long roleId)
    {
        var userRole = _userRoles.FirstOrDefault(ur => ur.RoleId == roleId);
        if (userRole != null)
        {
            _userRoles.Remove(userRole);
        }
    }

    public void RemoveAllRoles()
    {
        if (_userRoles.Any())
        {
            _userRoles.Clear();
        }
    }

    public void UpdateRoles(IEnumerable<long> roleIds)
    {
        ArgumentNullException.ThrowIfNull(roleIds);

        var newRoleIds = roleIds.ToHashSet();
        var currentRoleIds = _userRoles.Select(ur => ur.RoleId).ToHashSet();

        // Find roles to remove (exist in current but not in new)
        var rolesToRemove = currentRoleIds.Except(newRoleIds).ToList();

        // Find roles to add (exist in new but not in current)
        var rolesToAdd = newRoleIds.Except(currentRoleIds).ToList();

        // Remove roles that are no longer needed
        foreach (var roleId in rolesToRemove)
        {
            RemoveRole(roleId);
        }

        // Add new roles
        foreach (var roleId in rolesToAdd)
        {
            AddRole(roleId);
        }
    }

    public bool HasRole(int roleId)
    {
        return _userRoles.Any(ur => ur.RoleId == roleId);
    }

    public List<long> GetRoleIds()
    {
        return _userRoles.Select(ur => ur.RoleId).ToList();
    }

    // Helper methods
    public string GetFullName()
    {
        return $"{FirstName} {LastName}".Trim();
    }

    public void UpdateName(string firstName, string lastName)
    {
        FirstName = firstName ?? string.Empty;
        LastName = lastName ?? string.Empty;
    }
}