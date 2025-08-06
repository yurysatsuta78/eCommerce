using Microsoft.EntityFrameworkCore;
using Order.Domain.Interfaces;
using Order.Domain.Models;
using Order.Domain.QueryParams;
using Order.Infrastructure.Data;
using Order.Infrastructure.QueryBuilders;

namespace Order.Infrastructure.Repositories
{
    public class CustomerOrdersRepository : ICustomerOrdersRepository
    {
        private readonly OrdersDbContext _dbContext;
        private readonly DbSet<CustomerOrder> _dbSet;

        public CustomerOrdersRepository(OrdersDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<CustomerOrder>();
        }

        public Task<IEnumerable<CustomerOrder>> GetFilteredAsync(CustomerOrderFilterParams filter, CancellationToken cancellationToken)
        {
            var builder = new CustomerOrderQueryBuilder(_dbSet.AsNoTracking().Include(co => co.OrderItems))
                .ByCustomerId(filter.CustomerId)
                .ByStatus(filter.Status)
                .MinTotalPrice(filter.MinTotalPrice)
                .MaxTotalPrice(filter.MaxTotalPrice);

            return builder.BuildPaginatedListAsync(filter, cancellationToken);
        }

        public Task<int> GetCountAsync(CustomerOrderFilterParams filter, CancellationToken cancellationToken) 
        {
            var builder = new CustomerOrderQueryBuilder(_dbSet.AsNoTracking().Include(co => co.OrderItems))
                .ByCustomerId(filter.CustomerId)
                .ByStatus(filter.Status)
                .MinTotalPrice(filter.MinTotalPrice)
                .MaxTotalPrice(filter.MaxTotalPrice);

            return builder.GetCountAsync(cancellationToken);
        }

        public Task<CustomerOrder?> GetByIdAsync(Guid id, bool withIncludes, CancellationToken cancellationToken)
        {
            var query = _dbSet.AsQueryable();

            if (withIncludes) 
            {
                query = query.Include(co => co.OrderItems);
            }

            return query.FirstOrDefaultAsync(co => co.Id == id, cancellationToken);
        }

        public async Task AddAsync(CustomerOrder customerOrder, CancellationToken cancellationToken)
        {
            await _dbSet.AddAsync(customerOrder, cancellationToken);
        }

        public void Update(CustomerOrder customerOrder)
        {
            _dbSet.Update(customerOrder);
        }

        public void Delete(CustomerOrder customerOrder)
        {
            _dbSet.Remove(customerOrder);
        }

        public Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            return _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
