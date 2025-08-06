using Microsoft.EntityFrameworkCore;
using Order.Domain.Enums;
using Order.Domain.Models;
using Order.Domain.QueryParams;

namespace Order.Infrastructure.QueryBuilders
{
    public class CustomerOrderQueryBuilder
    {
        private IQueryable<CustomerOrder> _query;

        public CustomerOrderQueryBuilder(IQueryable<CustomerOrder> query)
        {
            _query = query;
        }

        public CustomerOrderQueryBuilder ByCustomerId(Guid? customerId) 
        {
            if (customerId is not null)
            {
                _query = _query.Where(o => o.CustomerId == customerId);
            }
            return this;
        }

        public CustomerOrderQueryBuilder ByStatus(CustomerOrderStatuses? status)
        {
            if (status is not null)
            {
                _query = _query.Where(o => o.Status == status);
            }
            return this;
        }

        public async Task<IEnumerable<CustomerOrder>> BuildPaginatedListAsync(CustomerOrderFilterParams filter, 
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
