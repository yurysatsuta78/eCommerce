using Microsoft.EntityFrameworkCore;
using Orders.Domain.Interfaces;
using Orders.Domain.Models;
using Orders.Domain.QueryParams;
using Orders.Infrastructure.Data;
using Orders.Infrastructure.QueryBuilders;

namespace Orders.Infrastructure.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly OrdersDbContext _dbContext;
        private readonly DbSet<Order> _dbSet;

        public OrdersRepository(OrdersDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<Order>();
        }

        public Task<IEnumerable<Order>> GetFilteredAsync(OrderFilterParams filter, CancellationToken cancellationToken)
        {
            var builder = new OrderQueryBuilder(_dbSet.AsNoTracking().Include(co => co.OrderItems))
                .ByCustomerId(filter.CustomerId)
                .ByStatus(filter.Status);

            return builder.BuildPaginatedListAsync(filter, cancellationToken);
        }

        public Task<int> GetCountAsync(OrderFilterParams filter, CancellationToken cancellationToken) 
        {
            var builder = new OrderQueryBuilder(_dbSet.AsNoTracking().Include(co => co.OrderItems))
                .ByCustomerId(filter.CustomerId)
                .ByStatus(filter.Status);

            return builder.GetCountAsync(cancellationToken);
        }

        public Task<Order?> GetByIdAsync(Guid id, bool withIncludes, CancellationToken cancellationToken)
        {
            var query = _dbSet.AsQueryable();

            if (withIncludes) 
            {
                query = query.Include(co => co.OrderItems);
            }

            return query.FirstOrDefaultAsync(co => co.Id == id, cancellationToken);
        }

        public async Task AddAsync(Order order, CancellationToken cancellationToken)
        {
            await _dbSet.AddAsync(order, cancellationToken);
        }

        public void Update(Order order)
        {
            _dbSet.Update(order);
        }

        public void Delete(Order order)
        {
            _dbSet.Remove(order);
        }

        public Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            return _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
