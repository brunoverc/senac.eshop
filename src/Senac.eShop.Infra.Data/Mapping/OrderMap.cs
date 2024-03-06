using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Senac.eShop.Domain.Entities;

namespace Senac.eShop.Infra.Data.Mapping
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");
            builder.Property(o => o.ClientId).IsRequired();
            builder.Property(o => o.AddressId).IsRequired();
            builder.Property(o => o.Status).IsRequired();
            builder.Property(o => o.Code).HasMaxLength(5).IsRequired();
            builder.Property(o => o.PaymentMethodId).IsRequired();
            builder.Property(o => o.TotalValue).HasPrecision(10, 2);
            builder.Property(o => o.Discount).HasPrecision(10, 2);
        }
    }
}
