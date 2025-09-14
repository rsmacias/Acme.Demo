using Demo.Domain.Customers;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Demo.Infrastructure.Persistence.Repositories;

internal class CustomerRepository : Repository<Customer>, ICustomerRepository
{
    private readonly DemoContext context;

    public CustomerRepository(DemoContext context) : base(context)
    {
        this.context = context;
    }

    public Task<Customer?> GetCustomerByEmailAsync(Email email)
    {
        var query = _context.Customers
            .Where(x => x.Email == email);

        return query.FirstOrDefaultAsync();
    }
}
