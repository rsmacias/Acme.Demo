using Demo.Domain.Customers;
using Demo.Domain.Orders;
using Microsoft.EntityFrameworkCore;

namespace Demo.Infrastructure.Persistence;

public class DemoContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderDetails { get; set; }
}
