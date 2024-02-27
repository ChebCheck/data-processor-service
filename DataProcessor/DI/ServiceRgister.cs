using DataProcessor.Entities;
using DataProcessor.Repositories;
using DataProcessor.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace DataProcessor.DI;

public static class ServiceRgister
{
    public static void AddServices(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ApplicationContext>((options) =>
        {
            //options.UseSqlite(connectionString);
            options.UseNpgsql(connectionString);
        });
        services.AddScoped<IRepository<ModuleStatusEntity>, ModulelStatusRepository>();
    }
}
