namespace MessageBroker.Abstraction.Contracts
{
    public interface IMessageProducer
    {
        Task PublishAsync<TMessage>(TMessage message, string exchange, string routingKey) where TMessage : IMessage;
    }
}
