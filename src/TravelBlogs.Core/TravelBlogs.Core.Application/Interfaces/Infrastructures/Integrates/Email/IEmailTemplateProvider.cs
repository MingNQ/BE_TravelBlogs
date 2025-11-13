namespace TravelBlogs.Core.Application.Interfaces.Infrastructures.Integrates.Email;

public interface IEmailTemplateProvider
{
    string GetTemplateByName(string name, string languageCode = "en");
    Task<string> GetTemplateByNameAsync(string name, string languageCode = "en");
}