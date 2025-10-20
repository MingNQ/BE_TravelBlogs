using Refit;
using TravelBlogs.Core.Application.Dto.Integrates.Emails;

namespace TravelBlogs.Infrastructure.ExternalService.ExternalEndpointClients.RefitInterfaces;

public interface IEmailServiceClient
{
    [Post("/Mails/CreateMail")]
    Task<EmailResponseDto> SendEmails(EmailRequestDto request);
}