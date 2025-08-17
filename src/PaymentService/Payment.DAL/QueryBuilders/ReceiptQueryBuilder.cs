using MongoDB.Driver;
using Payment.DAL.Enums;
using Payment.DAL.Models;

namespace Payment.DAL.QueryBuilders
{
    public class ReceiptQueryBuilder
    {
        private readonly FilterDefinitionBuilder<ReceiptDb> _builder = Builders<ReceiptDb>.Filter;
        private FilterDefinition<ReceiptDb> _filter = Builders<ReceiptDb>.Filter.Empty;

        public ReceiptQueryBuilder ByOrderId(Guid? orderId)
        {
            if (orderId is not null)
            {
                _filter &= _builder.Eq(r => r.OrderId, orderId);
            }
            return this;
        }

        public ReceiptQueryBuilder ByStatus(Statuses? status) 
        {
            if (status is not null) 
            {
                _filter &= _builder.Eq(r => r.Status, status.Value);
            }
            return this;
        }

        public FilterDefinition<ReceiptDb> Build()
        {
            return _filter;
        }
    }
}
