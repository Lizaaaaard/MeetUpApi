using AutoMapper;
using Infrastructure.Mapping;
using Persistance.Repositories.Speaker;

namespace API.Configurations;

public static class InfrastructureConfiguration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(provider => new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new MappingProfile(provider.CreateScope().ServiceProvider.GetService<ISpeakerRepository>()));
 
        }).CreateMapper());
        return services;
    }
}