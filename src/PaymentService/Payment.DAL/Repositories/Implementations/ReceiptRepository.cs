using MongoDB.Driver;
using Payment.DAL.Models;
using Payment.DAL.Options;
using Payment.DAL.QueryBuilders;
using Payment.DAL.QueryParams;
using Payment.DAL.Repositories.Interfaces;

namespace Payment.DAL.Repositories.Implementations
{
    public class ReceiptRepository : IReceiptRepository
    {
        private readonly IMongoCollection<ReceiptDb> _collection;

        public ReceiptRepository(IMongoDatabase mongoDatabase, MongoOptions options) 
        {
            _collection = mongoDatabase.GetCollection<ReceiptDb>(options.ReceiptsCollectionName);
        }

        public async Task<IEnumerable<ReceiptDb>> GetFilteredAsync(ReceiptQueryParams filter, 
            CancellationToken cancellationToken)
        {
            var builder = new ReceiptQueryBuilder()
                .ByOrderId(filter.OrderId)
                .ByStatus(filter.Status);

            var filterQuery = builder.Build();

            var receipts = await _collection
                .Find(filterQuery)
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Limit(filter.PageSize)
                .ToListAsync(cancellationToken);

            return receipts;
        }

        public async Task<ReceiptDb?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var receipt = await _collection
                .Find(r => r.Id == id)
                .FirstOrDefaultAsync(cancellationToken);

            return receipt;
        }

        public Task CreateAsync(ReceiptDb receipt, CancellationToken cancellationToken)
        {
            return _collection.InsertOneAsync(receipt, null, cancellationToken);
        }
    }
}
