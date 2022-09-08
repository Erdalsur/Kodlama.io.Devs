using Kodlama.Application.Services.Repositories;
using Kodlama.Persistence.Contexts;
using Kodlama.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kodlama.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
                                                                IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(options =>
                                                     options.UseSqlServer(
                                                         configuration.GetConnectionString("KodlamaCampConnectionString")));
            services.AddScoped<ILessonRepository, LessonRepository>();
            services.AddScoped<IProgrammingTechnologyRepository, ProgrammingTechnologyRepository>();

            return services;
        }
    }
}