using MessageBroker.Abstraction.Contracts;

namespace MessageBroker.Abstraction.Events
{
    public abstract class IntegrationEvent : IMessage
    {
        public Guid Id { get; init; }
        public DateTime CreationDate { get; init; }

        protected IntegrationEvent()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.UtcNow;
        }
    }
}
