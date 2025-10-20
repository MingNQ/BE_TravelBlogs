using System.Text.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TravelBlogs.Core.Application.Configurations;
using TravelBlogs.Core.Application.Dto.Integrates.Emails;
using TravelBlogs.Core.Application.Dto.Integrates.Geo;
using TravelBlogs.Core.Application.Interfaces.Integrates;
using TravelBlogs.Infrastructure.ExternalService.ExternalEndpointClients.RefitInterfaces;

namespace TravelBlogs.Infrastructure.ExternalService.ExternalEndpointClients;

public class ExternalEnpointClient(
    HttpClient httpClient,
    ILogger<ExternalEnpointClient> logger,
    IOptions<ExternalUriSettings> options,
    IEmailServiceClient emailServiceClient,
    INotificationServiceClient notificationServiceClient) 
    : IExternalEnpointClient
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly ExternalUriSettings _externalUriSettings = options.Value;

    public async Task<List<CountryDto>> GetAllCountries()
    {
        var response = await _httpClient.GetStringAsync(_externalUriSettings.CountriesEndpoint);
        var countries = JsonSerializer.Deserialize<CountryReponse>(response
            , new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        return countries?.Data ?? [];
    }

    public async Task SendEmailNotification(string toAddress, string subject, string body)
    {
        try
        {
            await notificationServiceClient.SendEmail(new()
            {
                ToAddress = toAddress,
                Subject = subject,
                Body = body
            });
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "Failed to send email notification to {ToAddress}", toAddress);
        }
    }

    public async Task<EmailResponseDto> SendEmails(EmailRequestDto request)
    {
        return await emailServiceClient.SendEmails(request);
    }

    public async Task SendSmsNotification(string phoneNumber, string message)
    {
        await notificationServiceClient.SendSms(new()
        {
            PhoneNumber = phoneNumber,
            Message = message
        });
    }
}