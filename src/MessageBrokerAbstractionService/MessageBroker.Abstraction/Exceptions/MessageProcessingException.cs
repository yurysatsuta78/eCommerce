namespace MessageBroker.Abstraction.Exceptions
{
    public class MessageProcessingException : MessageBrokerException
    {
        public MessageProcessingException() { }
        public MessageProcessingException(string message) : base(message) { }
        public MessageProcessingException(string message, Exception innerException) : base(message, innerException) { }
    }
}
