using AutoMapper;
using FluentValidation;

using Microsoft.Extensions.DependencyInjection;

using System.Reflection;
using TravelBlogs.Core.Application.Mappings;


namespace TravelBlogs.Core.Application;



public static class Startup

{

    public static IServiceCollection AddApplication(this IServiceCollection services)

    {
        var assembly = Assembly.GetExecutingAssembly();

        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new MappingProfile());
        });

        IMapper mapper = mapperConfig.CreateMapper();

        services.AddSingleton(mapper);

        services.AddValidatorsFromAssembly(assembly);
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

        return services;

    }

}