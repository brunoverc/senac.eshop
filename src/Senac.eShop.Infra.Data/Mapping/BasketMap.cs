using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Senac.eShop.Domain.Entities;

namespace Senac.eShop.Infra.Data.Mapping
{
    public class BasketMap : IEntityTypeConfiguration<Basket>
    {
        public void Configure(EntityTypeBuilder<Basket> builder)
        {
            builder.ToTable("Basket");

            builder.Property(b => b.ClientId).IsRequired();

            builder.HasKey(b => b.Id);
        }
    }
}
