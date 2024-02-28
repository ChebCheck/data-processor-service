using DataProcessor.Entities;
using DataProcessor.Interfaces;
using DataProcessor.Models;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace DataProcessor.Services;

public class MessageReciverService : IMessageBroker, IDisposable
{
    private readonly IRepository<ModuleStatusEntity> _repository;
    private readonly IModel channel;
    private readonly IConnection connection;
    private readonly string queueKey = "InstrumentStatus";

    public MessageReciverService(IRepository<ModuleStatusEntity> repository, ConnectionFactory factory)
    {
        connection = factory.CreateConnection();
        channel = connection.CreateModel();
        channel.QueueDeclare(queueKey, false, false, false, null);
        _repository = repository;
    }

    public void Recive()
    {
        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (model, ea) =>
        {
            var recivedObject = JsonSerializer.Deserialize<InstrumentStatus>(
                Encoding.UTF8.GetString(ea.Body.ToArray()));

            if (recivedObject == null)
                throw new Exception();

            foreach (var item in recivedObject.DeviceStatuses)
            {
                _repository.Create(new ModuleStatusEntity()
                {
                    ModuleCategoryID = item.ModuleCategoryID,
                    ModuleState = item.RapidControlStatus.ModuleState
                }).Wait();
            }
        };
        channel.BasicConsume(queueKey, true, consumer);
    }

    public void Dispose()
    {
        channel.Close();
        connection.Close();
    }
}