namespace DataProcessor.Interfaces;

public interface IMessageBroker : IDisposable
{
    void Recive();
}
