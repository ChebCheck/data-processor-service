using System.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DataProcessor.DI;
using DataProcessor.Interfaces;

ServiceCollection services = new ServiceCollection();
services.AddServices(ConfigurationManager.AppSettings); //"Data Source=moduleStatus.db"

var provider = services.BuildServiceProvider();

var messageBroker = provider.GetRequiredService<IMessageBroker>();
messageBroker.Recive();

Console.WriteLine(" Waiting for messages.");
Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();