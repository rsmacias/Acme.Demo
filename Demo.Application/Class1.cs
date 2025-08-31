using Demo.Domain.Customers;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace Demo.Application;

public class GetCustomerName
{
    private readonly ICustomerRepository _customerRepository;

    public GetCustomerName(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<string?> Handle(string input)
    {
        var customerName = await _customerRepository.GetCustomerNameAsync();

        if (string.IsNullOrWhiteSpace(customerName))
            throw new Exception("Customer not found");

        return customerName;
    }
}
