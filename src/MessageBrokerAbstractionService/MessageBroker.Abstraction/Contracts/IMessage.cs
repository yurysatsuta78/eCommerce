namespace MessageBroker.Abstraction.Contracts
{
    public interface IMessage
    {
        public Guid Id { get; }
        public DateTime CreationDate { get; }
    }
}
