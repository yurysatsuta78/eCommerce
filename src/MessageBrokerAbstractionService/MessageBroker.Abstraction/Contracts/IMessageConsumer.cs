namespace MessageBroker.Abstraction.Contracts
{
    public interface IMessageConsumer
    {
        Task SubscribeAsync<TMessage, THandler>(string exchange, string routingKey, string queue)
            where TMessage : IMessage
            where THandler : IMessageHandler<TMessage>;
    }
}
