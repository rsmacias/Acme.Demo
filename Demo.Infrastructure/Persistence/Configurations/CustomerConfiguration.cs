using Demo.Domain.Customers;
using Demo.Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo.Infrastructure.Persistence.Configurations;

internal sealed class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.LastName)
            .IsRequired()
            .HasMaxLength(50);

        //builder.HasMany<Order>(x => x.Orders)
        //    .WithOne(y => y.Customer)
        //    .HasForeignKey(o => o.CustomerId);

        builder.OwnsOne(x => x.Address, builderAddress =>
        {
            builderAddress.Property(y => y.City)
                .HasMaxLength(100);

            builderAddress.Property(y => y.Street)
                .HasMaxLength(100);

            builderAddress.Property(y => y.ZipCode)
                .HasMaxLength(10);
        });

        builder.OwnsOne(x => x.Email, emailBuilder =>
        {
            emailBuilder.Property(x => x.Value)
                .HasColumnName("Email");
        });

        builder.Property(x => x.CreatedOn)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.UpdatedOn);
    }
}
