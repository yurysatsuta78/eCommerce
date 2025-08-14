namespace Contracts.Messaging
{
    public static class MessagingConstants
    {
        public static class OrdersExchange 
        {
            public const string Name = "orders_exchange";
            public const string OrderCreatedRoutingKey = "order.created";
            public const string OrderCancelledRoutingKey = "order.cancelled";
        }
    }
}
