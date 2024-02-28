using DataProcessor.Entities;
using DataProcessor.Repositories;
using DataProcessor.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Specialized;
using DataProcessor.Services;

namespace DataProcessor.DI;

public static class ServiceRgister
{
    public static void AddServices(this IServiceCollection services, NameValueCollection appSettings)
    {
        services.AddDbContext<ApplicationContext>((options) =>
        {
            //options.UseSqlite(appSettings["connectionString"]);
            options.UseNpgsql(appSettings["connectionString"]);
        });
        services.AddScoped<IRepository<ModuleStatusEntity>, ModulelStatusRepository>();
        services.AddScoped<IMessageBroker, MessageReciverService>(
            (provider)=>new MessageReciverService(
                provider.GetRequiredService<IRepository<ModuleStatusEntity>>(),
                new RabbitMQ.Client.ConnectionFactory()
                {
                    HostName = appSettings["hostName"],
                    VirtualHost = appSettings["virtualHost"],
                    Port = Int32.Parse(appSettings["port"]),
                    UserName = appSettings["username"],
                    Password = appSettings["password"]
                }));
    }
}
