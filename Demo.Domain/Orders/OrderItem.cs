namespace Demo.Domain.Orders;

public class OrderItem
{
    public long OrderId { get; private set; }
    public Order Order { get; private set; } // Navigation Property
    public string Product { get; private set; }
    public decimal Price { get; private set; }
    public int Quantity { get; private set; }
    public decimal Discount { get; private set; }
    public decimal Total { get; private set; }

    private OrderItem()
    {
        
    }

    private OrderItem(
        long orderId, 
        string product, 
        decimal price, 
        int quantity, 
        decimal discount, 
        decimal total)
    {
        OrderId = orderId;
        Product = product;
        Price = price;
        Quantity = quantity;
        Discount = discount;
        Total = total;
    }

    public static OrderItem Create(
        long orderId,
        string product,
        decimal price,
        int quantity,
        decimal discount)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(product);

        if (price <= 0)
            throw new ApplicationException("Price invalid");

        // TODO: Add more validations

        var total = price * quantity - discount;

        return new OrderItem(orderId, product, price, quantity, discount, total);
    }
}
