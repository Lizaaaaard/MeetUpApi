using Microsoft.EntityFrameworkCore;
using Persistance;
using Persistance.Repositories.Event;
using Persistance.Repositories.Speaker;

namespace API.Configurations
{
    public static class PersistenceConfigurations
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            string connection = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(options =>
                options
                    .UseSqlServer(connection));
            services.AddControllers()
                .AddNewtonsoftJson(x => x
                    .SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling
                    .Ignore);
            
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<ISpeakerRepository, SpeakerRepository>();
            return services;
        }
    }
}
