using TravelBlogs.Core.Application.Dto.Integrates.Emails;
using TravelBlogs.Core.Application.Dto.Integrates.Geo;

namespace TravelBlogs.Core.Application.Interfaces.Integrates;

public interface IExternalEnpointClient
{
    Task<List<CountryDto>> GetAllCountries();
    Task<EmailResponseDto> SendEmails(EmailRequestDto request);
    Task SendSmsNotification(string phoneNumber, string message);
    Task SendEmailNotification(string toAddress, string subject, string body);
}