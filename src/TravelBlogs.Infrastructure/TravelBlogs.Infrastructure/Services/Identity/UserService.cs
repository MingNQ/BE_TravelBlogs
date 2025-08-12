using TravelBlogs.Core.Application.Common.Repositories;
using TravelBlogs.Core.Application.Common.UnitOfWork;
using TravelBlogs.Core.Application.Cqrs.Users.Commands;
using TravelBlogs.Core.Application.Dto.Authorization.Accounts;
using TravelBlogs.Core.Application.Dto.Authorization.Verification;
using TravelBlogs.Core.Application.Dto.Persistence.Catalog.User;
using TravelBlogs.Core.Application.Interfaces.Services;
using TravelBlogs.Core.Domain.Entities.Identity;

namespace TravelBlogs.Infrastructure.Services.Identity;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    // private readonly IFilePathService _filePathService;
    // private readonly IVerificationService _verificationService;
    // private readonly IEmailService _emailService;
    private readonly IWriteRepository<User> _userRepository;
    private readonly IWriteRepository<Role> _roleRepository;

    public Task<bool> ChangePassword(UpdatePasswordCommand request)
    {
        throw new NotImplementedException();
    }

    public Task ChangePasswordAsync(int userId, string password)
    {
        throw new NotImplementedException();
    }

    public Task<CheckingItemExistModel> CheckEmailExisted(string email)
    {
        throw new NotImplementedException();
    }

    public Task<SendVerificationEmailOutputModel> ForgotPassword(SendPasswordResetCodeInput input)
    {
        throw new NotImplementedException();
    }

    public Task<UserDto> GetLoginResultAsync(string username, string password)
    {
        throw new NotImplementedException();
    }

    public Task<UserDto> GetUserByIdAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public Task<UserDto> GetUserDetailById(long userId)
    {
        throw new NotImplementedException();
    }

    public Task<UserDto> GetUserEmailExisted(string email)
    {
        throw new NotImplementedException();
    }

    public Task<UserDto> Register(RegisterAccountInput input)
    {
        throw new NotImplementedException();
    }

    public Task ResendVerificationEmail(int userId)
    {
        throw new NotImplementedException();
    }

    public Task<string> ResetPassword(ResetPasswordInput input)
    {
        throw new NotImplementedException();
    }

    public Task SetVerificationEmail(string email)
    {
        throw new NotImplementedException();
    }

    public Task ValidateVerifyEmail(VerifyEmailInput input)
    {
        throw new NotImplementedException();
    }

    public Task<ResetPasswordOutput> ValidResetPasswordCode(ValidateResetPasswordCodeInput input)
    {
        throw new NotImplementedException();
    }
}
