namespace MessageBroker.Abstraction.Contracts
{
    public interface IMessageBrokerFactory
    {
        IMessageProducer CreateProducer();
        IMessageConsumer CreateConsumer();
    }
}
