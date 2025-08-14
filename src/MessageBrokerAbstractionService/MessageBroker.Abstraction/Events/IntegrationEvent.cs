using MessageBroker.Abstraction.Contracts;

namespace MessageBroker.Abstraction.Events
{
    public abstract record IntegrationEvent : IMessage
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public DateTime CreationDate { get; init; } = DateTime.UtcNow;
    }
}
