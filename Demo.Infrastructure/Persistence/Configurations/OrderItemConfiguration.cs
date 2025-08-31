using Demo.Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo.Infrastructure.Persistence.Configurations;

internal sealed class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ToTable("OrderDetails");

        builder.HasKey(x => x.OrderId);

        builder.HasOne<Order>(x => x.Order)
            .WithMany(y => y.Details)
            .HasForeignKey(d => d.OrderId);

        builder.Property(x => x.Product);

        builder.Property(x => x.Price);

        builder.Property(x => x.Quantity);

        builder.Property(x => x.Discount);

        builder.Property(x => x.Total);
    }
}
