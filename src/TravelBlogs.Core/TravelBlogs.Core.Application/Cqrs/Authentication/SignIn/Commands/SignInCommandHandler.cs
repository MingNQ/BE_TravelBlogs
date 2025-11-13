using Application.Identity.Tokens;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TravelBlogs.Core.Application.Common.Events;
using TravelBlogs.Core.Application.Common.Repositories;
using TravelBlogs.Core.Application.Common.UnitOfWork;
using TravelBlogs.Core.Application.Dto.Authentication;
using TravelBlogs.Core.Application.Interfaces.Services;
using TravelBlogs.Core.Application.Utility;
using TravelBlogs.Core.Domain.Entities.Identity;
using TravelBlogs.Core.Domain.Events.Verification;
using TravelBlogs.Core.Domain.ValueObjects.Verification;

namespace TravelBlogs.Core.Application.Cqrs.Authentication.SignIn.Commands;

public class InitiateSignInCommandHandler(
    IUnitOfWork unitOfWork,
    IEventPublisher eventPublisher,
    IVerificationService verificationService)
    : IRequestHandler<InitiateSignInCommand, InitiateSignInResponse>
{
    private readonly IWriteRepository<User> _userRepository = unitOfWork.GetRepository<User>();

    public async Task<InitiateSignInResponse> Handle(InitiateSignInCommand request, CancellationToken cancellationToken)
    {
        var contactInfo = ContactInfo.Create(request.Contact);

        var user = await ValidateCredentialsAsync(contactInfo, request.Password);
        if (user == null)
        {
            throw new UnauthorizedAccessException("Invalid contact or password.");
        }

        var userDto = user.Adapt<UserProfileDto>();
        userDto.IsEmailVerified = user.IsVerifiedEmail ?? false;
        userDto.IsPhoneVerified = user.IsVerifiedPhone ?? false;

        var verificationExist = await verificationService.FindActiveVerification(contactInfo, VerificationMode.SignIn);
        if (verificationExist != null)
        {
            return new InitiateSignInResponse
            {
                VerificationId = verificationExist.Id,
                Contact = contactInfo.Value,
                Message = $"An existing verification code has been sent to {contactInfo.ValueMask()}",
                User = userDto
            };
        }

        var verification = UserVerification.CreateForSignIn(contactInfo, user.Id);
        await verificationService.InsertVerificationAsync(verification, cancellationToken);

        var verificationEvent = new VerificationCreatedEvent(
            verification.Id,
            contactInfo,
            VerificationMode.SignIn,
            verification.GetVerificationCode());
        await eventPublisher.PublishAsync(verificationEvent);

        return new InitiateSignInResponse
        {
            VerificationId = verification.Id,
            Contact = contactInfo.Value,
            Message = $"A verification code has been sent to your contact. {contactInfo.ValueMask()}",
            User = userDto
        };
    }

    private async Task<User?> ValidateCredentialsAsync(ContactInfo contactInfo, string password)
    {
        const string defaultPassword = "Abc@1234"; // For testing purposes only - to be removed in production
        string passwordHash = Utils.ComputeHash(password);

        User? user;

        if (contactInfo.IsEmail)
        {
            user = await _userRepository.GetFirstOrDefaultAsync(
                predicate: u => u.NormalizedEmail == contactInfo.Value.ToUpperInvariant() &&
                               (u.PasswordHash == passwordHash || password == defaultPassword),
                include: x => x.Include(u => u.UserRoles).ThenInclude(ur => ur.Role!),
                disableTracking: true);
        }
        else
        {
            user = await _userRepository.GetFirstOrDefaultAsync(
                predicate: u => u.PhoneNumber == contactInfo.Value &&
                              (u.PasswordHash == passwordHash || password == defaultPassword),
                include: x => x.Include(u => u.UserRoles).ThenInclude(ur => ur.Role!),
                disableTracking: true);
        }

        return user;
    }
}

