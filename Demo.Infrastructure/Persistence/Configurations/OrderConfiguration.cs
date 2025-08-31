using Demo.Domain.Customers;
using Demo.Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo.Infrastructure.Persistence.Configurations;

internal sealed class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");

        builder.HasKey(x => x.Id);

        builder.HasOne<Customer>(x => x.Customer)
            .WithMany(y => y.Orders)
            .HasForeignKey(o => o.CustomerId);

        builder.OwnsOne(x => x.ShippingAddress, builderAddress =>
        {
            builderAddress.Property(y => y.City)
                .HasMaxLength(100);

            builderAddress.Property(y => y.Street)
                .HasMaxLength(100);

            builderAddress.Property(y => y.ZipCode)
                .HasMaxLength(10);
        });

        builder.Property(x => x.CreationDate)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.ShippingDate);

        builder.Property(x => x.Total);
    }
}
