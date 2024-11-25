using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Domain.Enums;
using Order.Domain.Models;
using Order.Domain.ValueObjects;

namespace Order.Infrastracture.Data.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Domain.Models.Order>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Order> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id).HasConversion(
                            orderId => orderId.Value,
                            dbId => OrderId.Of(dbId));

            builder.HasOne<Customer>()
              .WithMany()
              .HasForeignKey(o => o.CustomerId)
              .IsRequired();

            builder.HasMany(o => o.OrderItems)
                .WithOne()
                .HasForeignKey(oi => oi.OrderId);

            builder.Property(p => p.OrderName).HasMaxLength(100).IsRequired();

            builder.ComplexProperty(
               o => o.ShippingAddress, addressBuilder =>
               {
                   addressBuilder.Property(a => a.FirstName)
                       .HasMaxLength(50)
                       .IsRequired();

                   addressBuilder.Property(a => a.LastName)
                        .HasMaxLength(50)
                        .IsRequired();

                   addressBuilder.Property(a => a.EmailAddress)
                       .HasMaxLength(50);

                   addressBuilder.Property(a => a.AddressLine)
                       .HasMaxLength(180)
                       .IsRequired();

                   addressBuilder.Property(a => a.Country)
                       .HasMaxLength(50);

                   addressBuilder.Property(a => a.State)
                       .HasMaxLength(50);

                   addressBuilder.Property(a => a.ZipCode)
                       .HasMaxLength(5)
                       .IsRequired();
               });

            builder.ComplexProperty(
              o => o.BillingAddress, addressBuilder =>
              {
                  addressBuilder.Property(a => a.FirstName)
                       .HasMaxLength(50)
                       .IsRequired();

                  addressBuilder.Property(a => a.LastName)
                       .HasMaxLength(50)
                       .IsRequired();

                  addressBuilder.Property(a => a.EmailAddress)
                      .HasMaxLength(50);

                  addressBuilder.Property(a => a.AddressLine)
                      .HasMaxLength(180)
                      .IsRequired();

                  addressBuilder.Property(a => a.Country)
                      .HasMaxLength(50);

                  addressBuilder.Property(a => a.State)
                      .HasMaxLength(50);

                  addressBuilder.Property(a => a.ZipCode)
                      .HasMaxLength(5)
                      .IsRequired();
              });

            builder.Property(o => o.Status)
                .HasDefaultValue(OrderStatus.Draft)
                .HasConversion(
                    s => s.ToString(),
                    dbStatus => (OrderStatus)Enum.Parse(typeof(OrderStatus), dbStatus));

            builder.Property(o => o.TotalPrice);
        }
    }
}
