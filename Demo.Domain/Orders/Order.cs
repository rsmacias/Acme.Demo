using Demo.Domain.Abstractions;
using Demo.Domain.Customers;
using Demo.Domain.Shared;

namespace Demo.Domain.Orders;

public class Order : IAggregateRoot
{
    public long Id { get; private set; }
    public long CustomerId { get; private set; }
    public Customer Customer { get; private set; } // Navigation Property
    public Address ShippingAddress { get; private set; }
    public DateOnly CreationDate { get; private set; }
    public DateOnly ShippingDate { get; private set; }
    public decimal Total { get; set; }

    public List<OrderItem> Details { get; private set; }  // Navigation Property

    private Order()
    {
        
    }

    private Order(long Id, 
        long customerId,
        Address address,
        DateOnly shipppingDate,
        decimal total)
    {
        Id = Id;
        CustomerId = customerId;
        ShippingAddress = address;
        CreationDate = DateOnly.FromDateTime(DateTime.Today);
        ShippingDate = shipppingDate;
        Total = total;
    }

    public static Order Create(
        long customerId, 
        Address shippingAddress, 
        DateOnly shippingDate)
    {
        // TODO: validations

        return new Order(0L, customerId, shippingAddress, shippingDate, 0L);
    }

    public void AddItem(
        string product,
        decimal price,
        int quantity,
        decimal discount)
    {
        // TODO: Add validations

        var item = OrderItem.Create(Id, product, price, quantity, discount);

        Details.Add(item);
    }
}
