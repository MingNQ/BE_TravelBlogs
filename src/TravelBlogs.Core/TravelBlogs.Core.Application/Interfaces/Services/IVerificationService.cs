using TravelBlogs.Core.Domain.Entities.Identity;
using TravelBlogs.Core.Domain.Events.Verification;
using TravelBlogs.Core.Domain.ValueObjects.Verification;

namespace TravelBlogs.Core.Application.Interfaces.Services;

public interface IVerificationService
{
    Task<UserVerification?> FindActiveVerification(ContactInfo contactInfo, VerificationMode mode, long? userId = null);

    Task InsertVerificationAsync(UserVerification verification, CancellationToken cancellation);

    Task UpdateVerificationAsync(UserVerification verification);

    Task DeleteVerificationAsync(long verificationId);

    Task<UserVerification?> FindActiveVerificationById(ContactInfo contactInfo, long verificationId);

    Task<UserVerification?> FindVerificationById(ContactInfo contactInfo, long verificationId);
}