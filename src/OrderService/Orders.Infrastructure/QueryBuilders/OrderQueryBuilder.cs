using Microsoft.EntityFrameworkCore;
using Orders.Domain.Enums;
using Orders.Domain.Models;
using Orders.Domain.QueryParams;

namespace Orders.Infrastructure.QueryBuilders
{
    public class OrderQueryBuilder
    {
        private IQueryable<Order> _query;

        public OrderQueryBuilder(IQueryable<Order> query)
        {
            _query = query;
        }

        public OrderQueryBuilder ByCustomerId(Guid? customerId) 
        {
            if (customerId is not null)
            {
                _query = _query.Where(o => o.CustomerId == customerId);
            }
            return this;
        }

        public OrderQueryBuilder ByStatus(OrderStatuses? status)
        {
            if (status is not null)
            {
                _query = _query.Where(o => o.Status == status);
            }
            return this;
        }

        public async Task<IEnumerable<Order>> BuildPaginatedListAsync(OrderFilterParams filter, 
            CancellationToken cancellationToken)
        {
            var pagedQuery = _query
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize);

            return await pagedQuery.ToListAsync(cancellationToken);
        }

        public async Task<int> GetCountAsync(CancellationToken cancellationToken)
        {
            return await _query.CountAsync(cancellationToken);
        }
    }
}
