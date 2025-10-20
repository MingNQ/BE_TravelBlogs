using TravelBlogs.Core.Application.Dto.Integrates.Notifications;
using Refit;

namespace TravelBlogs.Infrastructure.ExternalService.ExternalEndpointClients.RefitInterfaces;

public interface INotificationServiceClient
{
    [Post("/notification/email/send")]
    Task<string> SendEmail(EmailNotificationRequest request);

    [Post("/notification/sms/send")]
    Task<string> SendSms(SmsNotificationRequest request);
}