public class VerifySignInOtpCommandHandler(
    IUnitOfWork unitOfWork,
    ITokenService tokenService,
    IVerificationService verificationService)
    : IRequestHandler<VerifySignInOtpCommand, VerifySignInOtpResponse>
{
    private readonly IWriteRepository<User> _userRepository = unitOfWork.GetRepository<User>();
    private readonly IWriteRepository<UserVerification> _verificationRepository = unitOfWork.GetRepository<UserVerification>();

    public async Task<VerifySignInOtpResponse> Handle(VerifySignInOtpCommand request, CancellationToken cancellationToken)
    {
        var contactInfo = ContactInfo.Create(request.Contact);

        var verification = await verificationService.FindActiveVerification(contactInfo, VerificationMode.SignIn);
        if (verification == null || verification.Mode != nameof(VerificationMode.SignIn))
        {
            throw new InvalidOperationException("No active sign-in verification found for the provided contact.");
        }

        if (!verification.VerifyCode(request.VerificationCode))
        {
            throw new UnauthorizedAccessException("Invalid verification code.");
        }

        var user = await _userRepository.GetFirstOrDefaultAsync(
            predicate: u => u.Id == verification.UserId,
            include: x => x.Include(u => u.UserRoles).ThenInclude(ur => ur.Role!),
            disableTracking: true);

        if (user == null)
        {
            throw new InvalidOperationException("User associated with the verification not found.");
        }

        if (!user.IsVerified())
        {
            if (contactInfo.IsEmail)
            {
                user.VerifyEmail();
            }
            else
            {
                user.VerifyPhone();
            }
            _userRepository.Update(user);
        }

        verification.MarkAsUsed();
        _verificationRepository.Update(verification);
        await unitOfWork.SaveChangesAsync();

        var userDto = user.Adapt<UserProfileDto>();
        userDto.IsEmailVerified = user.IsVerifiedEmail ?? false;
        userDto.IsPhoneVerified = user.IsVerifiedPhone ?? false;

        await verificationService.DeleteVerificationAsync(verification.Id);

        var tokenResponse = await tokenService.GetTokenAsync(user.Id, request.RememberMe, request.IpAddress, cancellationToken);

        return new VerifySignInOtpResponse
        {
            IsAuthenticated = true,
            AccessToken = tokenResponse.Token,
            RefreshToken = tokenResponse.RefreshToken,
            ExpiresAt = tokenResponse.RefreshTokenExpiryTime,
            Message = "Sign-in successful.",
            User = userDto
        };
    }
}

public class ResendSignInOtpCommandHandler(
    IUnitOfWork unitOfWork,
    IEventPublisher eventPublisher,
    IVerificationService verificationService)
    : IRequestHandler<ResendSignInOtpCommand, ResendSignInOtpResponse>
{
    private readonly IWriteRepository<UserVerification> _verificationRepository = unitOfWork.GetRepository<UserVerification>();

    public async Task<ResendSignInOtpResponse> Handle(ResendSignInOtpCommand request, CancellationToken cancellationToken)
    {
        var contactInfo = ContactInfo.Create(request.Contact);

        var verification = await verificationService.FindActiveVerification(contactInfo, VerificationMode.SignIn);
        if (verification == null || verification.Mode != nameof(VerificationMode.SignIn)) 
        {
            throw new InvalidOperationException("No active sign-in verification found for the provided contact.");
        }

        verification.Resend();
        await verificationService.UpdateVerificationAsync(verification);        

        var verificationEvent = new VerificationCreatedEvent(
            verification.Id,
            contactInfo,
            VerificationMode.SignIn,
            verification.GetVerificationCode());
        await eventPublisher.PublishAsync(verificationEvent);

        return new ResendSignInOtpResponse
        {
            IsSent = true,
            VerificationId = verification.Id,
            Message = $"A new verification code has been sent to your contact. {contactInfo.ValueMask()}"
        };
    }
}