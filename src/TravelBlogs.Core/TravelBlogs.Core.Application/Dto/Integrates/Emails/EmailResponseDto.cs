namespace TravelBlogs.Core.Application.Dto.Integrates.Emails;

public class EmailResponseDto
{
    public int? StatusCode { get; set; }
    public string? StatusMessage { get; set; }
    public long? MailId { get; set; }
}