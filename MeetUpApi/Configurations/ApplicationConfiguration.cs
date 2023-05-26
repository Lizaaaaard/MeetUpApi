using System.Text;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Servicies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Persistance;

namespace API.Configurations;

public static class ApplicationConfiguration
{
    public static IServiceCollection AddApplication (this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IEventService, EventService>();
        services.AddScoped<ISpeakerService, SpeakerService>();
        
        services.AddIdentity<User, IdentityRole<int>>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            })
            .AddEntityFrameworkStores<AppDbContext>();
        services.AddScoped<UserManager<User>>();
        services.AddScoped<SignInManager<User>>();

        services.AddScoped<IUserService, UserService>();
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                        .GetBytes(configuration.GetSection("AppSettings:Token").Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        
        return services;
    }
}