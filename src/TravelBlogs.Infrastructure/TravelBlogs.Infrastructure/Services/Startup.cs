using Application.Identity.Tokens;
using Microsoft.Extensions.DependencyInjection;
using TravelBlogs.Core.Application.Common.Services;
using TravelBlogs.Core.Application.Interfaces.Infrastructures.Integrates.Email;
using TravelBlogs.Core.Application.Interfaces.Services;
using TravelBlogs.Infrastructure.Auth.Authorization;
using TravelBlogs.Infrastructure.ExternalService.Email;
using TravelBlogs.Infrastructure.Services.Catalog;
using TravelBlogs.Infrastructure.Services.Identity;
using TravelBlogs.Infrastructure.Services.Integrates;

namespace TravelBlogs.Infrastructure.Services;

public static class Startup
{
    public static IServiceCollection AddRegisterService(this IServiceCollection services)
    {
        services.AddTransient<IPaginationService, PaginationService>();
        services.AddTransient<ITokenService, TokenService>();
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<ISyncService, SyncService>();
        services.AddTransient<IVerificationService, VerificationService>();

        services.AddTransient<IEmailTemplateProvider, EmailTemplateProvider>();
        services.AddTransient<IEmailService, EmailService>();

        services.AddTransient<IFilePathService, FilePathService>();
        services.AddTransient<IFileStorageService, FileStorageService>();

        services.AddTransient<IBlogRequestService, BlogRequestService>();

        return services;
    }
}