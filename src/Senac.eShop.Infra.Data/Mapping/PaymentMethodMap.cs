using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Senac.eShop.Domain.Entities;

namespace Senac.eShop.Infra.Data.Mapping
{
    public class PaymentMethodMap : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.ToTable("PaymentMethod");
            builder.Property(o => o.Alias).HasMaxLength(50).IsRequired();
            builder.Property(o => o.CardId).HasMaxLength(120).IsRequired();
            builder.Property(o => o.Last4).HasMaxLength(4).IsRequired();
            builder.Property(o => o.ClientId).IsRequired();
        }
    }
}
