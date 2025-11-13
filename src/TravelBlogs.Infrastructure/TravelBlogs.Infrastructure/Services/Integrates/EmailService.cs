using TravelBlogs.Core.Application.Dto.Authorization.Verification;
using TravelBlogs.Core.Application.Interfaces.Infrastructures.Integrates.Email;
using TravelBlogs.Core.Application.Interfaces.Integrates;

namespace TravelBlogs.Infrastructure.Services.Integrates;

public class EmailService(
    IExternalEnpointClient emailSender,
    IEmailTemplateProvider emailTemplateProvider) 
    : IEmailService
{
    public Task ChangePasswordSuccessfullyAsync(string emailAddress, string fullName, string language)
    {
        throw new NotImplementedException();
    }

    public Task SendVerificationCodeAsync(SendVerificationByEmailInput input, string language)
    {
        throw new NotImplementedException();
    }

    public Task SendVerificationCodeForUpdateProfileAsync(SendVerificationByEmailInput input, string language)
    {
        throw new NotImplementedException();
    }

    public async Task SendVerificationEmailVerify(SendVerificationByEmailInput input, string language)
    {
        string emailTemplate = await emailTemplateProvider.GetTemplateByNameAsync("verifyemail", language); 

        if (!string.IsNullOrEmpty(input.Code))
        {
            emailTemplate = emailTemplate.Replace("{{UserName}}", input.UserName);
            emailTemplate = emailTemplate.Replace("{{OTP_CODE}}", input.Code);
            emailTemplate = emailTemplate.Replace("{{EMAIL}}", input.Email);
        }

        await ReplaceBodyAndSend(input.Email, "EMAIL_VERIFICATION", emailTemplate);
    }

    public Task SendVerificationEmailVerifyLinkOnly(SendVerificationByEmailInput input, string language)
    {
        throw new NotImplementedException();
    }

    public Task SendVerificationPasswordReset(SendVerificationByEmailInput input, string language)
    {
        throw new NotImplementedException();
    }

    private async Task ReplaceBodyAndSend(string emailAddress, string subject, string emailTemplate)
    {
        await emailSender.SendEmailNotification(emailAddress, subject, emailTemplate);
        await Task.CompletedTask;
    }
}