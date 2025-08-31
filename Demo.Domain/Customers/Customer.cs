using Demo.Domain.Abstractions;
using Demo.Domain.Orders;
using Demo.Domain.Shared;

namespace Demo.Domain.Customers;

public class Customer : IAggregateRoot
{
    public long Id { get; private set; }
    public string Name { get; private set; }
    public string LastName { get; private set; }
    public Address Address { get; private set; }
    public Email Email { get; private set; }

    public DateTimeOffset CreatedOn { get; private set; }
    public DateTimeOffset UpdatedOn { get; private set; }

    public List<Order> Orders { get; private set; } // Navigation Property

    private Customer()
    {
        
    }

    private Customer(
        string name,
        string lastName,
        Address address,
        Email email)
    {
        Id = 0L;
        Name = name;
        LastName = lastName;
        Address = address;
        Email = email;

        CreatedOn = DateTimeOffset.Now;
    }

    public static Customer Create(string name,
        string lastName,
        Address address,
        Email email)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ApplicationException("Name invalid");

        if (string.IsNullOrWhiteSpace(lastName))
            throw new ApplicationException("Last Name invalid");


        var customer = new Customer(name, lastName, address, email);

        return customer;
    }


    public void SetEmail(Email email)
    {
        Email = email;
        UpdatedOn = DateTimeOffset.Now;
    }
}
