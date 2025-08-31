using Demo.Domain.Customers;
using System.Linq.Expressions;

namespace Demo.Infrastructure.Persistence.Repositories;

internal class CustomerRepository : ICustomerRepository
{
    private readonly DemoContext context;

    public CustomerRepository(DemoContext context)
    {
        this.context = context;
    }

    public void Add(Customer entity)
    {
        throw new NotImplementedException();
    }

    public void AddMany(IEnumerable<Customer> entities)
    {
        throw new NotImplementedException();
    }

    public bool Any(Expression<Func<Customer, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public void Delete(Customer entity)
    {
        throw new NotImplementedException();
    }

    public async Task<string?> GetCustomerNameAsync()
    {
        return "Hello";
    }

    public void Update(Customer entity)
    {
        throw new NotImplementedException();
    }
}
