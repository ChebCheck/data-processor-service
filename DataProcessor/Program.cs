using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using DataProcessor.Models;
using Microsoft.Extensions.DependencyInjection;
using DataProcessor.DI;
using DataProcessor.Interfaces;
using DataProcessor.Entities;

ServiceCollection services = new ServiceCollection();
services.AddServices("Host = localhost; Port = 5432; Database = moduleStatus; Username = postgres; Password = postgres"); //"Data Source=moduleStatus.db"

var serviceProvider = services.BuildServiceProvider();


Console.WriteLine(" [*] Waiting for messages.");
InstrumentStatus instrumentStatus = new InstrumentStatus();

var factory = new ConnectionFactory() { HostName = "localhost" };
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();
channel.QueueDeclare("InstrumentStatus", false, false, false, null);

var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, ea) =>
{
    var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    var recivedObject = JsonSerializer.Deserialize<InstrumentStatus>(message);
    var repository = serviceProvider.GetRequiredService<IRepository<ModuleStatusEntity>>();

    if (recivedObject == null)
        throw new Exception();

    foreach(var item in recivedObject.DeviceStatuses)
    {
        repository.Create(new ModuleStatusEntity()
        {
            ModuleCategoryID = item.ModuleCategoryID,
            ModuleState = item.RapidControlStatus.ModuleState
        }).Wait();
    }
};
channel.BasicConsume("InstrumentStatus", true, consumer);

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();