namespace MessageBroker.Abstraction.Contracts
{
    public interface IMessageHandler<in TMessage> where TMessage : IMessage
    {
        Task HandleAsync(TMessage message);
    }
}
